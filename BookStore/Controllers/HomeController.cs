using System;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.DAL;
using BookStore.Models;
using BookStore.ViewModels;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Home
        public ActionResult Index()
        {
            var books = from b in db.bookList
                        select b;
            int Max = books.Count(); //Hold the numbers of books in database
            var r = new Random();
            var random = r.Next(1, Max); // Genereate random number between 1 to Max*/
            books = books.Where(s => s.listID == random);

            return View(books.ToList());
        }
        public ActionResult Statistics()
        {
            IQueryable<ListViewModels> data = from a in db.bookList
                                              group a by a.genre into dataGroup
                                              select new ListViewModels()
                                              {
                                                  genre = dataGroup.Key,
                                                  countBook = dataGroup.Count()
                                              };
            data = data.OrderByDescending(s => s.countBook);
            return View(data);
        }
    }
}
