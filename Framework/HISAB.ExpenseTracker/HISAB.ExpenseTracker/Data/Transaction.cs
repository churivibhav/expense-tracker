using System;
using HISAB.ExpenseTracker.Models;
using Microsoft.AspNet.Identity;

namespace HISAB.ExpenseTracker.Data
{
    public class Transaction : ITransaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Label { get; set; }
        public Catagory Catagory { get; set; }
        public Wallet Wallet { get; set; }
        public virtual ApplicationUser User { get; set; }
        public decimal Amount { get; set; }

        IWallet ITransaction.Wallet
        {
            get { return this.Wallet; }
            set { this.Wallet = value as Wallet; }
        }

        ICatagory ITransaction.Catagory
        {
            get { return this.Catagory; }
            set { this.Catagory = value as Catagory; }
        }

        IUser ITransaction.User
        {
            get { return this.User; }
            set { this.User = value as ApplicationUser; }
        }
    }
}