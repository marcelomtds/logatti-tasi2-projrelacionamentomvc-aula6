using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjMVCRelacionamento_Aula6;

namespace ProjMVCRelacionamento_Aula6.Controllers
{
    public class TB_TELEFONEController : Controller
    {
        private PessoaTelefoneEntities db = new PessoaTelefoneEntities();

        // GET: TB_TELEFONE
        public ActionResult Index()
        {
            var tB_TELEFONE = db.TB_TELEFONE.Include(t => t.TB_PESSOA);
            return View(tB_TELEFONE.ToList());
        }

        // GET: TB_TELEFONE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TELEFONE tB_TELEFONE = db.TB_TELEFONE.Find(id);
            if (tB_TELEFONE == null)
            {
                return HttpNotFound();
            }
            return View(tB_TELEFONE);
        }

        // GET: TB_TELEFONE/Create
        public ActionResult Create()
        {
            ViewBag.id_pessoa = new SelectList(db.TB_PESSOA, "Id", "nome");
            return View();
        }

        // POST: TB_TELEFONE/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,numero,tipo,id_pessoa")] TB_TELEFONE tB_TELEFONE)
        {
            if (ModelState.IsValid)
            {
                db.TB_TELEFONE.Add(tB_TELEFONE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pessoa = new SelectList(db.TB_PESSOA, "Id", "nome", tB_TELEFONE.id_pessoa);
            return View(tB_TELEFONE);
        }

        // GET: TB_TELEFONE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TELEFONE tB_TELEFONE = db.TB_TELEFONE.Find(id);
            if (tB_TELEFONE == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pessoa = new SelectList(db.TB_PESSOA, "Id", "nome", tB_TELEFONE.id_pessoa);
            return View(tB_TELEFONE);
        }

        // POST: TB_TELEFONE/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,numero,tipo,id_pessoa")] TB_TELEFONE tB_TELEFONE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_TELEFONE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pessoa = new SelectList(db.TB_PESSOA, "Id", "nome", tB_TELEFONE.id_pessoa);
            return View(tB_TELEFONE);
        }

        // GET: TB_TELEFONE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TELEFONE tB_TELEFONE = db.TB_TELEFONE.Find(id);
            if (tB_TELEFONE == null)
            {
                return HttpNotFound();
            }
            return View(tB_TELEFONE);
        }

        // POST: TB_TELEFONE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_TELEFONE tB_TELEFONE = db.TB_TELEFONE.Find(id);
            db.TB_TELEFONE.Remove(tB_TELEFONE);
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
