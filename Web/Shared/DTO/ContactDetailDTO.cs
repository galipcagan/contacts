using System;
namespace Web.Shared.DTO
{
	public class ContactDetailDTO
	{
        public required string ContactId { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public required string AddressId { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public int ZipCode { get; set; }
        public required string Country { get; set; }
    }
}

