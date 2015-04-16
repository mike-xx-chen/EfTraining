using RIB.EfTraining.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIB.EfTraining.BusinessComponents
{
    public class TodoItemAdoNetLogic : LogicBase
    {
        /// <summary>
        /// As the name implied, gets the first item.
        /// </summary>
        /// <returns></returns>
        public virtual TodoItemEntity GetFirst()
        {
            return null;
        }

        /// <summary>
        /// As the name implied, gets the last item.
        /// </summary>
        /// <returns></returns>
        public virtual TodoItemEntity GetLast()
        {
            return null;
        }

        /// <summary>
        /// Gets a item via a condition.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual TodoItemEntity GetItem(Func<TodoItemEntity, bool> predicate)
        {
            return null;
        }

        /// <summary>
        /// Gets a list of items via a certain condition.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        //public virtual IEnumerable<TodoItemEntity> GetItems(Expression<Func<TodoItemEntity, bool>> predicate)
        //{
        //    using (var context = new TContext())
        //    {
        //        return context.Set<TEntity>()
        //                      .Where(predicate)
        //                      .ToList();
        //    }
        //}

        /// <summary>
        /// As the name implied, gets all of items.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TodoItemEntity> GetAll()
        {
            return null;
        }

        /// <summary>
        /// AS the name implied, gets the default item.
        /// </summary>
        /// <returns></returns>
        public virtual TodoItemEntity GetDefault()
        {
            return null;
        }

        /// <summary>
        /// Saves all incoming entities.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual bool Save(IEnumerable<TodoItemEntity> entities)
        {
            return false;
            //using (var context = new TContext())
            //{
            //    foreach (var item in entities)
            //    {
            //        context.Set<TEntity>().Attach(item);

            //        if (item.Version != 0)
            //        {
            //            item.Version++;
            //            item.UpdatedDate = DateTime.UtcNow;
            //            context.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Modified;
            //        }
            //        else
            //        {
            //            item.Version++;
            //            item.CreatedDate = DateTime.UtcNow;
            //            context.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Added;
            //        }
            //    }

            //    return context.SaveChanges() == 0;
            //}
        }

        /// <summary>
        /// Saves the entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Save(TodoItemEntity entity)
        {
            return Save(new List<TodoItemEntity>() { entity });
        }

        /// <summary>
        /// Deletes the incoming items.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Delete(IEnumerable<TodoItemEntity> entities)
        {
            //using (var context = new TContext())
            //{
            //    foreach (var item in entities)
            //    {
            //        context.Set<TEntity>().Attach(item);
            //        context.Set<TEntity>().Remove(item);
            //    }

            //    context.SaveChanges();
            //}
        }

        /// <summary>
        /// Deletes the incoming item.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TodoItemEntity entity)
        {
            Delete(new List<TodoItemEntity>() { entity });
        }

        /// <summary>
        /// Deletes the item by id.
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(int id)
        {
            var entity = GetItem(e => e.Id == id);
            Delete(new List<TodoItemEntity>() { entity });
        }

        /// <summary>
        /// Deletes a list of items by id.
        /// </summary>
        /// <param name="ids"></param>
        public virtual void Delete(IEnumerable<int> ids)
        {
            //var entities = GetItems(e => ids.Contains(e.Id));
            //Delete(entities);
        }

        /// <summary>
        /// Based on multiple keyword search
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public virtual IEnumerable<TodoItemEntity> Search(string searchText)
        {
            return null;
        } 
    }
}
