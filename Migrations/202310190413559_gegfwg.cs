namespace TiendaZapatillas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gegfwg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        ImagePath = c.String(),
                        UnitPrice = c.Double(nullable: false),
                        CategoryID = c.Int(),
                        stock = c.Int(),
                        vendido = c.Int(),
                        GeneroCategory_GenCategoryID = c.Int(),
                        TypeCategory_TypeCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.GeneroCategories", t => t.GeneroCategory_GenCategoryID)
                .ForeignKey("dbo.TypeCategories", t => t.TypeCategory_TypeCategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.GeneroCategory_GenCategoryID)
                .Index(t => t.TypeCategory_TypeCategoryID);
            
            CreateTable(
                "dbo.GeneroCategories",
                c => new
                    {
                        GenCategoryID = c.Int(nullable: false, identity: true),
                        GeneroName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.GenCategoryID);
            
            CreateTable(
                "dbo.TypeCategories",
                c => new
                    {
                        TypeCategoryID = c.Int(nullable: false, identity: true),
                        TypeCategoryName = c.String(nullable: false, maxLength: 100),
                        TypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.TypeCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TypeCategory_TypeCategoryID", "dbo.TypeCategories");
            DropForeignKey("dbo.Products", "GeneroCategory_GenCategoryID", "dbo.GeneroCategories");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "TypeCategory_TypeCategoryID" });
            DropIndex("dbo.Products", new[] { "GeneroCategory_GenCategoryID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.TypeCategories");
            DropTable("dbo.GeneroCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
