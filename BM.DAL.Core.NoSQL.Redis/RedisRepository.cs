using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.DAL.Core.Specifications;
using ServiceStack.Redis;

namespace BM.DAL.Core.NoSQL.Redis
{
    public abstract class RedisRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        private readonly string _host;

        public RedisRepository(string host)
        {
            _host = host;
        }

        public virtual void Add(TEntity item)
        {
            using (RedisClient rc = new RedisClient(_host))
            {
                var entities = rc.As<TEntity>();
                entities.Store(item);
            }
        }

        public virtual IEnumerable<TEntity> Find()
        {
            using (RedisClient rc = new RedisClient(_host))
            {
                var entities =  rc.As<TEntity>();
                return entities.GetAll();
            }
        }

        public virtual IEnumerable<TEntity> Find(ISpecification<TEntity> specification)
        {
            return Find().Where(x => specification.IsSatisfiedBy(x));
        }

        public virtual TEntity Find(TKey id)
        {
            using (RedisClient rc = new RedisClient(_host))
            {
                var entities = rc.As<TEntity>();
                return entities.GetById(id);
            }
        }

        public virtual void Remove(TEntity item)
        {
            using (RedisClient rc = new RedisClient(_host))
            {
                var entities = rc.As<TEntity>();
                entities.DeleteById(item.Id);
            }
        }

        public virtual void Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
