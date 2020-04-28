using System.ComponentModel.DataAnnotations;

namespace BerrasBiograf
{
    public class UserLoginModel
    {
        [Display(Name="E-Mail")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
