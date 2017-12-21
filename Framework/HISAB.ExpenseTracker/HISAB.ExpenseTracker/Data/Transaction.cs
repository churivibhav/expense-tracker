using System;

namespace HISAB.ExpenseTracker.Data
{
    public class Transaction : ITransaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Label { get; set; }
        public virtual Catagory Catagory { get; set; }
        public virtual Wallet Wallet { get; set; }

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
    }
}