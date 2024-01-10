using Sisteminha.Data;
using Sisteminha.Models;

namespace Sisteminha.Repositorys
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly BancoContext _bancoContext;
        public PacienteRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public PacienteModel Adicionar(PacienteModel paciente)
        {
            _bancoContext.Pacientes.Add(paciente);
            _bancoContext.SaveChanges();
            return paciente;
        }

        public PacienteModel Atualizar(PacienteModel paciente)
        {
            PacienteModel pacienteDB = ListarPorId(paciente.Id);
            if (pacienteDB == null)
            {
                throw new System.Exception("Erro na Atualização do Paciente");
            }

            pacienteDB.Nome = paciente.Nome;
            pacienteDB.DataNasc = paciente.DataNasc;
            pacienteDB.Problema = paciente.Problema;
            pacienteDB.Email = paciente.Email;
            pacienteDB.Celular = paciente.Celular;

            _bancoContext.Pacientes.Update(pacienteDB);
            _bancoContext.SaveChanges();

            return pacienteDB;
        }

        public List<PacienteModel> BuscarTodos()
        {
            return _bancoContext.Pacientes.ToList();
        }

        public bool Excluir(int id)
        {
            PacienteModel pacienteDB = ListarPorId(id);
            if (pacienteDB == null)
            {
                throw new System.Exception("Erro na Exclusão do Paciente");
            }

            _bancoContext.Pacientes.Remove(pacienteDB);
            _bancoContext.SaveChanges();
            return true;

        }

        public PacienteModel ListarPorId(int id)
        {
            return _bancoContext.Pacientes.FirstOrDefault(x => x.Id == id);
        }
    }
}
