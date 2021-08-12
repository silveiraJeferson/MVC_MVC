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
    public class FornecedorController : Controller
    {
        private jlsEntitiesFinanceiro db = new jlsEntitiesFinanceiro();

        // GET: Fornecedor
        public ActionResult Index()
        {
            var fornecedor = db.Fornecedor.Include(f => f.Bairro).Include(f => f.TipoFornecedor);
            return View(fornecedor.ToList());
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            ViewBag.BairroId = new SelectList(db.Bairro, "Id", "Nome");
            ViewBag.TipoFornecedorId = new SelectList(db.TipoFornecedor, "Id", "Descricao");
            return View();
        }

        // POST: Fornecedor/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome_,Cpf,Rg,Cnpj,Endereco,Email,Site,Fone,Ativo,TipoFornecedorId,BairroId")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Fornecedor.Add(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BairroId = new SelectList(db.Bairro, "Id", "Nome", fornecedor.BairroId);
            ViewBag.TipoFornecedorId = new SelectList(db.TipoFornecedor, "Id", "Descricao", fornecedor.TipoFornecedorId);
            return View(fornecedor);
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.BairroId = new SelectList(db.Bairro, "Id", "Nome", fornecedor.BairroId);
            ViewBag.TipoFornecedorId = new SelectList(db.TipoFornecedor, "Id", "Descricao", fornecedor.TipoFornecedorId);
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome_,Cpf,Rg,Cnpj,Endereco,Email,Site,Fone,Ativo,TipoFornecedorId,BairroId")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BairroId = new SelectList(db.Bairro, "Id", "Nome", fornecedor.BairroId);
            ViewBag.TipoFornecedorId = new SelectList(db.TipoFornecedor, "Id", "Descricao", fornecedor.TipoFornecedorId);
            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            db.Fornecedor.Remove(fornecedor);
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
