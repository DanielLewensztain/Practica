using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdmPractica1.Models;

namespace AdmPractica1.Controllers
{
    public class lewensztainsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: lewensztains
        [Authorize]
        public ActionResult Index()
        {
            return View(db.lewensztains.ToList());
        }

        // GET: lewensztains/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lewensztain lewensztain = db.lewensztains.Find(id);
            if (lewensztain == null)
            {
                return HttpNotFound();
            }
            return View(lewensztain);
        }

        // GET: lewensztains/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: lewensztains/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lewensztainID,Friendoflewensztain,place,email,birthdate")] lewensztain lewensztain)
        {
            if (ModelState.IsValid)
            {
                db.lewensztains.Add(lewensztain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lewensztain);
        }

        // GET: lewensztains/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lewensztain lewensztain = db.lewensztains.Find(id);
            if (lewensztain == null)
            {
                return HttpNotFound();
            }
            return View(lewensztain);
        }

        // POST: lewensztains/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lewensztainID,Friendoflewensztain,place,email,birthdate")] lewensztain lewensztain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lewensztain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lewensztain);
        }

        // GET: lewensztains/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lewensztain lewensztain = db.lewensztains.Find(id);
            if (lewensztain == null)
            {
                return HttpNotFound();
            }
            return View(lewensztain);
        }

        // POST: lewensztains/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lewensztain lewensztain = db.lewensztains.Find(id);
            db.lewensztains.Remove(lewensztain);
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
