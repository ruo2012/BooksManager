using BM.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.DAL.Core.Specifications;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace BM.DAL.Core.SQL.Dapper
{
    public abstract class DapperRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        private readonly string _tableName;
        private readonly string _connectionString;

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public DapperRepository(string tableName, string connectionString)
        {
            _tableName = tableName;
            _connectionString = connectionString;
        }

        internal virtual dynamic Mapping(TEntity item)
        {
            return item;
        }

        public virtual void Add(TEntity item)
        {
            using (IDbConnection cn = Connection)
            {
                var parameters = (object)Mapping(item);
                cn.Open();
                item.Id = cn.Insert<TKey>(_tableName, parameters);
            }
        }

        public virtual void Update(TEntity item)
        {
            using (IDbConnection cn = Connection)
            {
                var parameters = (object)Mapping(item);
                cn.Open();
                cn.Update(_tableName, parameters);
            }
        }

        public virtual void Remove(TEntity item)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                cn.Execute("DELETE FROM " + _tableName + " WHERE ID=@ID", new { ID = item.Id });
            }
        }

        public virtual IEnumerable<TEntity> Find()
        {
            IEnumerable<TEntity> items = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                items = cn.Query<TEntity>("SELECT * FROM " + _tableName);
            }

            return items;
        }
        public virtual TEntity Find(TKey id)
        {
            TEntity item = default(TEntity);

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                item = cn.Query<TEntity>("SELECT * FROM " + _tableName + " WHERE ID=@ID", new { ID = id }).SingleOrDefault();
            }

            return item;
        }

        public virtual IEnumerable<TEntity> Find(ISpecification<TEntity> specification)
        {
            IEnumerable<TEntity> items = null;

            // extract the dynamic sql query and parameters from predicate
            QueryResult result = DynamicQuery.GetDynamicQuery<TEntity>(_tableName, x => specification.IsSatisfiedBy(x));

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                items = cn.Query<TEntity>(result.Sql, (object)result.Param);
            }

            return items;
        }
    }
}
