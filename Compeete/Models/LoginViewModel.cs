using System.ComponentModel;

namespace Compeete.Models
{
    public class LoginViewModel
    {
        [DisplayName("Email")] 
        public string Email { get; set; }
        [DisplayName("Password")] 
        public string Password { get; set; }
    }
}
