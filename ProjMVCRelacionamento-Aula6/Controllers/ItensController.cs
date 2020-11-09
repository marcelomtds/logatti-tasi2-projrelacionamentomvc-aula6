using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjMVCRelacionamento_Aula6.Controllers
{
    public class ItensController : Controller
    {
        private PessoaTelefoneEntities db = new PessoaTelefoneEntities();
        public ActionResult ListarItens(int id)
        {
            var lista = db.TB_TELEFONE.Where(t => t.TB_PESSOA.Id == id);
            ViewBag.Pessoa = id;
            return PartialView(lista);
        }
        public ActionResult SalvarTelefones(string numero, string tipo, int idPessoa)
        {
            var telefone = new TB_TELEFONE()
            {
                numero = numero,
                tipo = tipo,
                TB_PESSOA = db.TB_PESSOA.Find(idPessoa)
            };
            db.TB_TELEFONE.Add(telefone);
            db.SaveChanges();
            return Json(new { Resultado = telefone.Id }, JsonRequestBehavior.AllowGet);
        }
    }
}