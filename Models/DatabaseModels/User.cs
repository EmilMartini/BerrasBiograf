using Microsoft.AspNetCore.Identity;

namespace BerrasBiograf
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
