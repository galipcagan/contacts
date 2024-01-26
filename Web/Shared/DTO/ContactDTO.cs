using System;
namespace Web.Shared.DTO
{
	public class ContactDTO
	{
        public required string ContactId { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
    }
}

