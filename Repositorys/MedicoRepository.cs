using Sisteminha.Data;
using Sisteminha.Models;

namespace Sisteminha.Repositorys
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly BancoContext _bancoContext;
        public MedicoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public MedicoModel Adicionar(MedicoModel medico)
        {
            _bancoContext.Medicos.Add(medico);
            _bancoContext.SaveChanges();
            return medico;
        }

        public MedicoModel Atualizar(MedicoModel medico)
        {
            MedicoModel medicoDB = ListarPorId(medico.Id);
            if (medicoDB == null)
            {
                throw new System.Exception("Erro na Atualização do Contato");
            }

            medicoDB.Nome = medico.Nome;
            medicoDB.Especialidade = medico.Especialidade;
            medicoDB.Email = medico.Email;
            medicoDB.Celular = medico.Celular;

            _bancoContext.Medicos.Update(medicoDB);
            _bancoContext.SaveChanges();

            return medicoDB;
        }

        public List<MedicoModel> BuscarTodos()
        {
            return _bancoContext.Medicos.ToList();
        }

        public bool Excluir(int id)
        {
            MedicoModel medicoDB = ListarPorId(id);
            if (medicoDB == null)
            {
                throw new System.Exception("Erro na Exclusão do Contato");
            }

            _bancoContext.Medicos.Remove(medicoDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public MedicoModel ListarPorId(int id)
        {
            return _bancoContext.Medicos.FirstOrDefault(x => x.Id == id);
        }
    }
}
