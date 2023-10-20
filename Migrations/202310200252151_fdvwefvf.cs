namespace TiendaZapatillas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fdvwefvf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "GenCategoryID", "dbo.GeneroCategories");
            DropForeignKey("dbo.Products", "TypeCategoryID", "dbo.TypeCategories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "GenCategoryID" });
            DropIndex("dbo.Products", new[] { "TypeCategoryID" });
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.GeneroCategories");
            DropPrimaryKey("dbo.TypeCategories");
            AddColumn("dbo.Products", "Category_CategoryName", c => c.String(maxLength: 100));
            AddColumn("dbo.Products", "GeneroCategory_GeneroName", c => c.String(maxLength: 100));
            AddColumn("dbo.Products", "TypeCategory_TypeCategoryName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Categories", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CategoryID", c => c.Int());
            AlterColumn("dbo.Products", "GenCategoryID", c => c.Int());
            AlterColumn("dbo.Products", "TypeCategoryID", c => c.Int());
            AlterColumn("dbo.GeneroCategories", "GenCategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.TypeCategories", "TypeCategoryID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Categories", "CategoryName");
            AddPrimaryKey("dbo.GeneroCategories", "GeneroName");
            AddPrimaryKey("dbo.TypeCategories", "TypeCategoryName");
            CreateIndex("dbo.Products", "Category_CategoryName");
            CreateIndex("dbo.Products", "GeneroCategory_GeneroName");
            CreateIndex("dbo.Products", "TypeCategory_TypeCategoryName");
            AddForeignKey("dbo.Products", "Category_CategoryName", "dbo.Categories", "CategoryName");
            AddForeignKey("dbo.Products", "GeneroCategory_GeneroName", "dbo.GeneroCategories", "GeneroName");
            AddForeignKey("dbo.Products", "TypeCategory_TypeCategoryName", "dbo.TypeCategories", "TypeCategoryName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TypeCategory_TypeCategoryName", "dbo.TypeCategories");
            DropForeignKey("dbo.Products", "GeneroCategory_GeneroName", "dbo.GeneroCategories");
            DropForeignKey("dbo.Products", "Category_CategoryName", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "TypeCategory_TypeCategoryName" });
            DropIndex("dbo.Products", new[] { "GeneroCategory_GeneroName" });
            DropIndex("dbo.Products", new[] { "Category_CategoryName" });
            DropPrimaryKey("dbo.TypeCategories");
            DropPrimaryKey("dbo.GeneroCategories");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.TypeCategories", "TypeCategoryID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.GeneroCategories", "GenCategoryID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "TypeCategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "GenCategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "CategoryID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Products", "TypeCategory_TypeCategoryName");
            DropColumn("dbo.Products", "GeneroCategory_GeneroName");
            DropColumn("dbo.Products", "Category_CategoryName");
            AddPrimaryKey("dbo.TypeCategories", "TypeCategoryID");
            AddPrimaryKey("dbo.GeneroCategories", "GenCategoryID");
            AddPrimaryKey("dbo.Categories", "CategoryID");
            CreateIndex("dbo.Products", "TypeCategoryID");
            CreateIndex("dbo.Products", "GenCategoryID");
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "TypeCategoryID", "dbo.TypeCategories", "TypeCategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "GenCategoryID", "dbo.GeneroCategories", "GenCategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
    }
}
