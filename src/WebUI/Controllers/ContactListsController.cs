using jCoreDemoApp.Application.ContactLists.Commands.CreateContactList;
using jCoreDemoApp.Application.ContactLists.Commands.DeleteContactList;
using jCoreDemoApp.Application.ContactLists.Commands.UpdateContactList;
using jCoreDemoApp.Application.ContactLists.Queries.ExportContacts;
using jCoreDemoApp.Application.ContactLists.Queries.GetContacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace jCoreDemoApp.WebUI.Controllers
{
    [Authorize]
    public class ContactListsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ContactsVm>> Get()
        {
            return await Mediator.Send(new GetContactsQuery());
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportContactsQuery { Id = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateContactListCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateContactListCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteContactListCommand { Id = id });

            return NoContent();
        }
    }
}
