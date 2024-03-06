using System.ComponentModel.DataAnnotations;

namespace System.DataTransferObject

{
    public class RegisterDTO
    { 
    [Required]
        public string UserName { get; set; }
        [Required]

        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
        // [Compare("Email")]

        //public string EmailConfirmed { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        [Compare("Password")]

        public string PasswordConfirmed { get; set; }

    }
}
