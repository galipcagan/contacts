using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Shared.ValueObjects;

namespace Web.Shared.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public required string ContactId { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public required string AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public required virtual Address Address { get; set; }
    }
}

