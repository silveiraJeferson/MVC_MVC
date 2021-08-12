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
    public class EntradaProdutoDetalhesController : Controller
    {
        private jlsEntitiesFinanceiro db = new jlsEntitiesFinanceiro();

        // GET: EntradaProdutoDetalhes
        public ActionResult Index()
        {
            var entradaProdutoDetalhe = db.EntradaProdutoDetalhe.Include(e => e.EntradaProdutoRegistro).Include(e => e.Produto);
            return View(entradaProdutoDetalhe.ToList());
        }

        // GET: EntradaProdutoDetalhes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaProdutoDetalhe entradaProdutoDetalhe = db.EntradaProdutoDetalhe.Find(id);
            if (entradaProdutoDetalhe == null)
            {
                return HttpNotFound();
            }
            return View(entradaProdutoDetalhe);
        }

        // GET: EntradaProdutoDetalhes/Create
        public ActionResult Create()
        {
            ViewBag.EntradaProdutoId = new SelectList(db.EntradaProdutoRegistro, "Id", "Id");
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao");
            return View();
        }

        // POST: EntradaProdutoDetalhes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Quantidade,ValorUnitario,ValorTotal,EntradaProdutoId,ProdutoId")] EntradaProdutoDetalhe entradaProdutoDetalhe)
        {
            if (ModelState.IsValid)
            {
                db.EntradaProdutoDetalhe.Add(entradaProdutoDetalhe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntradaProdutoId = new SelectList(db.EntradaProdutoRegistro, "Id", "Id", entradaProdutoDetalhe.EntradaProdutoId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao", entradaProdutoDetalhe.ProdutoId);
            return View(entradaProdutoDetalhe);
        }

        // GET: EntradaProdutoDetalhes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaProdutoDetalhe entradaProdutoDetalhe = db.EntradaProdutoDetalhe.Find(id);
            if (entradaProdutoDetalhe == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntradaProdutoId = new SelectList(db.EntradaProdutoRegistro, "Id", "Id", entradaProdutoDetalhe.EntradaProdutoId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao", entradaProdutoDetalhe.ProdutoId);
            return View(entradaProdutoDetalhe);
        }

        // POST: EntradaProdutoDetalhes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Quantidade,ValorUnitario,ValorTotal,EntradaProdutoId,ProdutoId")] EntradaProdutoDetalhe entradaProdutoDetalhe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entradaProdutoDetalhe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntradaProdutoId = new SelectList(db.EntradaProdutoRegistro, "Id", "Id", entradaProdutoDetalhe.EntradaProdutoId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao", entradaProdutoDetalhe.ProdutoId);
            return View(entradaProdutoDetalhe);
        }

        // GET: EntradaProdutoDetalhes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaProdutoDetalhe entradaProdutoDetalhe = db.EntradaProdutoDetalhe.Find(id);
            if (entradaProdutoDetalhe == null)
            {
                return HttpNotFound();
            }
            return View(entradaProdutoDetalhe);
        }

        // POST: EntradaProdutoDetalhes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntradaProdutoDetalhe entradaProdutoDetalhe = db.EntradaProdutoDetalhe.Find(id);
            db.EntradaProdutoDetalhe.Remove(entradaProdutoDetalhe);
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
