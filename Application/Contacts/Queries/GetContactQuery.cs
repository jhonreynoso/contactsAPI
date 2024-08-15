using Application.Common.Interfaces;
using MediatR;

namespace Application.Contacts.Queries;

public record GetContactQuery : IRequest<ContactDto>
{
    public int? id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
}

public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactDto>
{
    private readonly IContactsService _contactsService;

    public GetContactQueryHandler(IContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    public async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        return await _contactsService.GetContact(request.id);
    }
}

