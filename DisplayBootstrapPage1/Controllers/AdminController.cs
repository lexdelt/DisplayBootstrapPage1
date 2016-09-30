using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisplayBootstrapPage1.DAL;
using DisplayBootstrapPage1.Models;

namespace DisplayBootstrapPage1.Controllers
{
    //[Authorize]                                     // added
    public class AdminController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Products.OrderBy(item => item.Manufacturer).ThenBy(item => item.Category).ToList());
            //return View(db.Products.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,SubName,Category,Manufacturer,Price,Description,Description2,PublishDate,PictureLinkLarge,PictureLinkSmall,InStock,AverageReview,NumberReviews")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.PublishDate = DateTime.Now;     // modified
                product.NumberReviews = 0;              // modified
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,SubName,Category,Manufacturer,Price,Description,Description2,PublishDate,PictureLinkLarge,PictureLinkSmall,InStock,AverageReview,NumberReviews")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            db.SaveChanges();

            return View(product);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        // Should make sure the product is not a part of the shopping cart before deleting
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            //product.Reviews.Clear();                          // not needed any more
            db.Reviews.RemoveRange(product.Reviews);
            db.Products.Remove(product);
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
