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
    public class StoresController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Stores
        public ActionResult Index(string searchString , string storeHours)
        {
            /************* Create List Of Opening Hours ****************/
            var hoursList = new List<string>();
            var hoursQry = from d in db.bookStores
                           orderby d.openingTime
                           select d.openingTime;
            hoursList.AddRange(hoursQry.Distinct());
            ViewBag.storeHours = new SelectList(hoursList);

            var stores = from b in db.bookStores
                        select b;

            if (!String.IsNullOrEmpty(searchString)) //Searching By Address
            {
                stores = stores.Where(s => s.address.Contains(searchString) );
            }

            if (!string.IsNullOrEmpty(storeHours)) //Searching By Opening Hours
            {
                stores = stores.Where(x => x.openingTime.Contains(storeHours));
            }

            return View(stores);
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {

           if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stores stores = db.bookStores.Find(id);
            if (stores == null)
            {
                return HttpNotFound();
            }
            return View(stores);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoresId,Name,Address,Phone,Email,OpeningTime")] Stores stores)
        {
            if (ModelState.IsValid)
            {
                db.bookStores.Add(stores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stores);
        }

        // GET: Stores/Edit/5
        [Authorize(Users = "Admin@gmail.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stores stores = db.bookStores.Find(id);
            if (stores == null)
            {
                return HttpNotFound();
            }
            return View(stores);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin@gmail.com")]
        public ActionResult Edit([Bind(Include = "StoresId,Name,Address,Phone,Email,OpeningTime")] Stores stores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stores);
        }

        // GET: Stores/Delete/5
        [Authorize(Users = "Admin@gmail.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stores stores = db.bookStores.Find(id);
            if (stores == null)
            {
                return HttpNotFound();
            }
            return View(stores);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stores stores = db.bookStores.Find(id);
            db.bookStores.Remove(stores);
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
