using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Loja.App.Web
{
    public class ProdutoViewModel
    {
        public long? Id { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descricao do produto
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Quantidade em estoque
        /// </summary>
        public int Estoque { get; set; }

        /// <summary>
        /// Valor do preço de Custo
        /// </summary>
        public decimal PrecoCusto { get; set; }

        /// <summary>
        /// Valor do preço de venda
        /// </summary>
        public decimal PrecoVenda { get; set; }

        /// <summary>
        /// URL da imagem do produto
        /// </summary>
        public string ImagemURL { get; set; }

        /// <summary>
        /// Produto ativo?
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Tags relacionadas ao produto
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Data de cadastro
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Id do Usuário que cadastrou o produto
        /// </summary>
        public long? UsuarioId { get; set; }

        /// <summary>
        /// Id do Fabricante
        /// </summary>
        public long FabricanteId { get; set; }

        /// <summary>
        /// Id da Categoria
        /// </summary>
        public long CategoriaId { get; set; }

        //[Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Imagem")]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}