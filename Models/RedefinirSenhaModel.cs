using System.ComponentModel.DataAnnotations;

namespace Sisteminha.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }
    }
}
