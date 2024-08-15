
using MediatR;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Contacts.Commands.UpdateContact;
public record UpdateContactCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
}
public record UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Unit>
{

    private readonly IContactsService _contactsService;
    public UpdateContactCommandHandler(IContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            Id = request.Id,
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
        };

        await _contactsService.UpdateContact(contact);
        return Unit.Value;
    }
}
