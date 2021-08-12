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
    public class OrcamentoDetalhesController : Controller
    {
        private jlsEntitiesFinanceiro db = new jlsEntitiesFinanceiro();

        // GET: OrcamentoDetalhes
        public ActionResult Index()
        {
            var orcamentoDetalhe = db.OrcamentoDetalhe.Include(o => o.OrcamentoRegistro).Include(o => o.Produto);
            return View(orcamentoDetalhe.ToList());
        }

        // GET: OrcamentoDetalhes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrcamentoDetalhe orcamentoDetalhe = db.OrcamentoDetalhe.Find(id);
            if (orcamentoDetalhe == null)
            {
                return HttpNotFound();
            }
            return View(orcamentoDetalhe);
        }

        // GET: OrcamentoDetalhes/Create
        public ActionResult Create()
        {
            ViewBag.OrcamentoRegistroId = new SelectList(db.OrcamentoRegistro, "Id", "Id");
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao");
            return View();
        }

        // POST: OrcamentoDetalhes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrcamentoRegistroId,ProdutoId,Qtd,ValorUnitario,ValorTotal,Ativo")] OrcamentoDetalhe orcamentoDetalhe)
        {
            if (ModelState.IsValid)
            {
                db.OrcamentoDetalhe.Add(orcamentoDetalhe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrcamentoRegistroId = new SelectList(db.OrcamentoRegistro, "Id", "Id", orcamentoDetalhe.OrcamentoRegistroId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao", orcamentoDetalhe.ProdutoId);
            return View(orcamentoDetalhe);
        }

        // GET: OrcamentoDetalhes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrcamentoDetalhe orcamentoDetalhe = db.OrcamentoDetalhe.Find(id);
            if (orcamentoDetalhe == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrcamentoRegistroId = new SelectList(db.OrcamentoRegistro, "Id", "Id", orcamentoDetalhe.OrcamentoRegistroId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao", orcamentoDetalhe.ProdutoId);
            return View(orcamentoDetalhe);
        }

        // POST: OrcamentoDetalhes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrcamentoRegistroId,ProdutoId,Qtd,ValorUnitario,ValorTotal,Ativo")] OrcamentoDetalhe orcamentoDetalhe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orcamentoDetalhe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrcamentoRegistroId = new SelectList(db.OrcamentoRegistro, "Id", "Id", orcamentoDetalhe.OrcamentoRegistroId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao", orcamentoDetalhe.ProdutoId);
            return View(orcamentoDetalhe);
        }

        // GET: OrcamentoDetalhes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrcamentoDetalhe orcamentoDetalhe = db.OrcamentoDetalhe.Find(id);
            if (orcamentoDetalhe == null)
            {
                return HttpNotFound();
            }
            return View(orcamentoDetalhe);
        }

        // POST: OrcamentoDetalhes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrcamentoDetalhe orcamentoDetalhe = db.OrcamentoDetalhe.Find(id);
            db.OrcamentoDetalhe.Remove(orcamentoDetalhe);
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
