using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCartRepositories.Interfaces;

namespace VCartRepositories.Implementaion
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
       DbContext _Context;
        DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext Context, DbSet<TEntity> dbSet)
        {
            _Context = Context;
            _dbSet = Context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
           _dbSet.Remove(entity);
            _Context.SaveChanges();
        }

        public TEntity FindById(object id)
        {
            return _dbSet.Find(id);
        }

        public List<TEntity> GetAll()
        {
           return _dbSet.ToList();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _Context.SaveChanges();
        }
    }
}
