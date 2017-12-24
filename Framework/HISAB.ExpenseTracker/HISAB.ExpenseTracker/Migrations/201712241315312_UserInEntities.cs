namespace HISAB.ExpenseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catagories", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Transactions", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Wallets", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Catagories", "User_Id");
            CreateIndex("dbo.Transactions", "User_Id");
            CreateIndex("dbo.Wallets", "User_Id");
            AddForeignKey("dbo.Catagories", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Wallets", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallets", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Catagories", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Wallets", new[] { "User_Id" });
            DropIndex("dbo.Transactions", new[] { "User_Id" });
            DropIndex("dbo.Catagories", new[] { "User_Id" });
            DropColumn("dbo.Wallets", "User_Id");
            DropColumn("dbo.Transactions", "User_Id");
            DropColumn("dbo.Catagories", "User_Id");
        }
    }
}
