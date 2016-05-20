using BM.DAL.Core;
using BM.Shared.Models.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace BM.Website.Controllers
{
    public class BooksController : BaseController
    {
        // GET: Books
        public ActionResult Index()
        {
            IRepository<Book, int> booksRepo = Unity.Resolve<IRepository<Book, int>>("Dapper");
            IEnumerable<Book> books = booksRepo.Find();
            IRepository<Book, int> noSqlBooksRepo = Unity.Resolve<IRepository<Book, int>>("Redis");
            IEnumerable<Book> noSqlBooks = noSqlBooksRepo.Find();
            return View(books.Union(noSqlBooks));
        }

        public ActionResult Demo()
        {
            string host = "localhost";
            IRepository<Book, int> booksRepo = new DAL.Core.NoSQL.Redis.Repos.BooksRepository(host);
            foreach (Book book in Business.Demo.BooksGenerator.GetSampleData())
            {
                booksRepo.Add(book);
            }
            return new EmptyResult();
        }
    }
}