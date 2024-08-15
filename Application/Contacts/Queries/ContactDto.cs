using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Queries;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}

public class ContactDto : IMapFrom<Contact>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateEdit { get; set; }
}

