using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.EfTraining.Infrastructure
{
    public interface ISequenceManager
    {
        int GetNext<TEntity>() where TEntity : class, IEntity;
    }
}
