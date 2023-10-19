namespace TiendaZapatillas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jisjodff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "GeneroCategory_GenCategoryID", "dbo.GeneroCategories");
            DropForeignKey("dbo.Products", "TypeCategory_TypeCategoryID", "dbo.TypeCategories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "GeneroCategory_GenCategoryID" });
            DropIndex("dbo.Products", new[] { "TypeCategory_TypeCategoryID" });
            RenameColumn(table: "dbo.Products", name: "GeneroCategory_GenCategoryID", newName: "GenCategoryID");
            RenameColumn(table: "dbo.Products", name: "TypeCategory_TypeCategoryID", newName: "TypeCategoryID");
            AlterColumn("dbo.Products", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "GenCategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "TypeCategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryID");
            CreateIndex("dbo.Products", "GenCategoryID");
            CreateIndex("dbo.Products", "TypeCategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "GenCategoryID", "dbo.GeneroCategories", "GenCategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "TypeCategoryID", "dbo.TypeCategories", "TypeCategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TypeCategoryID", "dbo.TypeCategories");
            DropForeignKey("dbo.Products", "GenCategoryID", "dbo.GeneroCategories");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "TypeCategoryID" });
            DropIndex("dbo.Products", new[] { "GenCategoryID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            AlterColumn("dbo.Products", "TypeCategoryID", c => c.Int());
            AlterColumn("dbo.Products", "GenCategoryID", c => c.Int());
            AlterColumn("dbo.Products", "CategoryID", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "TypeCategoryID", newName: "TypeCategory_TypeCategoryID");
            RenameColumn(table: "dbo.Products", name: "GenCategoryID", newName: "GeneroCategory_GenCategoryID");
            CreateIndex("dbo.Products", "TypeCategory_TypeCategoryID");
            CreateIndex("dbo.Products", "GeneroCategory_GenCategoryID");
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "TypeCategory_TypeCategoryID", "dbo.TypeCategories", "TypeCategoryID");
            AddForeignKey("dbo.Products", "GeneroCategory_GenCategoryID", "dbo.GeneroCategories", "GenCategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
