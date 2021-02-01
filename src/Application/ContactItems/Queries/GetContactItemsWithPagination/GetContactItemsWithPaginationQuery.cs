using AutoMapper;
using AutoMapper.QueryableExtensions;
using jCoreDemoApp.Application.Common.Interfaces;
using jCoreDemoApp.Application.Common.Mappings;
using jCoreDemoApp.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactItems.Queries.GetContactItemsWithPagination
{
    public class GetContactItemsWithPaginationQuery : IRequest<PaginatedList<ContactItemDto>>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetContactItemsWithPaginationQueryHandler : IRequestHandler<GetContactItemsWithPaginationQuery, PaginatedList<ContactItemDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetContactItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ContactItemDto>> Handle(GetContactItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.ContactItems
                .Where(x => x.Id > 0)
                .OrderBy(x => x.Name)
                .ProjectTo<ContactItemDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            // return await _context.ContactItems
            //     .Where(x => x.Id == request.Id)
            //     .OrderBy(x => x.Name)
            //     .ProjectTo<ContactItemDto>(_mapper.ConfigurationProvider)
            //     .PaginatedListAsync(request.PageNumber, request.PageSize);                
        }
    }
}
