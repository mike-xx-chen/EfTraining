using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.EfTraining.Infrastructure
{
    public class LogicBase : MarshalByRefObject
    {
    }

    public class LogicBase<TContext, TEntity> : LogicBase 
        where TContext: DbContext, new()
        where TEntity : class,IEntity
    {
        /// <summary>
        /// As the name implied, gets the first item.
        /// </summary>
        /// <returns></returns>
        public virtual TEntity GetFirst()
        {
            return null;
        }

        /// <summary>
        /// As the name implied, gets the last item.
        /// </summary>
        /// <returns></returns>
        public virtual TEntity GetLast()
        {
            return null;
        }

        /// <summary>
        /// Gets a item via a condition.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual TEntity GetItem(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>()
                              .Where(predicate)
                              .FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets a list of items via a certain condition.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetItems(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>()
                              .Where(predicate)
                              .ToList();
            }
        }

        /// <summary>
        /// As the name implied, gets all of items.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>()
                              .ToList();
            }
        }

        /// <summary>
        /// AS the name implied, gets the default item.
        /// </summary>
        /// <returns></returns>
        public virtual TEntity GetDefault()
        {
            return null;
        }

        /// <summary>
        /// Saves all incoming entities.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual bool Save(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var item in entities)
                {
                    context.Set<TEntity>().Attach(item);

                    if (item.Version != 0)
                    {
                        item.Version++;
                        item.UpdatedDate = DateTime.UtcNow;
                        context.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        item.Version++;
                        item.CreatedDate = DateTime.UtcNow;
                        context.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Added;
                    }
                }

                return context.SaveChanges() == 0;
            }
        }

        /// <summary>
        /// Saves the entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Save(TEntity entity)
        {
            return Save(new List<TEntity>() { entity });
        }

        /// <summary>
        /// Deletes the incoming items.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var item in entities)
                {
                    context.Set<TEntity>().Attach(item);
                    context.Set<TEntity>().Remove(item);
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the incoming item.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            Delete(new List<TEntity>() { entity });
        }

        /// <summary>
        /// Deletes the item by id.
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(int id)
        {
            var entity = GetItem(e => e.Id == id);
            Delete(new List<TEntity>() { entity });
        }

        /// <summary>
        /// Deletes a list of items by id.
        /// </summary>
        /// <param name="ids"></param>
        public virtual void Delete(IEnumerable<int> ids)
        {
            var entities = GetItems(e => ids.Contains(e.Id));
            Delete(entities);
        }

        /// <summary>
        /// Based on multiple keyword search
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Search(string searchText)
        {
            return null;
        }
    }
}
