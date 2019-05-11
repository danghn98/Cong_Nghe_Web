using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Ban_Giay_2.Models.Entities;
using PagedList;

namespace Web_Ban_Giay_2.Controllers
{
    public class MauController : Controller
    {
        private ShopModel db = new ShopModel();

        // GET: Mau
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;

            var links = (from l in db.Maus
                         select l).OrderBy(x => x.Mamau);

            int pageSize = 10;

            int pageNumber = (page ?? 1);

            return View(links.ToPagedList(pageNumber, pageSize));
        }

        // GET: Mau/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mau mau = db.Maus.Find(id);
            if (mau == null)
            {
                return HttpNotFound();
            }
            return View(mau);
        }

        // GET: Mau/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mau/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mamau,Tenmau")] Mau mau)
        {
            if (ModelState.IsValid)
            {
                db.Maus.Add(mau);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mau);
        }

        // GET: Mau/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mau mau = db.Maus.Find(id);
            if (mau == null)
            {
                return HttpNotFound();
            }
            return View(mau);
        }

        // POST: Mau/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mamau,Tenmau")] Mau mau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mau);
        }

        // GET: Mau/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mau mau = db.Maus.Find(id);
            if (mau == null)
            {
                return HttpNotFound();
            }
            return View(mau);
        }

        // POST: Mau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mau mau = db.Maus.Find(id);
            db.Maus.Remove(mau);
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
