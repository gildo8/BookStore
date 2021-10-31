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
    public class CommentsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Comments
        public ActionResult Index(string sortOrder , int? ratingSort)
        {
            var bookComments = db.bookComments.Include(c => c.bookList);
            /********************************************
                 Order Comments BY Rating or Book Name
            *********************************************/
            ViewBag.BookSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RatingSortParm = sortOrder == "rating" ? "rating_desc" : "rating";

            switch(sortOrder)
            {
                case "name_desc" :
                    bookComments = bookComments.OrderByDescending(s => s.bookList.title);
                    break;
                case "rating_desc":
                    bookComments = bookComments.OrderByDescending(s => s.rating);
                    break;
                case "rating":
                    bookComments = bookComments.OrderBy(s => s.rating);
                    break;
                default:
                    bookComments = bookComments.OrderBy(s => s.listID);
                    break;
            }
            return View(bookComments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
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

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.ListID = new SelectList(db.bookList, "ListID", "Title");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentsID,ListID,CommentTitle,Writer,Content,Rating,Email,Phone")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.bookComments.Add(comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListID = new SelectList(db.bookList, "ListID", "Title", comments.listID);
            return View(comments);
        }

        // GET: Comments/Edit/5
        [Authorize(Users = "Admin@gmail.com")]
        public ActionResult Edit(int? id)
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
            ViewBag.ListID = new SelectList(db.bookList, "ListID", "Title", comments.listID);
            return View(comments);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin@gmail.com")]
        public ActionResult Edit([Bind(Include = "CommentsID,ListID,CommentTitle,Writer,Content,Rating,Email,Phone")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListID = new SelectList(db.bookList, "ListID", "Title", comments.listID);
            return View(comments);
        }

        // GET: Comments/Delete/5
        [Authorize(Users = "Admin@gmail.com")]
        public ActionResult Delete(int? id)
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

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comments comments = db.bookComments.Find(id);
            db.bookComments.Remove(comments);
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
    }
}
