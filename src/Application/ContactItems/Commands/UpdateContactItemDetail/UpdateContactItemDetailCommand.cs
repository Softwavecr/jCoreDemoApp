using jCoreDemoApp.Application.Common.Exceptions;
using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Domain.Entities;
using jCoreDemoApp.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactItems.Commands.UpdateContactItemDetail
{
    public class UpdateContactItemDetailCommand : IRequest
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public PriorityLevel Priority { get; set; }

        public string Note { get; set; }
    }

    public class UpdateContactItemDetailCommandHandler : IRequestHandler<UpdateContactItemDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateContactItemDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateContactItemDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContactItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ContactItem), request.Id);
            }

            entity.ListId = request.ListId;
            entity.Priority = request.Priority;
            //entity.Note = request.Note;//JAIRO CHECK

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
