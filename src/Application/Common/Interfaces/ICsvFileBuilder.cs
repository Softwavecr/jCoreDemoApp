using jCoreDemoApp.Application.TodoLists.Queries.ExportTodos;
using jCoreDemoApp.Application.ContactLists.Queries.ExportContacts;
using System.Collections.Generic;

namespace jCoreDemoApp.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);

        byte[] BuildContactItemsFile(IEnumerable<ContactItemRecord> records);
    }
}
