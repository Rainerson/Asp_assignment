using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Views.Models.Entities;

namespace Views.Models.Identity
{
    public class ProfileData
    {
        [Key, ForeignKey("User")]
        public string IdentityUser { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Company { get; set; }

        public string? ImageFile { get; set; }

        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public AppUser User { get; set; } = null!;
    }
}
