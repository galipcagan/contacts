using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Infrastructure.DbSets
{
	public class Contact
	{
		public Guid ContactId { get; set; }
		public required string UserName { get; set; }
		public required string FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public Guid AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public required virtual Address Address { get; set; }
    }
}