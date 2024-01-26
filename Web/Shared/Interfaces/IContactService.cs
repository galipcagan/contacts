using System;
using Web.Shared.Entities;

namespace Web.Shared.Interfaces
{
    public interface IContactService
    {
        public Task<Contact> CreateContactAsync(Contact contact);

        public Task UpdateContactAsync(Contact contact);

        public Task DeleteContactAsync(string id);

        public Task<Contact?> GetContactByIdAsync(string id);

        public Task<IEnumerable<Contact?>> GetAllContactsAsync();
    }
}

