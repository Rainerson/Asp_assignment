using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Views.Models.Entities
{
    public class ProfileEntity
    {
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Mobile { get; set; }
        public string? Company { get; set; }
        public string? Image { get; set; }
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public UserEntity User { get; set; } = null!;

    }
}
