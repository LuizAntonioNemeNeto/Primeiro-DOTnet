using System.ComponentModel.DataAnnotations;

namespace Sisteminha.Models
{
    public class MedicoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Médico")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a Especialidade do Médico")]
        public string Especialidade { get; set;}
        [Required(ErrorMessage = "Digite o Email do Médico")]
        [EmailAddress(ErrorMessage = "O Email Informado não é Válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do Médico")]
        [Phone(ErrorMessage = "O Número Informado não é Válido")]
        public string Celular { get; set; }

        public virtual List<ConsultaModel>? Consultas { get; set; }
    }
}
