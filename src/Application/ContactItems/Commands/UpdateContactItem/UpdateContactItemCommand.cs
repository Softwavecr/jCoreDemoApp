using jCoreDemoApp.Application.Common.Exceptions;
using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactItems.Commands.UpdateContactItem
{
    public class UpdateContactItemCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Done { get; set; }
    }

    public class UpdateContactItemCommandHandler : IRequestHandler<UpdateContactItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateContactItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateContactItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContactItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ContactItem), request.Id);
            }

            entity.Name = request.Name;
            entity.Done = request.Done;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
