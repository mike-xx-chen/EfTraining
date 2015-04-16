using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.EfTraining.Infrastructure
{
    public class SequenceManager<TContext> : ISequenceManager where TContext : DbContext, new()
    {
        private static Lazy<SequenceManager<TContext>> _lazyInstance = new Lazy<SequenceManager<TContext>>(() => new SequenceManager<TContext>(), true);

        private SequenceManager()
        {

        }

        private Dictionary<Type, int> _nextIdMap = new Dictionary<Type, int>();

        public static SequenceManager<TContext> Instance
        {
            get { return _lazyInstance.Value; }
        }

        public int GetNext<TEntity>() where TEntity : class, IEntity
        {
            int nextId = 0;

            if (!_nextIdMap.ContainsKey(typeof(TEntity)))
            {
                using (var context = new TContext())
                {
                    if (context.Set<TEntity>().Any())
                    {
                        nextId = context.Set<TEntity>().Max(e => e.Id);
                    }
                }

                _nextIdMap.Add(typeof(TEntity), nextId+2);
                ++nextId;
            }
            else
            {
                nextId = _nextIdMap[typeof(TEntity)];
                _nextIdMap[typeof(TEntity)] = ++_nextIdMap[typeof(TEntity)];
            }

            return nextId;
        }
    }
}
