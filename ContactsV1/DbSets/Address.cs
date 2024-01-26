using System;
namespace Contacts.Infrastructure.DbSets
{
	public class Address
	{
        public Guid AddressId { get; set; }
        public required string Street { get; set; }
		public required string City { get; set; }
		public required string State { get; set; }
		public int ZipCode { get; set; }
		public required string Country { get; set; }
	}
}

