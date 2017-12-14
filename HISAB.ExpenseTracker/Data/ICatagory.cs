namespace HISAB.ExpenseTracker.Data
{
    public interface ICatagory : IEntity
    {
        string Label { get; set; }
        TransactionType Type { get; set; }
    }
}