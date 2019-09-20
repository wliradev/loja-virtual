using Loja.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Data.EF
{
    public class RepositoryEF<T> : IDisposable, IRepository<T> where T : EntityKey
    {
        public DbContext Context { get; set; }

        public List<string> Includes { get; set; }

        public RepositoryEF()
        {
            Includes = new List<string>();
        }

        public RepositoryEF(DbContext contexto)
        {
            Includes = new List<string>();
            Context = contexto;
        }

        public virtual void Add(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }

        public virtual void Remove(T item)
        {
            Context.Set<T>().Remove(item);
            Context.SaveChanges();
        }

        public virtual void Update(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual T GetById(long id)
        {
            DbQuery<T> query = null;

            foreach (var item in Includes)
            {
                if (query == null)
                    query = Context.Set<T>().Include(item);
                else
                    query = query.Include(item);
            }

            return query.Where(p => p.Id == id).FirstOrDefault();
        }

        public virtual IQueryable<T> GetAll()
        {
            if (Includes.Count() == 0)
                return Context.Set<T>();

            DbQuery<T> query = null;

            foreach (var entityToInclude in Includes)
            {
                if (query == null)
                    query = Context.Set<T>().Include(entityToInclude);
                else
                    query = query.Include(entityToInclude);
            }

            return query;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
