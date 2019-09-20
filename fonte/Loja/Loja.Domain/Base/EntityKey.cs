using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain
{
    public abstract class EntityKey
    {
        /// <summary>
        /// Id do produto
        /// </summary>
        [Key]
        public long? Id { get; set; }
    }
}
