using System;
using Web.Shared.Entities;

namespace Web.Shared.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> AddAsync(Contact contact);
        Task DeleteAsync(string id);
        Task UpdateAsync(Contact contact);
        Task<Contact?> GetByIdAsync(string id);
        Task<IEnumerable<Contact?>> GetAllAsync();
    }
}

