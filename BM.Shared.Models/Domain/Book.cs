using BM.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Shared.Models.Domain
{
    public class Book : EntityBase<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public string ISBN { get; set; }
    }
}
