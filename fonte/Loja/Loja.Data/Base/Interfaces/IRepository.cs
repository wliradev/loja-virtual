using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Data
{
    public interface IRepository<T>
    {
        void Add(T item);

        void Update(T item);

        void Remove(T item);

        T GetById(long id);

        IQueryable<T> GetAll();
    }
}
