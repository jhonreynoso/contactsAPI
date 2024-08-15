
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using MediatR;
using Application.Contacts.Commands.CreateContact;
using Application.Contacts.Commands.UpdateContact;
using Application.Contacts.Commands.DeleteContact;
using Application.Contacts.Queries;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[OpenApiTag(name: "Contacts", Description = "showing how cool is swagger.. with contacts sample")]
public class ContactsController : Controller
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ContactDto>>> GetAllContacts()
    {
        var query = new GetAllContactsQuery();
        var contacts = await _mediator.Send(query);

        if (contacts == null || !contacts.Any())
        {
            return NotFound();
        }

        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContactDto>> GetContact(int id)
    {
        var query = new GetContactQuery { id = id };
        var contactDto = await _mediator.Send(query);
        if (contactDto == null)
        {
            return NotFound();
        }
        return Ok(contactDto);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateContactCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateContactCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        var command = new DeleteContactCommand(id);
        await _mediator.Send(command);
        return Ok();
    }

}

