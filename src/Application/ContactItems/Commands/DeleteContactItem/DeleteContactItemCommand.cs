using jCoreDemoApp.Application.Common.Exceptions;
using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactItems.Commands.DeleteContactItem
{
    public class DeleteContactItemCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteContactItemCommandHandler : IRequestHandler<DeleteContactItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteContactItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteContactItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContactItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ContactItem), request.Id);
            }

            _context.ContactItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
