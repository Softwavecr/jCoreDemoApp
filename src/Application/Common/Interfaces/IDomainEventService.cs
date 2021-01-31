using jCoreDemoApp.Domain.Common;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
