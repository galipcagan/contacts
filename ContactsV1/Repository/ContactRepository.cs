using System;
using Web.Shared.Entities;
using Web.Shared.Interfaces;
using Contacts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Contacts.Infrastructure.Repository
{
	public class ContactRepository: IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> AddAsync(Contact contact)
        {
            await _context.Addresses.AddAsync(contact.Address);
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task DeleteAsync(string id)
        {
            var existingContact = await _context.Contacts
                                    .FirstOrDefaultAsync(c => c.ContactId == id);

            await _context.Addresses
                    .Where(x => x.AddressId == existingContact.AddressId)
                    .ExecuteDeleteAsync();

            await _context.Contacts
                    .Where(x => x.ContactId == id)
                    .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact contact)
        {
            var existingContact = await _context.Contacts
                                                .Include(c => c.Address)
                                                .FirstOrDefaultAsync(c => c.ContactId == contact.ContactId);

            existingContact.UserName = contact.UserName;
            existingContact.Email = contact.Email;
            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.MiddleInitial = contact.MiddleInitial;
            existingContact.Age = contact.Age;
            existingContact.PhoneNumber = contact.PhoneNumber;

            existingContact.Address.Street = contact.Address.Street;
            existingContact.Address.City = contact.Address.City;
            existingContact.Address.State = contact.Address.State;
            existingContact.Address.ZipCode = contact.Address.ZipCode;
            existingContact.Address.Country = contact.Address.Country;

            await _context.SaveChangesAsync();
        }

        public async Task<Contact?> GetByIdAsync(string id)
        {
            return await _context.Contacts
                .Include(c => c.Address)
                .FirstOrDefaultAsync(x => x.ContactId == id);
        }

        public async Task<IEnumerable<Contact?>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

    }
}

