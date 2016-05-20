using BM.Shared.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Website.Business.Demo
{
    internal class BooksGenerator
    {
        public static IEnumerable<Book> GetSampleData()
        {
            yield return new Book { Id = 1, Title = "Tales from Shakespeare", Author = "Demo" };
            yield return new Book { Id = 2, Title = "The History of Little Henry and his Bearer", Author = "Demo" };
            yield return new Book { Id = 3, Title = "Hoodie", Author = "Demo" };
            yield return new Book { Id = 4, Title = "Coral Island (1857)", Author = "Demo" };
            yield return new Book { Id = 5, Title = "The Rose and the Ring (1854)", Author = "Demo" };
            yield return new Book { Id = 6, Title = "Westward Ho! (1855)", Author = "Demo" };
            yield return new Book { Id = 7, Title = "At the Back of the North Wind (1871)", Author = "Demo" };
            yield return new Book { Id = 8, Title = "Through the Looking-Glass (1871)", Author = "Demo" };
            yield return new Book { Id = 9, Title = "The Princess and the Goblin (1872)", Author = "Demo" };
            yield return new Book { Id = 10, Title = "The Wouldbegoods (1899)", Author = "Demo" };
        }
    }
}
