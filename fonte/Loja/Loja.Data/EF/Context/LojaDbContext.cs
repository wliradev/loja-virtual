using Loja.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Data.EF.Context
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext()
            : base("LojaDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(250));

            base.OnModelCreating(modelBuilder);
        }
    }

    public static class ChangeDb
    {
        public static void ChangeConnection(this LojaDbContext context, string cn)
        {
            context.Database.Connection.ConnectionString = cn;
        }
    }

    public class LojaDbContextInitializer : DropCreateDatabaseAlways<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            context.Usuarios.Add(new Usuario()
            {
                Nome = "Dev",
                Senha = "123",
                Email = "e@e.com.br",
                DataNascimento = DateTime.Now
            });

            context.Categorias.Add(new Categoria()
            {
                Nome = "Wearable",
                Descricao = "Wearable",
                UsuarioId = 1
            });

            context.Fabricantes.Add(new Fabricante()
            {
                Nome = "Apple",
                UsuarioId = 1
            });

            base.Seed(context);
        }
    }
}
