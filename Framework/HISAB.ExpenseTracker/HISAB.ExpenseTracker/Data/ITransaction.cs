using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity;

namespace HISAB.ExpenseTracker.Data
{
    public interface ITransaction : IEntity
    {
        TransactionType Type { get; set; }
        DateTime Date { get; set; }
        ICatagory Catagory { get; set; }
        string Label { get; set; }
        IWallet Wallet { get; set; }
        IUser User { get; set; }
        decimal Amount { get; set; }
    }
}
