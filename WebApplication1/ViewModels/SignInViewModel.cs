using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels {
    public class SignInViewModel {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4), MaxLength(16)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
