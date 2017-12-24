using Microsoft.AspNet.Identity;

namespace HISAB.ExpenseTracker.Data
{
    public interface ICatagory : IEntity
    {
        string Label { get; set; }
        TransactionType Type { get; set; }
        IUser User { get; set; }
    }
}