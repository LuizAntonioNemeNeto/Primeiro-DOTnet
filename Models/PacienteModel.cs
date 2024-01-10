using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Sisteminha.Models
{
    public class PacienteModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Paciente")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a Data de Nascimento do Paciente")]
        public DateOnly? DataNasc { get; set; }
        [Required(ErrorMessage = "Digite o Email do Médico")]
        [EmailAddress(ErrorMessage = "O Email Informado não é Válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do Médico")]
        [Phone(ErrorMessage = "O Número Informado não é Válido")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Digite o Problema do Paciente")]
        public string Problema { get; set; }

        public virtual List<ConsultaModel>? Consultas { get; set; }
    }
}
