using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlowerDelivery.Models;

namespace FlowerDelivery.Controllers
{
    public class FlowerItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FlowerItem
        public ActionResult Index()
        {
            return View(db.FlowerItems.ToList());
        }

        // GET: FlowerItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerItem flowerItem = db.FlowerItems.Find(id);
            if (flowerItem == null)
            {
                return HttpNotFound();
            }
            return View(flowerItem);
        }

        // GET: FlowerItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlowerItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] FlowerItem flowerItem)
        {
            if (ModelState.IsValid)
            {
                db.FlowerItems.Add(flowerItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flowerItem);
        }

        // GET: FlowerItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerItem flowerItem = db.FlowerItems.Find(id);
            if (flowerItem == null)
            {
                return HttpNotFound();
            }
            return View(flowerItem);
        }

        // POST: FlowerItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] FlowerItem flowerItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flowerItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flowerItem);
        }

        // GET: FlowerItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerItem flowerItem = db.FlowerItems.Find(id);
            if (flowerItem == null)
            {
                return HttpNotFound();
            }
            return View(flowerItem);
        }

        // POST: FlowerItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlowerItem flowerItem = db.FlowerItems.Find(id);
            db.FlowerItems.Remove(flowerItem);
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
