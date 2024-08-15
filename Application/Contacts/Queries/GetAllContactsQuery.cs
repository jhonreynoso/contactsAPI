using System;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Contacts.Queries;

public record GetAllContactsQuery : IRequest<List<ContactDto>>
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
}

public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<ContactDto>>
{
    private readonly IContactsService _contactsService;

    public GetAllContactsQueryHandler(IContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    public async Task<List<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        return await _contactsService.GetAllContacts();
    }
}

