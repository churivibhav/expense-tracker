namespace HISAB.ExpenseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameToWallet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wallets", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wallets", "Name");
        }
    }
}
