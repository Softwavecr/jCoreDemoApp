using AutoMapper;
using AutoMapper.QueryableExtensions;
using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Application.Common.Mappings;
using jCoreDemoApp.Application.Common.Models;
//using jCoreDemoApp.Application.ContactItem.Queries.GetContacts;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;


namespace jCoreDemoApp.Application.ContactItems.Queries.GetContactItems
{
    public class GetContactItemsQuery : IRequest<IEnumerable<ContactItemDto>>
    {    }

    public class GetContactItemsQueryHandler : IRequestHandler<GetContactItemsQuery, IEnumerable<ContactItemDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetContactItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IEnumerable<ContactItemDto>> Handle(GetContactItemsQuery request, CancellationToken cancellationToken)
        {
            var r = _context.ContactItems.ProjectTo<ContactItemDto>(_mapper.ConfigurationProvider);
            //return Task.FromResult(r);
            return (Task<IEnumerable<ContactItemDto>>) r;

            // var rr = await _context.ContactItems
            //     .Where(x => x.Id > 0)
            //     .OrderBy(x => x.Name)
            //     .ProjectTo<ContactItemDto>(_mapper.ConfigurationProvider)
            //     .PaginatedListAsync(request.PageNumber, request.PageSize);

        }


    }
}
