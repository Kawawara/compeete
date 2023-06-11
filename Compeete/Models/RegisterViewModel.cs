using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Compeete.Models
{
    public class RegisterViewModel
    {
        [DisplayName("Email")] 
        public string Email { get; set; }
        [DisplayName("Nom")] 
        public string UserName { get; set; }
        [DisplayName("Date de naissance")] 
        public DateTime Birthdate { get; set; }
        [DisplayName("Genre")] 
        public string? Sex { get; set; }

        [DisplayName("Mot de passe")] 
        public string Password { get; set; }
        [DisplayName("Confirmation Mot de passe")]
        [Compare("Password", ErrorMessage = "Les mots de passe rensignés ne sont pas identiques")]
        public string ConfirmPassword { get; set; }
    }
}
