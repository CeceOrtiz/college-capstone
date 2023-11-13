using System.ComponentModel.DataAnnotations;

namespace D424.Models
{
    public class LoginModel
#nullable disable
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
