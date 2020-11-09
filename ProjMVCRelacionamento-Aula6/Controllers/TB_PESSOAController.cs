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
    public class TB_PESSOAController : Controller
    {
        private PessoaTelefoneEntities db = new PessoaTelefoneEntities();

        // GET: TB_PESSOA
        public ActionResult Index()
        {
            return View(db.TB_PESSOA.ToList());
        }

        // GET: TB_PESSOA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PESSOA tB_PESSOA = db.TB_PESSOA.Find(id);
            if (tB_PESSOA == null)
            {
                return HttpNotFound();
            }
            return View(tB_PESSOA);
        }

        // GET: TB_PESSOA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_PESSOA/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,nome")] TB_PESSOA tB_PESSOA)
        public ActionResult Create(TB_PESSOA tB_PESSOA)
        {
            if (ModelState.IsValid)
            {
                db.TB_PESSOA.Add(tB_PESSOA);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            //return View(tB_PESSOA);
            return Json(new { Resultado = tB_PESSOA.Id }, JsonRequestBehavior.AllowGet);
        }

        // GET: TB_PESSOA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PESSOA tB_PESSOA = db.TB_PESSOA.Find(id);
            if (tB_PESSOA == null)
            {
                return HttpNotFound();
            }
            return View(tB_PESSOA);
        }

        // POST: TB_PESSOA/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome")] TB_PESSOA tB_PESSOA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_PESSOA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_PESSOA);
        }

        // GET: TB_PESSOA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PESSOA tB_PESSOA = db.TB_PESSOA.Find(id);
            if (tB_PESSOA == null)
            {
                return HttpNotFound();
            }
            return View(tB_PESSOA);
        }

        // POST: TB_PESSOA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_PESSOA tB_PESSOA = db.TB_PESSOA.Find(id);
            db.TB_PESSOA.Remove(tB_PESSOA);
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
