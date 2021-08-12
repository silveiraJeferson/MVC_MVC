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
    public class VendaDetalhesController : Controller
    {
        private jlsEntitiesFinanceiro db = new jlsEntitiesFinanceiro();

        // GET: VendaDetalhes
        public ActionResult Index()
        {
            var vendaDetalhe = db.VendaDetalhe.Include(v => v.Produto).Include(v => v.VendaRegistro);
            return View(vendaDetalhe.ToList());
        }

        // GET: VendaDetalhes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaDetalhe vendaDetalhe = db.VendaDetalhe.Find(id);
            if (vendaDetalhe == null)
            {
                return HttpNotFound();
            }
            return View(vendaDetalhe);
        }

        // GET: VendaDetalhes/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao");
            ViewBag.VendaRegistroId = new SelectList(db.VendaRegistro, "Id", "Id");
            return View();
        }

        // POST: VendaDetalhes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendaRegistroId,ProdutoId,Qtd,ValorUnitario,ValorTotal,Ativo")] VendaDetalhe vendaDetalhe)
        {
            if (ModelState.IsValid)
            {
                db.VendaDetalhe.Add(vendaDetalhe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao", vendaDetalhe.ProdutoId);
            ViewBag.VendaRegistroId = new SelectList(db.VendaRegistro, "Id", "Id", vendaDetalhe.VendaRegistroId);
            return View(vendaDetalhe);
        }

        // GET: VendaDetalhes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaDetalhe vendaDetalhe = db.VendaDetalhe.Find(id);
            if (vendaDetalhe == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao", vendaDetalhe.ProdutoId);
            ViewBag.VendaRegistroId = new SelectList(db.VendaRegistro, "Id", "Id", vendaDetalhe.VendaRegistroId);
            return View(vendaDetalhe);
        }

        // POST: VendaDetalhes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendaRegistroId,ProdutoId,Qtd,ValorUnitario,ValorTotal,Ativo")] VendaDetalhe vendaDetalhe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendaDetalhe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Descricao", vendaDetalhe.ProdutoId);
            ViewBag.VendaRegistroId = new SelectList(db.VendaRegistro, "Id", "Id", vendaDetalhe.VendaRegistroId);
            return View(vendaDetalhe);
        }

        // GET: VendaDetalhes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaDetalhe vendaDetalhe = db.VendaDetalhe.Find(id);
            if (vendaDetalhe == null)
            {
                return HttpNotFound();
            }
            return View(vendaDetalhe);
        }

        // POST: VendaDetalhes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendaDetalhe vendaDetalhe = db.VendaDetalhe.Find(id);
            db.VendaDetalhe.Remove(vendaDetalhe);
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
