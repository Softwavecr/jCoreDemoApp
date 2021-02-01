using jCoreDemoApp.Application.Common.Models;
using jCoreDemoApp.Application.Contacts.Commands.CreateContact;
using jCoreDemoApp.Application.Contacts.Commands.DeleteContact;
using jCoreDemoApp.Application.Contacts.Commands.UpdateContact;
using jCoreDemoApp.Application.Contacts.Commands.UpdateContactDetail;
using jCoreDemoApp.Application.Contacts.Queries.GetContactsWithPagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
namespace jCoreDemoApp.WebUI.Controllers
{
    //[Authorize]
    public class ContactsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ContactPaginatedDto>>> GetContactsWithPagination([FromQuery] GetContactsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateContactCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateContactCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdateContactDetailCommand command)
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
            await Mediator.Send(new DeleteContactCommand { Id = id });

            return NoContent();
        }
    }
}
