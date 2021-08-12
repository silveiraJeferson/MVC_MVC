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
    public class VendaRegistrosController : Controller
    {
        private jlsEntitiesFinanceiro db = new jlsEntitiesFinanceiro();

        // GET: VendaRegistros
        public ActionResult Index()
        {
            var vendaRegistro = db.VendaRegistro.Include(v => v.Cliente).Include(v => v.Funcionario).Include(v => v.TipoPagamento);
            return View(vendaRegistro.ToList());
        }

        // GET: VendaRegistros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaRegistro vendaRegistro = db.VendaRegistro.Find(id);
            if (vendaRegistro == null)
            {
                return HttpNotFound();
            }
            return View(vendaRegistro);
        }

        // GET: VendaRegistros/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nome");
            ViewBag.FuncionarioId = new SelectList(db.Funcionario, "Id", "Nome");
            ViewBag.TipoPagamentoId = new SelectList(db.TipoPagamento, "Id", "Descricao");
            return View();
        }

        // POST: VendaRegistros/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClienteId,FuncionarioId,TipoPagamentoId,DataVenda,ValorSugerido,Desconto,TotalVenda,Parcelas,PrimVencimento,Ativo,Recebeu,Juro,Restante,ValorFinal")] VendaRegistro vendaRegistro)
        {
            if (ModelState.IsValid)
            {
                db.VendaRegistro.Add(vendaRegistro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nome", vendaRegistro.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionario, "Id", "Nome", vendaRegistro.FuncionarioId);
            ViewBag.TipoPagamentoId = new SelectList(db.TipoPagamento, "Id", "Descricao", vendaRegistro.TipoPagamentoId);
            return View(vendaRegistro);
        }

        // GET: VendaRegistros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaRegistro vendaRegistro = db.VendaRegistro.Find(id);
            if (vendaRegistro == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nome", vendaRegistro.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionario, "Id", "Nome", vendaRegistro.FuncionarioId);
            ViewBag.TipoPagamentoId = new SelectList(db.TipoPagamento, "Id", "Descricao", vendaRegistro.TipoPagamentoId);
            return View(vendaRegistro);
        }

        // POST: VendaRegistros/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClienteId,FuncionarioId,TipoPagamentoId,DataVenda,ValorSugerido,Desconto,TotalVenda,Parcelas,PrimVencimento,Ativo,Recebeu,Juro,Restante,ValorFinal")] VendaRegistro vendaRegistro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendaRegistro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nome", vendaRegistro.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionario, "Id", "Nome", vendaRegistro.FuncionarioId);
            ViewBag.TipoPagamentoId = new SelectList(db.TipoPagamento, "Id", "Descricao", vendaRegistro.TipoPagamentoId);
            return View(vendaRegistro);
        }

        // GET: VendaRegistros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaRegistro vendaRegistro = db.VendaRegistro.Find(id);
            if (vendaRegistro == null)
            {
                return HttpNotFound();
            }
            return View(vendaRegistro);
        }

        // POST: VendaRegistros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendaRegistro vendaRegistro = db.VendaRegistro.Find(id);
            db.VendaRegistro.Remove(vendaRegistro);
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
