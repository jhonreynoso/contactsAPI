using MediatR;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Contacts.Commands.CreateContact;

public record CreateContactCommand : IRequest<int>
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
}
public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
{
    private readonly IContactsService _contactsService;

    public CreateContactCommandHandler(IContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
        };
        return await _contactsService.CreateContact(contact);
    }
}


