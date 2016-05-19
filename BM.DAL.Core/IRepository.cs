using BM.DAL.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BM.DAL.Core
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : EntityBase<TKey>
    {
        void Add(TEntity item);
        void Remove(TEntity item);
        void Update(TEntity item);
        TEntity Find(TKey id);
        IEnumerable<TEntity> Find(ISpecification<TEntity> specification);
        IEnumerable<TEntity> Find();
    }
}
