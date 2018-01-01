using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HISAB.ExpenseTracker.Data;
using HISAB.ExpenseTracker.Data.Persistance;
using HISAB.ExpenseTracker.Models;

namespace HISAB.ExpenseTracker.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext db;
        private UnitOfWork unit;

        public TransactionsController()
        {
            db = new ApplicationDbContext();
            unit = new UnitOfWork(db);
        }

        // GET: Transactions
        public ActionResult Index()
        {
            return View(db.Transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            var model = new CreateTransactionViewModel
            {
                Date = DateTime.Today,
                Wallets = GetWalletSelectList(),
                Catagories = GetCatagoriesSelectList()
            };
            return View(model);
        }

        private List<SelectListItem> GetCatagoriesSelectList()
        {
            return unit.Repository<Catagory>().AsQueryable().Select(c => new SelectListItem { Text = c.Label, Value = c.Id.ToString() }).ToList();
        }

        private List<SelectListItem> GetWalletSelectList()
        {
            return unit.Repository<Wallet>().AsQueryable().Select(w => new SelectListItem { Text = w.Name, Value = w.Id.ToString() }).ToList();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Date,Label,Amount,CatagoryId,WalletId")] CreateTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = unit.Repository<Transaction>();
                var transaction = repo.Create();
                SetData(model, transaction);

                repo.Add(transaction);
                unit.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        private void SetData(CreateTransactionViewModel model, Transaction transaction)
        {
            transaction.Date = model.Date;
            transaction.Label = model.Label;
            transaction.Amount = model.Amount;
            transaction.Type = model.Type;

            transaction.Catagory = unit.Repository<Catagory>().Get(model.CatagoryId);
            transaction.Wallet = unit.Repository<Wallet>().Get(model.WalletId);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transaction = unit.Repository<Transaction>().Get(id.Value);// db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            var model = new CreateTransactionViewModel
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                CatagoryId = transaction.Catagory?.Id,
                Date = transaction.Date,
                Label = transaction.Label,
                Type = transaction.Type,
                WalletId = transaction.Wallet?.Id,
                Wallets = GetWalletSelectList(),
                Catagories = GetCatagoriesSelectList()
            };
            return View(model);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Date,Label,Amount,CatagoryId,WalletId")] CreateTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var transaction = unit.Repository<Transaction>().Get(model.Id);
                SetData(model, transaction);
                unit.SeAsModified(transaction);
                unit.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
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
