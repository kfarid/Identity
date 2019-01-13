using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels {
    public class SignUpViewModel {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4), MaxLength(16), DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password"), DataType(DataType.Password)]
        public string Password2 { get; set; }
    }
}
