using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.EfTraining.Infrastructure
{
    public static class SequenceManagerFactory
    {
        public static ISequenceManager Create<TContext>() where TContext : DbContext, new()
        {
            return SequenceManager<TContext>.Instance;
        }
    }
}
