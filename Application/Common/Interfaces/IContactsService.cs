using Application.Contacts.Queries;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IContactsService
    {
        public Task<ContactDto> GetContact(int? id);
        public Task<List<ContactDto>> GetAllContacts();
        public Task<int> CreateContact(Contact contact);
        public Task UpdateContact(Contact contact);
        public Task DeleteContact(int? id);
    }
}

