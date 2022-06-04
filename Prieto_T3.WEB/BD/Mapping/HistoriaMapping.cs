using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prieto_T3.WEB.Models;

namespace Prieto_T3.WEB.BD.Mapping
{
    public class HistoriaMapping : IEntityTypeConfiguration<HistoriaClinica>
    {
        public void Configure(EntityTypeBuilder<HistoriaClinica> builder)
        {
            builder.ToTable("HistoriaC", "dbo");
            builder.HasKey(o => o.Id);

        }
    }
}
