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
                Id = request.Id,                
                Name = request.Name,
                Company = request.Company,
                Email = request.Email,
                BirthDate = request.BirthDate,
                PhoneNumberPersonal = request.PhoneNumberPersonal,
                PhoneNumberWork = request.PhoneNumberWork,
                Address = request.Address,
                Priority =  jCoreDemoApp.Domain.Enums.PriorityLevel.High,
                Deleted = false
            };

            entity.DomainEvents.Add(new ContactItemCreatedEvent(entity));

            _context.ContactItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
