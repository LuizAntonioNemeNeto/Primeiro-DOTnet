using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sisteminha.Data;
using Sisteminha.Models;

namespace Sisteminha.Repositorys
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly BancoContext _bancoContext;
        public ConsultaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ConsultaModel Adicionar(ConsultaModel consulta)
        {
            _bancoContext.Consultas.Add(consulta);
            _bancoContext.SaveChanges();
            return consulta;
        }

        public ConsultaModel Atualizar(ConsultaModel consulta)
        {
            ConsultaModel consultaDB = ListarPorId(consulta.Id);
            
            if (consultaDB == null)
            {
                throw new System.Exception("Erro na Atualização da Consulta");
            }

            consultaDB.Marcacao = consulta.Marcacao;
            consultaDB.Retorno = consulta.Retorno;
            consultaDB.MedicoId = consulta.MedicoId;
            consultaDB.PacienteId = consulta.PacienteId;


            _bancoContext.Consultas.Update(consultaDB);
            _bancoContext.SaveChanges();

            return consultaDB;
        }

        public List<ConsultaModel> BuscarTodos()
        {
            return _bancoContext.Consultas.Include(x => x.Medico).Include(x => x.Paciente).ToList();
        }

        public List<ConsultaModel> BuscarTodosMedicos(int medicoId)
        {
            return _bancoContext.Consultas.Where(x => x.MedicoId == medicoId).Include(x => x.Paciente).ToList();
        }

        public List<ConsultaModel> BuscarTodosPacientes(int pacienteId)
        {
            return _bancoContext.Consultas.Where(x => x.PacienteId == pacienteId).Include(x => x.Medico).ToList();
        }

        public bool Excluir(int id)
        {
            ConsultaModel consultaDB = ListarPorId(id);
            if (consultaDB == null)
            {
                throw new System.Exception("Erro na Exclusão da Consulta");
            }

            _bancoContext.Consultas.Remove(consultaDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public ConsultaModel ListarPorId(int id)
        {
            //return _bancoContext.Consultas.Where(x => x.Id == id).Include(x => x.Medico).Include(x => x.Paciente).FirstOrDefault();
            return _bancoContext.Consultas.FirstOrDefault(x => x.Id == id);
        }
    }
}
