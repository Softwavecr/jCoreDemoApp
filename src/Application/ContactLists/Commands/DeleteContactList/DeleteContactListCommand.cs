using jCoreDemoApp.Application.Common.Exceptions;
using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactLists.Commands.DeleteContactList
{
    public class DeleteContactListCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteContactListCommandHandler : IRequestHandler<DeleteContactListCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteContactListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteContactListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContactLists
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ContactList), request.Id);
            }

            _context.ContactLists.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
