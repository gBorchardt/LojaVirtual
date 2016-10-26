using LojaVirtual.Dominio.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Categoria>().ToTable("Categoria");
            //modelBuilder.Entity<Produto>().ToTable("Produto");
        }

        public DbSet<Categoria> Categorias{ get; set; }
        public DbSet<Produto> Produtos { get; set; }

    }
}
