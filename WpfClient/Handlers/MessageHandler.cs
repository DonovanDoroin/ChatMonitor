using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfClient.Messages;
using WpfClient.ViewModels;

namespace WpfClient.Handlers
{
    public class MessageHandler : INotificationHandler<InformationReceivedNotification>
    {
        private readonly MainViewModel _viewModel;

        // The handler is injected with the ViewModel via constructor injection
        public MessageHandler(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        // Triggered whenever an InformationReceivedNotification is published
        public Task Handle(InformationReceivedNotification notification, CancellationToken cancellationToken)
        {
            // Check if the message text contains the word "test" (case-insensitive) and add it to the observable collection for UI displaying
            if (notification.Message.Text.Contains("test", StringComparison.OrdinalIgnoreCase))
            {
                _viewModel.Messages.Add(notification.Message);
            }

            // Task.CompletedTask indicates that the handler has finished processing
            return Task.CompletedTask;
        }
    }

}
