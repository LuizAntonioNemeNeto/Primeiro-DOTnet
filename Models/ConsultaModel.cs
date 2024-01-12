using Sisteminha.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sisteminha.Models
{
    public class ConsultaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a Data e Hora da Consulta")]
        public DateTime Marcacao { get; set; }
        [Required(ErrorMessage = "Informe se Haverá Retorno")]
        public RetornoEnum Retorno { get; set; }
        [Required(ErrorMessage = "Informe o Médico")]
        public int? MedicoId { get; set; }
        [Required(ErrorMessage = "Informe o Paciente")]
        public int? PacienteId { get; set; }

        public MedicoModel? Medico { get; set; }
        public PacienteModel? Paciente { get; set; }
        
    }
}
