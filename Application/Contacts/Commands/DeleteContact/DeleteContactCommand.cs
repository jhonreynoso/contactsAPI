using MediatR;
using Application.Common.Interfaces;
namespace Application.Contacts.Commands.DeleteContact;

public class DeleteContactCommand : IRequest<Unit>
{
    public int? Id { get; set; }

    public DeleteContactCommand(int? id)
    {
        Id = id;
    }
    public record DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {

        private readonly IContactsService _contactsService;
        public DeleteContactCommandHandler(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            await _contactsService.DeleteContact(request.Id);
            return Unit.Value;
        }
    }
}
