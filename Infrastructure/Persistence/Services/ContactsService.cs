using Application.Common.Interfaces;
using Application.Contacts.Queries;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IApplicationDbContext _context;

        public ContactsService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContactDto>> GetAllContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();

            var contactDtos = contacts.Select(contact => new ContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber,
                DateCreated = contact.DateCreated,
                DateEdit = contact.DateEdit
            }).ToList();

            return contactDtos;
        }
        public async Task<ContactDto> GetContact(int? id)
        {
            var contact = await _context.Contacts.Where(x => x.Id == id).FirstOrDefaultAsync();

            var contactDto = new ContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber,
                DateCreated = contact.DateCreated,
                DateEdit = contact.DateEdit
            };

            return contactDto;
        }

        public async Task<int> CreateContact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contact.Id;
        }

        public async Task UpdateContact(Contact contact)
        {
            var entity = await _context.Contacts.Where(x => x.Id == contact.Id).FirstOrDefaultAsync();
            if (entity is null)
            {
                throw new Exception(nameof(Contact));
            }
            entity.Name = contact.Name;
            entity.PhoneNumber = contact.PhoneNumber;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteContact(int? id)
        {
            var entity = await _context.Contacts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
            {
                throw new Exception(nameof(Contact));

            }
            _context.Contacts.Remove(entity);
            await _context.SaveChangesAsync();

        }

    }
}

