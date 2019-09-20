using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain
{
    /// <summary>
    /// Entidade Categoria
    /// </summary>
    public class Categoria : EntityKey
    {
        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição da categoria
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Ativo?
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Data de cadastro
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Id do usuario de cadastro
        /// </summary>
        public long? UsuarioId { get; set; }

        #region Filhos

        /// <summary>
        /// Produtos da Categoria
        /// </summary>
        public ICollection<Produto> Produtos { get; set; }

        #endregion

        #region Relações

        /// <summary>
        /// Usuario de Cadastro
        /// </summary>
        [ForeignKey("UsuarioId")]
        public virtual Usuario UsuarioCadastro { get; set; }

        #endregion

        public Categoria()
        {
            Produtos = new HashSet<Produto>();
            Ativo = true;
            DataCadastro = DateTime.Now;
        }
    }
}