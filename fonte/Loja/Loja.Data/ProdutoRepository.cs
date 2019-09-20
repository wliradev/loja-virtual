using Loja.Data.EF;
using Loja.Data.EF.Context;
using Loja.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Data
{
    public class ProdutoRepository : RepositoryEF<Produto>
    {
        public ProdutoRepository()
        {
            Context = new LojaDbContext();

            Includes.Add("UsuarioCadastro");
            Includes.Add("Categoria");
            Includes.Add("Fabricante");
        }

        public List<Categoria> GetCategorias()
        {
            return ((LojaDbContext)this.Context).Categorias.ToList();
        }

        public List<Fabricante> GetFabricantes()
        {
            return ((LojaDbContext)this.Context).Fabricantes.ToList();
        }

        public List<Usuario> GetUsuarios()
        {
            return ((LojaDbContext)this.Context).Usuarios.ToList();
        }

    }
}
