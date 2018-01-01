using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HISAB.ExpenseTracker.Data;

namespace HISAB.ExpenseTracker.Models
{
    public class CreateTransactionViewModel
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Label { get; set; }
        public int? CatagoryId { get; set; }
        public int? WalletId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public decimal Amount { get; set; }

        public List<SelectListItem> Wallets { get; set; }
        public List<SelectListItem> Catagories { get; set; }

    }
}