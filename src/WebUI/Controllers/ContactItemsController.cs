using jCoreDemoApp.Application.Common.Models;
using jCoreDemoApp.Application.ContactItems.Commands.CreateContactItem;
using jCoreDemoApp.Application.ContactItems.Commands.DeleteContactItem;
using jCoreDemoApp.Application.ContactItems.Commands.UpdateContactItem;
using jCoreDemoApp.Application.ContactItems.Commands.UpdateContactItemDetail;
using jCoreDemoApp.Application.ContactItems.Queries.GetContactItemsWithPagination;
using jCoreDemoApp.Application.ContactLists.Queries.GetContacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace jCoreDemoApp.WebUI.Controllers
{
    [Authorize]
    public class ContactItemsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ContactItemDto>>> GetContactItemsWithPagination([FromQuery] GetContactItemsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateContactItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateContactItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdateContactItemDetailCommand command)
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
            await Mediator.Send(new DeleteContactItemCommand { Id = id });

            return NoContent();
        }
    }
}
