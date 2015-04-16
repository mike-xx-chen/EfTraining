using MyCompany.EfTraining.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.EfTraining.BusinessComponents
{
    public class TodoItemLogic : LogicBase<TrainingDbContext, TodoItemEntity>
    {
        [Conditional("DEBUG")]
        public void InitializeDb()
        {
            using(var context = new TrainingDbContext())
            {
                Delete(GetAll());
                if (!context.TodoItemEntities.Any())
                {
                    List<TodoItemEntity> entities = new List<TodoItemEntity>();
                    var random = new Random();
                    int numberOfEntries = 10;
                    for (int i = 0; i < numberOfEntries; i++)
                    {
                        entities.Add(Create(string.Format("Hello Mike {0} !", i + 1), i == 5, random.Next(numberOfEntries)));
                    }

                    Save(entities);
                }
            }
        }

        /// <summary>
        /// As the name implied, gets the first item.
        /// </summary>
        /// <returns></returns>
        public override TodoItemEntity GetFirst()
        {
            using(var context = new TrainingDbContext())
            {
                return context.Set<TodoItemEntity>()
                              .OrderBy(e => e.Sorting)
                              .ThenBy(e => e.Id)
                              .FirstOrDefault();
            }
        }

        /// <summary>
        /// As the name implied, gets the last item.
        /// </summary>
        /// <returns></returns>
        public override TodoItemEntity GetLast()
        {
            using (var context = new TrainingDbContext())
            {
                return context.Set<TodoItemEntity>()
                              .OrderByDescending(e => e.Sorting)
                              .ThenByDescending(e => e.Id)
                              .FirstOrDefault();
            }
        }

        /// <summary>
        /// As the name implied, gets all of items.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<TodoItemEntity> GetAll()
        {
            using (var context = new TrainingDbContext())
            {
                return context.Set<TodoItemEntity>()
                              .OrderBy(e=>e.Sorting)
                              .ThenBy(e=>e.Id)
                              .ToList();
            }
        }

        /// <summary>
        /// AS the name implied, gets the default item.
        /// </summary>
        /// <returns></returns>
        public override TodoItemEntity GetDefault()
        {
            using (var context = new TrainingDbContext())
            {
                return context.Set<TodoItemEntity>()
                              .OrderByDescending(e => e.IsDefault)
                              .ThenBy(e => e.Sorting)
                              .FirstOrDefault();
            }
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="isDefault"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public TodoItemEntity Create(string description, bool isDefault, int sorting = 0)
        {
            ISequenceManager manager = SequenceManagerFactory.Create<TrainingDbContext>();

            return new TodoItemEntity()
            {
                Id = manager.GetNext<TodoItemEntity>(),
                Description = description,
                IsDefault = isDefault,
                Sorting = sorting,
            };
        }

        /// <summary>
        /// Based on multiple keyword search
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public override IEnumerable<TodoItemEntity> Search(string searchText)
        {
            using (var context = new TrainingDbContext())
            {
               char[] charSeparators = new char[] { ' ' };
               string[] searchKeywords = searchText.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
               
               Func<TodoItemEntity, bool> predicate = e =>
               {
                    foreach (var keyword in searchKeywords)
                    {
                        if (e.Description.Contains(keyword))
                        {
                            return true;
                        }
                    }

                    return false;
               };

               return context.Set<TodoItemEntity>()
                      .Where(predicate)
                      .OrderBy(e=>e.Sorting)
                      .ThenBy(e=>e.Id)
                      .ToList();
            }
        }
    }
}
