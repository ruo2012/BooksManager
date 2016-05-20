using BM.Shared.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.DAL.Core.NoSQL.Redis.Repos
{
    public class BooksRepository : RedisRepository<Book, int>
    {
        public BooksRepository(string host)
            : base(host)
        { }
    }
}
