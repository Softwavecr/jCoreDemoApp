using AutoMapper;
using AutoMapper.QueryableExtensions;
using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Application.Common.Mappings;
using jCoreDemoApp.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.Contacts.Queries.GetContactsWithPagination
{
    public class GetContactsWithPaginationQuery : IRequest<PaginatedList<ContactPaginatedDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class GetContactsWithPaginationQueryHandler : IRequestHandler<GetContactsWithPaginationQuery, PaginatedList<ContactPaginatedDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetContactsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ContactPaginatedDto>> Handle(GetContactsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Contacts
                
                .OrderBy(x => x.Id)
                .ProjectTo<ContactPaginatedDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
