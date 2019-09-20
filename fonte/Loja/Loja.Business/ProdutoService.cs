using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Domain;
using Loja.Data;

namespace Loja.Business
{
    public class ProdutoService : IProdutoService
    {
        ProdutoRepository _repository;

        public ProdutoService()
        {
            _repository = new ProdutoRepository();
        }

        public List<Produto> All()
        {
            return _repository.GetAll().ToList();
        }

        public List<Produto> Find(Func<Produto, bool> predicate)
        {
            return _repository.GetAll().Where(predicate).ToList();
        }

        public Produto GetById(long id)
        {
            return _repository.GetById(id);
        }

        public void Remove(long id)
        {
            Produto produto = _repository.GetById(id);
            _repository.Remove(produto);
        }

        public Produto Save(Produto item)
        {
            if (item.Id.HasValue)
                _repository.Update(item);
            else
                _repository.Add(item);

            return item;
        }

        public List<Categoria> GetCategorias()
        {
            return _repository.GetCategorias();
        }

        public List<Fabricante> GetFabricantes()
        {
            return _repository.GetFabricantes();
        }

        public List<Usuario> GetUsuarios()
        {
            return _repository.GetUsuarios();
        }

        public List<PosicaoEstoqueFabricanteChartViewModel> GetPosicaoEstoqueChartData()
        {
            var query = from produto in _repository.GetAll()
                        group produto by new
                        {
                            produto.Fabricante
                        } into g
                        select new PosicaoEstoqueFabricanteChartViewModel()
                        {
                            Fabricante = g.Key.Fabricante.Nome,
                            Estoque = g.Sum(p => p.Estoque),
                        };

            return query.ToList();
        }
    }
}
