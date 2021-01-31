using jCoreDemoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<ContactList> ContactLists { get; set; }

        DbSet<ContactItem> ContactItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
