using RIB.EfTraining.BusinessComponents;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIB.EfTraining
{
    public partial class TrainingDbContext
    {
        static TrainingDbContext()
        {
#if DEBUG
            DbInterception.Add(new DatabaseLogger("./LogOutput.txt", false));
            //Database.SetInitializer<TrainingDbContext>(new TrainingDbInitializer());
#else
            Database.SetInitializer<TrainingDbContext>(new NullDatabaseInitializer());
#endif
        }
    }
}
