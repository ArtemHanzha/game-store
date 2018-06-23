using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.Contracts.Models.Abstracts;
using EpamLibrary.DAL.Context;
using EpamLibrary.DAL.Interfaces;

namespace EpamLibrary.DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : AbstractDbObject
    {
        private readonly LibraryContext _libraryContext;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
            _dbSet = libraryContext.Set<T>();
        }

        public T GetById(int id)
        {
            var entity = _dbSet.FirstOrDefault(e => e.Id == id);

            return entity;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            var query = _dbSet as IQueryable<T>;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
            _libraryContext.SaveChanges();
        }

        public void Update(T item)
        {
            _libraryContext.Entry(item).State = EntityState.Modified;
            _libraryContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var toRm = _dbSet.Find(id);
            if (toRm != null)
            {
                toRm.IsDeleted = true;
                Update(toRm);
                //_dbSet.Remove(toRm); //TODO: is deleted
            }

            _libraryContext.SaveChanges();
        }
    }
}
