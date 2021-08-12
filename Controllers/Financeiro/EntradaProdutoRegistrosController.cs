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
    public class EntradaProdutoRegistrosController : Controller
    {
        private jlsEntitiesFinanceiro db = new jlsEntitiesFinanceiro();

        // GET: EntradaProdutoRegistros
        public ActionResult Index()
        {
            var entradaProdutoRegistro = db.EntradaProdutoRegistro.Include(e => e.Fornecedor);
            return View(entradaProdutoRegistro.ToList());
        }

        // GET: EntradaProdutoRegistros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaProdutoRegistro entradaProdutoRegistro = db.EntradaProdutoRegistro.Find(id);
            if (entradaProdutoRegistro == null)
            {
                return HttpNotFound();
            }
            return View(entradaProdutoRegistro);
        }

        // GET: EntradaProdutoRegistros/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome_");
            return View();
        }

        // POST: EntradaProdutoRegistros/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataEntrada,ValorTotal,Ativo,FornecedorId")] EntradaProdutoRegistro entradaProdutoRegistro)
        {
            if (ModelState.IsValid)
            {
                db.EntradaProdutoRegistro.Add(entradaProdutoRegistro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome_", entradaProdutoRegistro.FornecedorId);
            return View(entradaProdutoRegistro);
        }

        // GET: EntradaProdutoRegistros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaProdutoRegistro entradaProdutoRegistro = db.EntradaProdutoRegistro.Find(id);
            if (entradaProdutoRegistro == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome_", entradaProdutoRegistro.FornecedorId);
            return View(entradaProdutoRegistro);
        }

        // POST: EntradaProdutoRegistros/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataEntrada,ValorTotal,Ativo,FornecedorId")] EntradaProdutoRegistro entradaProdutoRegistro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entradaProdutoRegistro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome_", entradaProdutoRegistro.FornecedorId);
            return View(entradaProdutoRegistro);
        }

        // GET: EntradaProdutoRegistros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaProdutoRegistro entradaProdutoRegistro = db.EntradaProdutoRegistro.Find(id);
            if (entradaProdutoRegistro == null)
            {
                return HttpNotFound();
            }
            return View(entradaProdutoRegistro);
        }

        // POST: EntradaProdutoRegistros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntradaProdutoRegistro entradaProdutoRegistro = db.EntradaProdutoRegistro.Find(id);
            db.EntradaProdutoRegistro.Remove(entradaProdutoRegistro);
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
