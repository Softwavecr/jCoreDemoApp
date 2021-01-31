using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Application.Common.Security;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactLists.Commands.PurgeContactLists
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "CanPurge")]
    public class PurgeContactListsCommand : IRequest
    {
    }

    public class PurgeContactListsCommandHandler : IRequestHandler<PurgeContactListsCommand>
    {
        private readonly IApplicationDbContext _context;

        public PurgeContactListsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PurgeContactListsCommand request, CancellationToken cancellationToken)
        {
            _context.ContactLists.RemoveRange(_context.ContactLists);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
