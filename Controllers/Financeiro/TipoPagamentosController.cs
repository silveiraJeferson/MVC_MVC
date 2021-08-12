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
    public class TipoPagamentosController : Controller
    {
        private jlsEntitiesFinanceiro db = new jlsEntitiesFinanceiro();

        // GET: TipoPagamentos
        public ActionResult Index()
        {
            return View(db.TipoPagamento.OrderBy(tp => tp.Descricao).ToList());
        }

        // GET: TipoPagamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPagamento tipoPagamento = db.TipoPagamento.Find(id);
            if (tipoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(tipoPagamento);
        }

        // GET: TipoPagamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPagamentos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Ativo")] TipoPagamento tipoPagamento)
        {
            if (ModelState.IsValid)
            {
                tipoPagamento.Ativo = true;
                db.TipoPagamento.Add(tipoPagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPagamento);
        }

        // GET: TipoPagamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPagamento tipoPagamento = db.TipoPagamento.Find(id);
            if (tipoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(tipoPagamento);
        }

        // POST: TipoPagamentos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Ativo")] TipoPagamento tipoPagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPagamento);
        }

        // GET: TipoPagamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPagamento tipoPagamento = db.TipoPagamento.Find(id);
            if (tipoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(tipoPagamento);
        }

        // POST: TipoPagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPagamento tipoPagamento = db.TipoPagamento.Find(id);
            db.TipoPagamento.Remove(tipoPagamento);
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
