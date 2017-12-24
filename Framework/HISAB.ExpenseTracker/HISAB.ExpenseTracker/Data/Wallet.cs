using System;
using System.Collections.Generic;
using HISAB.ExpenseTracker.Models;

namespace HISAB.ExpenseTracker.Data
{
    public class Wallet : IWallet
    {
        public Wallet()
        {
            Transactions = new List<Transaction>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public ApplicationUser User { get; set; }

        
    }
}
