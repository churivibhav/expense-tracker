using HISAB.ExpenseTracker.Models;
using Microsoft.AspNet.Identity;

namespace HISAB.ExpenseTracker.Data
{
    public class Catagory : ICatagory
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public TransactionType Type { get; set; }
        public virtual ApplicationUser User { get; set; }

        IUser ICatagory.User
        {
            get { return this.User; }
            set { this.User = value as ApplicationUser; }
        }
    }
}