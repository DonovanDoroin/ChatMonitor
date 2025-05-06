using Moq;
using Xunit;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using WpfClient.Models;
using WpfClient.Messages;
using WpfClient.ViewModels;
using WpfClient.Handlers;
using WpfClient.Services;

namespace UnitTests
{
    public class MessageHandlerTests
    {
        [Fact]
        public async Task Handler_Should_Add_Message_If_Contains_Test()
        {
            // Arrange
            var mockListener = new Mock<IGrpcListener>();
            var viewModel = new MainViewModel(mockListener.Object);
            var handler = new MessageHandler(viewModel);

            var message = new InformationMessageModel
            {
                Text = "this is a test message"
            };

            // Act
            await handler.Handle(new InformationReceivedNotification(message), CancellationToken.None);

            // Assert
            viewModel.Messages.Should().ContainSingle(m => m.Text.Contains("test"));
        }

        [Fact]
        public async Task Handler_Should_Not_Add_Message_If_It_Does_Not_Contain_Test()
        {
            // Arrange
            var mockListener = new Mock<IGrpcListener>();
            var viewModel = new MainViewModel(mockListener.Object);
            var handler = new MessageHandler(viewModel);

            var message = new InformationMessageModel
            {
                Text = "this message should be filtered"
            };

            // Act
            await handler.Handle(new InformationReceivedNotification(message), CancellationToken.None);

            // Assert
            viewModel.Messages.Should().BeEmpty("because the message did not contain the word 'test'");
        }
    }
}
