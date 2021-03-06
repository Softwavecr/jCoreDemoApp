﻿using jCoreDemoApp.Application.Common.Exceptions;
using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Domain.Entities;
using jCoreDemoApp.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.Contacts.Commands.UpdateContactDetail
{
    public class UpdateContactDetailCommand : IRequest
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
        public string Deleted { get; set; }
        public int Priority { get; set; }        
    }

    public class UpdateContactDetailCommandHandler : IRequestHandler<UpdateContactDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateContactDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateContactDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contacts.FindAsync(request.Id);

            if (entity == null)
            { 
                throw new NotFoundException(nameof(Contact), request.Id);
            }

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.Company = request.Company;
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
