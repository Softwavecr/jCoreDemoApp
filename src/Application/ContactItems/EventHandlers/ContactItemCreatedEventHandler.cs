using jCoreDemoApp.Application.Common.Models;
using jCoreDemoApp.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.Contacts.EventHandlers
{
    public class ContactCreatedEventHandler : INotificationHandler<DomainEventNotification<ContactCreatedEvent>>
    {
        private readonly ILogger<ContactCompletedEventHandler> _logger;

        public ContactCreatedEventHandler(ILogger<ContactCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<ContactCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("jCoreDemoApp Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
