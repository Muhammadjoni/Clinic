using Microsoft.AspNetCore.Identity;

namespace Clinic.Models
{
    public class User : IdentityUser

    {
        public int id { get; set; }
        public string Username { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
    }
}
