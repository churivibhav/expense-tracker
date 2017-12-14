namespace HISAB.ExpenseTracker.Data
{
    public class Catagory : ICatagory
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public TransactionType Type { get; set; }
    }
}