using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeContatos.Data.Map
{
    public class ColaboradorMap : IEntityTypeConfiguration<ColaboradorModel>
    {
        public void Configure(EntityTypeBuilder<ColaboradorModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Unidade);
        }
    }
}
