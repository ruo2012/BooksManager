using BM.Shared.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.DAL.Core.SQL.Dapper.Repos
{
    public class BooksRepository : DapperRepository<Book, int>
    {
        public BooksRepository(string connectionString)
            : base("Books", connectionString)
        { }
    }
}
