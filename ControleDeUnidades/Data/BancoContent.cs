using ControleDeContatos.Data.Map;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContent : DbContext
    {
        public BancoContent(DbContextOptions<BancoContent> options) :
            base(options)
        {
        }
       
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<UnidadeModel> Unidades { get; set; }
        public DbSet<ColaboradorModel> Colaboradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradorMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
