using System.Data.Entity;
using HISAB.ExpenseTracker.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;

namespace HISAB.ExpenseTracker.Models
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public ApplicationDbContext()
            : base("MyContext", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}