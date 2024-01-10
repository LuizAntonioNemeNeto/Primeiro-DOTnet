using Sisteminha.Enums;

namespace Sisteminha.Models
{
    public class ConsultaModel
    {
        public int Id { get; set; }
        public DateTime Marcacao { get; set; }
        public RetornoEnum Retorno { get; set; }

        public int? MedicoId { get; set; }
        public int? PacienteId { get; set; }

        public MedicoModel? Medico { get; set; }
        public PacienteModel? Paciente { get; set; }
        
    }
}
