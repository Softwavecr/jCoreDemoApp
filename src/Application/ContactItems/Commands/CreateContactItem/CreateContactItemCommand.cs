using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Domain.Entities;
using jCoreDemoApp.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactItems.Commands.CreateContactItem
{
    public class CreateContactItemCommand : IRequest<int>
    {
        public int ListId { get; set; }

        public string Name { get; set; }
    }

    public class CreateContactItemCommandHandler : IRequestHandler<CreateContactItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateContactItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateContactItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new ContactItem
            {
                ListId = request.ListId,
                Name = request.Name,
                Done = false
            };

            entity.DomainEvents.Add(new ContactItemCreatedEvent(entity));

            _context.ContactItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
