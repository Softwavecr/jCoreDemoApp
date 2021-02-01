using jCoreDemoApp.Application.Common.Models;
using jCoreDemoApp.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.Contacts.EventHandlers
{
    public class ContactCompletedEventHandler : INotificationHandler<DomainEventNotification<ContactDeletedEvent>>
    {
        private readonly ILogger<ContactCompletedEventHandler> _logger;

        public ContactCompletedEventHandler(ILogger<ContactCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<ContactDeletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("jCoreDemoApp Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
