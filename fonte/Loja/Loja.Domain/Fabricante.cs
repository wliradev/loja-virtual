using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain
{
    /// <summary>
    /// Entidade Fabricante
    /// </summary>
    public class Fabricante : EntityKey
    {
        /// <summary>
        /// Nome do Fabricante
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Ativo?
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Data de Cadastro
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Id do usuario de cadastro
        /// </summary>
        public long? UsuarioId { get; set; }

        #region Filhos

        /// <summary>
        /// Produtos do Fabricante
        /// </summary>
        public virtual ICollection<Produto> Produtos { get; set; }

        #endregion

        #region Relações

        /// <summary>
        /// Usuario de Cadastro
        /// </summary>
        [ForeignKey("UsuarioId")]
        private Usuario UsuarioCadastro { get; set; }

        #endregion

        public Fabricante()
        {
            Produtos = new HashSet<Produto>();
            Ativo = true;
            DataCadastro = DateTime.Now;
        }
    }
}