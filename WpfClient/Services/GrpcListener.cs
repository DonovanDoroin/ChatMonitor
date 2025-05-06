using Grpc.Net.Client;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfClient.Messages;
using WpfClient.Models;
using GrpcServer;
using Grpc.Core;

namespace WpfClient.Services
{
    public class GrpcListener : IGrpcListener
    {
        private readonly IMediator _mediator; // Used to dispatch notifications to MediatR handlers
        private readonly GrpcChannel _channel; // The gRPC communication channel
        private readonly MessageService.MessageServiceClient _client; // gRPC client stub generated from proto

        // Constructor receives MediatR instance via dependency injection
        public GrpcListener(IMediator mediator)
        {
            _mediator = mediator;
            _channel = GrpcChannel.ForAddress("https://localhost:7065"); // Create a channel to connect to the gRPC server at the given address (GrpcServer→Properties→launchSettings.json)
            _client = new MessageService.MessageServiceClient(_channel); // Instantiate the client using the generated gRPC stub class
        }

        // Starts listening to the server for streaming messages
        public async Task StartAsync()
        {
            using var call = _client.StreamMessages(new Empty()); // Initiate the gRPC call to start streaming messages from the server
            await foreach (var msg in call.ResponseStream.ReadAllAsync()) // Asynchronously read each incoming message from the server stream
            {
                // Convert the gRPC message to the WPF UI model
                var model = new InformationMessageModel
                {
                    Id = msg.Id,
                    From = msg.From,
                    To = msg.To,
                    Text = msg.Text,
                    Timestamp = msg.Timestamp
                };
                // Publish the message as a notification so MediatR handlers (like MessageHandler) can process it
                await _mediator.Publish(new InformationReceivedNotification(model));
            }
        }
    }

}
