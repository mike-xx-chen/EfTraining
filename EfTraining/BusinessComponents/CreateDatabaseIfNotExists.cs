using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIB.EfTraining.BusinessComponents
{
    public class TrainingCreateDatabaseIfNotExists : CreateDatabaseIfNotExists<TrainingDbContext>
    {
        protected override void Seed(TrainingDbContext context)
        {
            base.Seed(context);
            //Populate data
            var logic = new TodoItemLogic();

            //List<TodoItemEntity> entities = new List<TodoItemEntity>();

            for (int i = 0; i < 10; i++)
            {
                context.TodoItemEntities.Add(logic.Create(string.Format("Hello Mike {0} !", i), i == 5, i+1));
                //entities.Add(logic.Create(string.Format("Hello Mike {0} !", i), i == 5));
            }
        }
    }

    public class TrainingDbInitializer : IDatabaseInitializer<TrainingDbContext>
    {
        static TrainingDbInitializer()
        {
        }

        public void InitializeDatabase(TrainingDbContext context)
        {
            if (!context.TodoItemEntities.Any())
            {
                Seed(context);
            }
        }

        protected virtual void Seed(TrainingDbContext context)
        {
            //Populate data
            var logic = new TodoItemLogic();

            List<TodoItemEntity> entities = new List<TodoItemEntity>();

            for (int i = 0; i < 10; i++)
            {
                context.TodoItemEntities.Add(logic.Create(string.Format("Hello Mike {0} !", i), i == 5, i + 1));
                //entities.Add(logic.Create(string.Format("Hello Mike {0} !", i), i == 5));
            }

            logic.Save(entities);
        }
    }
}
