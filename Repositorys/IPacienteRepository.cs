using Sisteminha.Models;

namespace Sisteminha.Repositorys
{
    public interface IPacienteRepository
    {
        PacienteModel ListarPorId(int id);
        List<PacienteModel> BuscarTodos();
        PacienteModel Adicionar(PacienteModel paciente);
        PacienteModel Atualizar(PacienteModel paciente);
        bool Excluir(int id);
    }
}
