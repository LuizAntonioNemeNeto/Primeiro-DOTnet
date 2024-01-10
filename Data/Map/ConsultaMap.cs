using Sisteminha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sisteminha.Data.Map
{
    public class ConsultaMap : IEntityTypeConfiguration<ConsultaModel>
    {
        public void Configure(EntityTypeBuilder<ConsultaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Medico);
            builder.HasOne(x => x.Paciente);
        }
    }
}
