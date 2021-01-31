using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactLists.Commands.CreateContactList
{
    public class CreateContactListCommand : IRequest<int>
    {
        public string Title { get; set; }
    }

    public class CreateContactListCommandHandler : IRequestHandler<CreateContactListCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateContactListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateContactListCommand request, CancellationToken cancellationToken)
        {
            var entity = new ContactList();

            entity.Title = request.Title;

            _context.ContactLists.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
