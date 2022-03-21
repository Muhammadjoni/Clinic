using Microsoft.AspNetCore.Identity;

namespace Clinic.Models
{
    // [Index(nameof(email), IsUnique = true)]
    public class User : IdentityUser

    {
        public int id { get; set; }
        public string Username { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
    }
}
