using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.DAL;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class ListController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: List
        public ActionResult Index(string sortOrder)
        {
            var sortList = from s in db.bookList
                            select s;
            /********************************************
                 Order Books BY Year or Book Name or Price
            *********************************************/
            ViewBag.BookSortParm = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            ViewBag.YearSortParm = sortOrder == "year" ? "year_desc" : "year";
            ViewBag.PriceSortParm = sortOrder == "price" ? "price_desc" : "price";

            switch (sortOrder)
            {
                case "book_desc":
                    sortList = sortList.OrderByDescending(s => s.title);
                    break;
                case "year_desc":
                    sortList = sortList.OrderByDescending(s => s.year);
                    break;
                case "year":
                    sortList = sortList.OrderBy(s => s.year);
                    break;
                case "price_desc":
                    sortList = sortList.OrderByDescending(s => s.price);
                    break;
                case "price":
                    sortList = sortList.OrderBy(s => s.price);
                    break;
                default:
                    sortList = sortList.OrderBy(s => s.listID);
                    break;
            }
            return View(sortList.ToList());
        }
        public ActionResult Search(string searchString, string bookGenre, string bookAuthor, int? bookYear, double? bookPrice)
        {
            /************* Create List Of Years ****************/
            var YearList = new List<int>();
            var YearQry = from a in db.bookList
                          orderby a.year
                          select a.year;
            YearList.AddRange(YearQry.Distinct());
            ViewBag.bookYear = new SelectList(YearList);

            /************* Create List Of Genres ****************/
            var GenreList = new List<string>();
            var GenreQry = from d in db.bookList
                           orderby d.genre
                           select d.genre;
            GenreList.AddRange(GenreQry.Distinct());
            ViewBag.bookGenre = new SelectList(GenreList);

            var books = from b in db.bookList
                        select b;

            if (!String.IsNullOrEmpty(searchString)) //Searching By Title
            {
                books = books.Where(s => s.title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookGenre)) //Searching By Genre
            {
                books = books.Where(x => x.genre == bookGenre);
            }

            if (!string.IsNullOrEmpty(bookAuthor)) //Searching By Author
            {
                books = books.Where(y => y.author.Contains(bookAuthor));
            }

            if (bookYear > 0) //Searching By Year
            {
                books = books.Where(z => z.year == bookYear);
            }
            if (bookPrice > 0) //Searching By Price
            {
                books = books.Where(z => z.price >= bookPrice);
            }
            return View(books);
        }
        // GET: Search
        public ActionResult SearchBook(string searchString, string bookGenre, string bookAuthor, int? bookYear, double? bookPrice)
        {
            /************* Create List Of Years ****************/
            var YearList = new List<int>();
            var YearQry = from a in db.bookList
                          orderby a.year
                          select a.year;
            YearList.AddRange(YearQry.Distinct());
            ViewBag.bookYear = new SelectList(YearList);

            /************* Create List Of Genres ****************/
            var GenreList = new List<string>();
            var GenreQry = from d in db.bookList
                           orderby d.genre
                           select d.genre;
            GenreList.AddRange(GenreQry.Distinct());
            ViewBag.bookGenre = new SelectList(GenreList);

            var books = from b in db.bookList
                        select b;

            if (!String.IsNullOrEmpty(searchString)) //Searching By Title
            {
                books = books.Where(s => s.title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookGenre)) //Searching By Genre
            {
                books = books.Where(x => x.genre == bookGenre);
            }

            if (!string.IsNullOrEmpty(bookAuthor)) //Searching By Author
            {
                books = books.Where(y => y.author.Contains(bookAuthor));
            }

            if (bookYear > 0) //Searching By Year
            {
                books = books.Where(z => z.year == bookYear);
            }
            if (bookPrice > 0) //Searching By Price
            {
                books = books.Where(z => z.price >= bookPrice);
            }
            return View(books);
        }


        public ActionResult BookStatistics()
        {
            var books = from d in db.bookList
                        select d;
            /*************************
                Genre Statistics
            *************************/
            var g = books.Where(z => z.genre.Contains("Kids"));
            int gK = g.Count();
            ViewBag.gK = gK;

            g = books.Where(z => z.genre.Contains("Sport"));
            int gS = g.Count();
            ViewBag.gS = gS;

            g = books.Where(z => z.genre.Contains("Biography"));
            int gB = g.Count();
            ViewBag.gB = gB;

            g = books.Where(z => z.genre.Contains("Romantic"));
            int gR = g.Count();
            ViewBag.gR = gR;

            g = books.Where(z => z.genre.Contains("Action"));
            int gA = g.Count();
            ViewBag.gA = gA;

            g = books.Where(z => z.genre.Contains("History"));
            int gHi = g.Count();
            ViewBag.gHi = gHi;

            g = books.Where(z => z.genre.Contains("Classics"));
            int gC = g.Count();
            ViewBag.gC = gC;

            g = books.Where(z => z.genre.Contains("Drama"));
            int gD = g.Count();
            ViewBag.gD = gD;

            /*************************
                Years Statistics
            *************************/
            g = books.Where(z => z.year > 1900 && z.year < 1920);
            int g1 = g.Count();
            ViewBag.g1 = g1;

            g = books.Where(z => z.year > 1921 && z.year < 1940);
            int g2 = g.Count();
            ViewBag.g2 = g2;

            g = books.Where(z => z.year > 1941 && z.year < 1960);
            int g3 = g.Count();
            ViewBag.g3 = g3;

            g = books.Where(z => z.year > 1961 && z.year < 1980);
            int g4 = g.Count();
            ViewBag.g4 = g4;

            g = books.Where(z => z.year > 1981 && z.year < 2000);
            int g5 = g.Count();
            ViewBag.g5 = g5;

            g = books.Where(z => z.year > 2001 && z.year < 2015);
            int g6 = g.Count();
            ViewBag.g6 = g6;
            
            return View();
        }
        // GET: List/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.bookList.Find(id);
            CalcRatAvg(id);

            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // GET: List/CommentDetails/5
        public ActionResult CommentDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.bookComments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }

        // GET: List/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: List/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListID,Title,Content,Author,Publisher,Genre,Price,Year,Picture,Rating")] List list)
        {
            if (ModelState.IsValid)
            {
                db.bookList.Add(list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(list);
        }

        // GET: List/Edit/5
        [Authorize(Users = "Admin@gmail.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.bookList.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: List/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin@gmail.com")]
        public ActionResult Edit([Bind(Include = "ListID,Title,Content,Author,Publisher,Genre,Price,Year,Picture,Rating")] List list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(list);
        }

        // GET: List/Delete/5
        [Authorize(Users = "Admin@gmail.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.bookList.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List list = db.bookList.Find(id);
            db.bookList.Remove(list);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void CalcRatAvg (int? id) {
            
            double ra = 0;
            double avra = 0;

            List list = db.bookList.Find(id);
            var com = db.bookComments;
            var book = db.bookList.Where(b => b.listID == id).First();
            ra = book.comments.Count;  //Counting the Numbers Of Ratings
            foreach (var item in com)
            {
                if (item.listID == id)
                {
                    avra += item.rating;   //Sum Of the Ratings
                }
            }
            list.rating =(avra) / (ra); //Calculate the Average of the Rating
        }
    }
}
