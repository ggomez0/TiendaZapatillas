namespace TiendaZapatillas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fdvwefvfv : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "ProductID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Products", "ProductName");
            DropColumn("dbo.Products", "stock");
            DropColumn("dbo.Products", "vendido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "vendido", c => c.Int());
            AddColumn("dbo.Products", "stock", c => c.Int());
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "ProductID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Products", "ProductID");
        }
    }
}
