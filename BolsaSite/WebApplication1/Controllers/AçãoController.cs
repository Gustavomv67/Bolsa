using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Broker.Models;

namespace WebApplication1.Controllers
{
    public class AçãoController : Controller
    {
        private BrokerContext db = new BrokerContext();

        // GET: Ação
        public ActionResult Index()
        {
            return View(db.Ação.ToList());
        }

        // GET: Ação/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ação ação = db.Ação.Find(id);
            if (ação == null)
            {
                return HttpNotFound();
            }
            return View(ação);
        }

        // GET: Ação/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ação/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nome,descricao")] Ação ação)
        {
            if (ModelState.IsValid)
            {
                db.Ação.Add(ação);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ação);
        }

        // GET: Ação/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ação ação = db.Ação.Find(id);
            if (ação == null)
            {
                return HttpNotFound();
            }
            return View(ação);
        }

        // POST: Ação/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nome,descricao")] Ação ação)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ação).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ação);
        }

        // GET: Ação/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ação ação = db.Ação.Find(id);
            if (ação == null)
            {
                return HttpNotFound();
            }
            return View(ação);
        }

        // POST: Ação/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ação ação = db.Ação.Find(id);
            db.Ação.Remove(ação);
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
