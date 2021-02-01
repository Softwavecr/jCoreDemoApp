using AutoMapper;
using AutoMapper.QueryableExtensions;
using jCoreDemoApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactLists.Queries.ExportContacts
{
    public class ExportContactsQuery : IRequest<ExportContactsVm>
    {
        public int Id { get; set; }
    }

    public class ExportContactsQueryHandler : IRequestHandler<ExportContactsQuery, ExportContactsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportContactsQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportContactsVm> Handle(ExportContactsQuery request, CancellationToken cancellationToken)
        {
            var vm = new ExportContactsVm();

            var records = await _context.ContactItems
                    .Where(t => t.Id == request.Id)
                    .ProjectTo<ContactItemRecord>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            vm.Content = _fileBuilder.BuildContactItemsFile(records);
            vm.ContentType = "text/csv";
            vm.FileName = "ContactItems.csv";

            return await Task.FromResult(vm);
        }
    }
}
