using AutoMapper;
using AutoMapper.QueryableExtensions;
using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Application.Common.Mappings;
using jCoreDemoApp.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;


namespace jCoreDemoApp.Application.Contacts.Queries.GetContacts
{
    public class GetContactsQuery : IRequest<IEnumerable<ContactDto>>
    {    }

    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, IEnumerable<ContactDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetContactsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Contacts
                .Where(x => x.Id > 0)
                .OrderBy(x => x.Name)
                //.ProjectTo<ContactDto>(_mapper.ConfigurationProvider)
                .ProjectToListAsync<ContactDto>(_mapper.ConfigurationProvider);


        }


    }
}
