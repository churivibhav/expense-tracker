using System;
using System.Collections.Generic;
using System.Text;

namespace HISAB.ExpenseTracker.Data
{
    public interface IWallet : IEntity
    {
        string Name { get; set; }
        decimal Balance { get; set; }
    }
}
