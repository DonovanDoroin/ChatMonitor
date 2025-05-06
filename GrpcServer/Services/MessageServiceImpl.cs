using Grpc.Core;

namespace GrpcServer.Services
{
    public class MessageServiceImpl : MessageService.MessageServiceBase
    {
        public override async Task StreamMessages(Empty request, IServerStreamWriter<InformationMessage> responseStream, ServerCallContext context)
        {
            // A set of randomized predefined message texts to simulate message content
            var rnd = new Random();
            var samples = new[] {
                "hello",
                "this is a test",
                "ignore this",
                "unit test passed",
                "test complete"
            };

            // Will keep sending the randomized messages until the client disconnects or cancels the request
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var msg = new InformationMessage
                {
                    Id = Guid.NewGuid().ToString(),        // Generate a unique ID for the message
                    From = "Server",                       // For simulating a sender
                    To = "Client",                         // For simulating a recipient
                    Text = samples[rnd.Next(samples.Length)], // Randomly choose a message text
                    Timestamp = DateTime.Now.ToString()    // Current timestamp as string
                };

                // Send the message to the client every 1 second
                await responseStream.WriteAsync(msg);
                await Task.Delay(1000);
            }
        }
    }

}
