using Microsoft.EntityFrameworkCore;
using Sisteminha.Data.Map;
using Sisteminha.Models;

namespace Sisteminha.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        }
        public DbSet<MedicoModel> Medicos { get; set; }
        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<ConsultaModel> Consultas { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConsultaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
