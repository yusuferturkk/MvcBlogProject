using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.ModelBinding;

namespace MvcBlog.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class, new()
    {

        DbBlogEntities db = new DbBlogEntities();

        public void Add(TEntity entity)
        {
            var addedState = db.Entry(entity);
            addedState.State = EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deletedState = db.Entry(entity);
            deletedState.State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = db.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            db.SaveChanges();
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            return db.Set<TEntity>().FirstOrDefault(filter);
        }

        public List<TEntity> GetList()
        {
            return db.Set<TEntity>().ToList();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            return db.Set<TEntity>().Where(filter).ToList();
        }
    }
}