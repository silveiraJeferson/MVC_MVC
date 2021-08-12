using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_MVC;

namespace MVC_MVC.Controllers.Financeiro
{
    public class OrcamentoRegistrosController : Controller
    {
        private jlsEntitiesFinanceiro db = new jlsEntitiesFinanceiro();

        // GET: OrcamentoRegistros
        public ActionResult Index()
        {
            return View(db.OrcamentoRegistro.ToList());
        }

        // GET: OrcamentoRegistros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrcamentoRegistro orcamentoRegistro = db.OrcamentoRegistro.Find(id);
            if (orcamentoRegistro == null)
            {
                return HttpNotFound();
            }
            return View(orcamentoRegistro);
        }

        // GET: OrcamentoRegistros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrcamentoRegistros/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClienteId,FuncionarioId,DataOrcamento,ValorTotal")] OrcamentoRegistro orcamentoRegistro)
        {
            if (ModelState.IsValid)
            {
                db.OrcamentoRegistro.Add(orcamentoRegistro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orcamentoRegistro);
        }

        // GET: OrcamentoRegistros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrcamentoRegistro orcamentoRegistro = db.OrcamentoRegistro.Find(id);
            if (orcamentoRegistro == null)
            {
                return HttpNotFound();
            }
            return View(orcamentoRegistro);
        }

        // POST: OrcamentoRegistros/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClienteId,FuncionarioId,DataOrcamento,ValorTotal")] OrcamentoRegistro orcamentoRegistro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orcamentoRegistro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orcamentoRegistro);
        }

        // GET: OrcamentoRegistros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrcamentoRegistro orcamentoRegistro = db.OrcamentoRegistro.Find(id);
            if (orcamentoRegistro == null)
            {
                return HttpNotFound();
            }
            return View(orcamentoRegistro);
        }

        // POST: OrcamentoRegistros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrcamentoRegistro orcamentoRegistro = db.OrcamentoRegistro.Find(id);
            db.OrcamentoRegistro.Remove(orcamentoRegistro);
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
