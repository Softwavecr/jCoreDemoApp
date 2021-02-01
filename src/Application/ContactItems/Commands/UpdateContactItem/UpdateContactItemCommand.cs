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
        public string Company { get; set; }
        public byte[] ProfileImage { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumberWork { get; set; }
        public string PhoneNumberPersonal { get; set; }
        public string Address { get; set; }
        public bool Deleted { get; set; }
        public int Priority { get; set; }
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
            entity.Company = request.Company;
            entity.ProfileImage = request.ProfileImage;
            entity.Email = request.Email;
            entity.BirthDate = request.BirthDate;
            entity.PhoneNumberWork = request.PhoneNumberWork;
            entity.PhoneNumberPersonal = request.PhoneNumberPersonal;
            entity.Address = request.Address;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
