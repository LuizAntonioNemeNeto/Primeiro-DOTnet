using System.ComponentModel.DataAnnotations;

namespace Sisteminha.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }
    }
}
