using jCoreDemoApp.Application.Common.Exceptions;
using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactLists.Commands.UpdateContactList
{
    public class UpdateContactListCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }

    public class UpdateContactListCommandHandler : IRequestHandler<UpdateContactListCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateContactListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateContactListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContactLists.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ContactList), request.Id);
            }

            entity.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
