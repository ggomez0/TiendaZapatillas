namespace TiendaZapatillas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fdvwefvfvddd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_CategoryName", "dbo.Categories");
            DropForeignKey("dbo.Products", "GeneroCategory_GeneroName", "dbo.GeneroCategories");
            DropForeignKey("dbo.Products", "TypeCategory_TypeCategoryName", "dbo.TypeCategories");
            DropIndex("dbo.Products", new[] { "Category_CategoryName" });
            DropIndex("dbo.Products", new[] { "GeneroCategory_GeneroName" });
            DropIndex("dbo.Products", new[] { "TypeCategory_TypeCategoryName" });
            DropColumn("dbo.Products", "CategoryID");
            DropColumn("dbo.Products", "GenCategoryID");
            DropColumn("dbo.Products", "TypeCategoryID");
            RenameColumn(table: "dbo.Products", name: "Category_CategoryName", newName: "CategoryID");
            RenameColumn(table: "dbo.Products", name: "GeneroCategory_GeneroName", newName: "GenCategoryID");
            RenameColumn(table: "dbo.Products", name: "TypeCategory_TypeCategoryName", newName: "TypeCategoryID");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.GeneroCategories");
            DropPrimaryKey("dbo.TypeCategories");
            AlterColumn("dbo.Categories", "CategoryID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "ProductID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "CategoryID", c => c.Int());
            AlterColumn("dbo.Products", "GenCategoryID", c => c.Int());
            AlterColumn("dbo.Products", "TypeCategoryID", c => c.Int());
            AlterColumn("dbo.GeneroCategories", "GenCategoryID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TypeCategories", "TypeCategoryID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "CategoryID");
            AddPrimaryKey("dbo.Products", "ProductID");
            AddPrimaryKey("dbo.GeneroCategories", "GenCategoryID");
            AddPrimaryKey("dbo.TypeCategories", "TypeCategoryID");
            CreateIndex("dbo.Products", "CategoryID");
            CreateIndex("dbo.Products", "GenCategoryID");
            CreateIndex("dbo.Products", "TypeCategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Products", "GenCategoryID", "dbo.GeneroCategories", "GenCategoryID");
            AddForeignKey("dbo.Products", "TypeCategoryID", "dbo.TypeCategories", "TypeCategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TypeCategoryID", "dbo.TypeCategories");
            DropForeignKey("dbo.Products", "GenCategoryID", "dbo.GeneroCategories");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "TypeCategoryID" });
            DropIndex("dbo.Products", new[] { "GenCategoryID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropPrimaryKey("dbo.TypeCategories");
            DropPrimaryKey("dbo.GeneroCategories");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.TypeCategories", "TypeCategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.GeneroCategories", "GenCategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "TypeCategoryID", c => c.String(maxLength: 100));
            AlterColumn("dbo.Products", "GenCategoryID", c => c.String(maxLength: 100));
            AlterColumn("dbo.Products", "CategoryID", c => c.String(maxLength: 100));
            AlterColumn("dbo.Products", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "CategoryID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TypeCategories", "TypeCategoryName");
            AddPrimaryKey("dbo.GeneroCategories", "GeneroName");
            AddPrimaryKey("dbo.Products", "ProductName");
            AddPrimaryKey("dbo.Categories", "CategoryName");
            RenameColumn(table: "dbo.Products", name: "TypeCategoryID", newName: "TypeCategory_TypeCategoryName");
            RenameColumn(table: "dbo.Products", name: "GenCategoryID", newName: "GeneroCategory_GeneroName");
            RenameColumn(table: "dbo.Products", name: "CategoryID", newName: "Category_CategoryName");
            AddColumn("dbo.Products", "TypeCategoryID", c => c.Int());
            AddColumn("dbo.Products", "GenCategoryID", c => c.Int());
            AddColumn("dbo.Products", "CategoryID", c => c.Int());
            CreateIndex("dbo.Products", "TypeCategory_TypeCategoryName");
            CreateIndex("dbo.Products", "GeneroCategory_GeneroName");
            CreateIndex("dbo.Products", "Category_CategoryName");
            AddForeignKey("dbo.Products", "TypeCategory_TypeCategoryName", "dbo.TypeCategories", "TypeCategoryName");
            AddForeignKey("dbo.Products", "GeneroCategory_GeneroName", "dbo.GeneroCategories", "GeneroName");
            AddForeignKey("dbo.Products", "Category_CategoryName", "dbo.Categories", "CategoryName");
        }
    }
}
