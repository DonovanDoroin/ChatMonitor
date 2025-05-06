using MediatR;
using WpfClient.Models;

namespace WpfClient.Messages
{
    public record InformationReceivedNotification(InformationMessageModel Message) : INotification;
}