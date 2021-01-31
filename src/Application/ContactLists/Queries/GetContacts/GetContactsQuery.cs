using AutoMapper;
using AutoMapper.QueryableExtensions;
using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Application.Common.Security;
using jCoreDemoApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactLists.Queries.GetContacts
{
    public class GetContactsQuery : IRequest<ContactsVm>
    {
    }

    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, ContactsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetContactsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContactsVm> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            return new ContactsVm
            {
                PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                    .Cast<PriorityLevel>()
                    .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                    .ToList(),

                Lists = await _context.ContactLists
                    .AsNoTracking()
                    .ProjectTo<ContactListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
