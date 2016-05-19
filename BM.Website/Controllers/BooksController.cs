using BM.DAL.Core;
using BM.Shared.Models.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BM.Website.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BooksShop"].ConnectionString;
            IRepository<Book, int> booksRepo = new BM.DAL.Core.SQL.Dapper.Repos.BooksRepository(connectionString);
            IEnumerable<Book> books = booksRepo.Find();
            return View(books);
        }
    }
}