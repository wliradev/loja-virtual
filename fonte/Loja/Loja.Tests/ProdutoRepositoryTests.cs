using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Domain;
using Loja.Data.EF.Context;

namespace Loja.Data.Tests
{
    [TestClass()]
    public class ProdutoRepositoryTests
    {
        ProdutoRepository _repository;

        public ProdutoRepositoryTests()
        {
            _repository = new ProdutoRepository();
        }

        [TestMethod()]
        public void Seed()
        {
            // Seed
            LojaDbContext context = (LojaDbContext)_repository.Context;
            context.Usuarios.Add(new Usuario()
            {
                Nome = "Dev",
                Senha = "123",
                Email = "e@e.com.br",
                DataNascimento = DateTime.Now
            });

            context.SaveChanges();

            context.Categorias.Add(new Categoria()
            {
                Nome = "Wearable",
                Descricao = "Wearable",
                UsuarioId = 1
            });

            context.SaveChanges();

            context.Fabricantes.Add(new Fabricante()
            {
                Nome = "Apple",
                UsuarioId = 1
            });

            context.SaveChanges();
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            Produto novoProduto = new Produto()
            {
                Nome = "Apple Watch Serie 3 38mm",
                Descricao = "Apple Watch Serie 3 38mm Sport - Black",
                PrecoCusto = 1500.00M,
                PrecoVenda = 2079.00M,
                Estoque = 20,
                ImagemURL = "public/foto-watch-s3.png",
                Tags = "apple, watch, s3",
                UsuarioId = 1,
                FabricanteId = 1,
                CategoriaId = 1
            };

            // Act
            _repository.Add(novoProduto);

            // Assert
            Assert.IsNotNull(novoProduto.Id);
        }
    }
}