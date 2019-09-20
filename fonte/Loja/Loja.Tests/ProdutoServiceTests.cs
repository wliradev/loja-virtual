using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Domain;

namespace Loja.Business.Tests
{
    [TestClass()]
    public class ProdutoServiceTests
    {
        ProdutoService _service;

        public ProdutoServiceTests()
        {
            _service = new ProdutoService();
        }

        [TestMethod()]
        public void AllTest()
        {
            var itens = _service.All();

            Assert.IsTrue(itens != null && itens.Count > 0);
        }

        [TestMethod()]
        public void Add_Get_Update_Remove_Test()
        {
            var produto = new Produto()
            {
                Nome = "TEstes",
                Descricao = "Teste",
                PrecoCusto = 1500.00M,
                PrecoVenda = 2079.00M,
                Estoque = 20,
                ImagemURL = "public/foto-watch-s3.png",
                Tags = "apple, watch, s3",
                UsuarioId = 1,
                FabricanteId = 1,
                CategoriaId = 1
            };

            _service.Save(produto);
            Assert.IsNotNull(produto.Id);

            string novaDescricao = "Teste modificado";
            produto.Nome = novaDescricao;
            _service.Save(produto);
            Assert.IsTrue(produto.Nome.Equals(novaDescricao));

            _service.Remove(produto.Id.Value);
            var produtoDel = _service.GetById(produto.Id.Value);
            Assert.IsNull(produtoDel);
        }

        [TestMethod()]
        public void GetPosicaoEstoqueChartDataTest()
        {
            var dados = _service.GetPosicaoEstoqueChartData();

            Assert.IsNotNull(dados);
        }
    }
}