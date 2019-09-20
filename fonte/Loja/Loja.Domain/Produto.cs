using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain
{
    /// <summary>
    /// Entidade de Produto
    /// </summary>
    public class Produto : EntityKey
    {
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

        #region Relações

        /// <summary>
        /// Usuario de cadastro
        /// </summary>
        [ForeignKey("UsuarioId")]
        public virtual Usuario UsuarioCadastro { get; set; }

        /// <summary>
        /// Categoria
        /// </summary>
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        /// <summary>
        /// Fabricante
        /// </summary>
        [ForeignKey("FabricanteId")]
        public Fabricante Fabricante { get; set; }

        #endregion

        public Produto()
        {
            Ativo = true;
            DataCadastro = DateTime.Now;
        }
    }
}
