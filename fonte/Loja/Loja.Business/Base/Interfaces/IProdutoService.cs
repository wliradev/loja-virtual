using Loja.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Business
{
    public interface IProdutoService
    {
        Produto GetById(long id);
        List<Produto> Find(Func<Produto, bool> predicate);
        List<Produto> All();
        Produto Save(Produto item);
        void Remove(long id);

        List<Categoria> GetCategorias();
        List<Fabricante> GetFabricantes();
        List<Usuario> GetUsuarios();
        List<PosicaoEstoqueFabricanteChartViewModel> GetPosicaoEstoqueChartData();
    }
}
