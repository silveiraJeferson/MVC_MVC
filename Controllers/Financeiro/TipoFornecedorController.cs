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
    public class TipoFornecedorController : Controller
    {
        private jlsEntitiesFinanceiro db = new jlsEntitiesFinanceiro();

        // GET: TipoFornecedor
        public ActionResult Index()
        {
            return View(db.TipoFornecedor.ToList());
        }

        // GET: TipoFornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFornecedor tipoFornecedor = db.TipoFornecedor.Find(id);
            if (tipoFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoFornecedor);
        }

        // GET: TipoFornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoFornecedor/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Ativo")] TipoFornecedor tipoFornecedor)
        {
            if (ModelState.IsValid)
            {
                tipoFornecedor.Ativo = true;
                db.TipoFornecedor.Add(tipoFornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoFornecedor);
        }

        // GET: TipoFornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFornecedor tipoFornecedor = db.TipoFornecedor.Find(id);
            if (tipoFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoFornecedor);
        }

        // POST: TipoFornecedor/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Ativo")] TipoFornecedor tipoFornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoFornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoFornecedor);
        }

        // GET: TipoFornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFornecedor tipoFornecedor = db.TipoFornecedor.Find(id);
            if (tipoFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoFornecedor);
        }

        // POST: TipoFornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoFornecedor tipoFornecedor = db.TipoFornecedor.Find(id);
            db.TipoFornecedor.Remove(tipoFornecedor);
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
