using jCoreDemoApp.Application.Common.Models;
using jCoreDemoApp.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactItems.EventHandlers
{
    public class ContactItemCompletedEventHandler : INotificationHandler<DomainEventNotification<ContactItemDeletedEvent>>
    {
        private readonly ILogger<ContactItemCompletedEventHandler> _logger;

        public ContactItemCompletedEventHandler(ILogger<ContactItemCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<ContactItemDeletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("jCoreDemoApp Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
