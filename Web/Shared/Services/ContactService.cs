using System;
using Web.Shared.Entities;
using Web.Shared.Interfaces;

namespace Web.Shared.Services
{

        public class ContactService : IContactService
        {
            private readonly IContactRepository _contactRepository;

            public ContactService(IContactRepository contactRepository)
            {
                _contactRepository = contactRepository;
            }
            public async Task<Contact> CreateContactAsync(Contact contact)
            {
                return await _contactRepository.AddAsync(contact);
            }

            public async Task UpdateContactAsync(Contact contact)
            {
                await _contactRepository.UpdateAsync(contact);
            }

            public async Task DeleteContactAsync(string id)
            {
                await _contactRepository.DeleteAsync(id);
            }

            public async Task<Contact?> GetContactByIdAsync(string id)
            {
                return await _contactRepository.GetByIdAsync(id);
            }

            public async Task<IEnumerable<Contact?>> GetAllContactsAsync()
            {
                return await _contactRepository.GetAllAsync();
            }
        }
    
}

