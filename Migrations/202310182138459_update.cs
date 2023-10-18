namespace TiendaZapatillas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Products", "GeneroCategory_GenCategoryID", c => c.Int());
            AddColumn("dbo.Products", "TypeCategory_TypeCategoryID", c => c.Int());
            CreateIndex("dbo.Products", "GeneroCategory_GenCategoryID");
            CreateIndex("dbo.Products", "TypeCategory_TypeCategoryID");
            AddForeignKey("dbo.Products", "GeneroCategory_GenCategoryID", "dbo.GeneroCategories", "GenCategoryID");
            AddForeignKey("dbo.Products", "TypeCategory_TypeCategoryID", "dbo.TypeCategories", "TypeCategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TypeCategory_TypeCategoryID", "dbo.TypeCategories");
            DropForeignKey("dbo.Products", "GeneroCategory_GenCategoryID", "dbo.GeneroCategories");
            DropIndex("dbo.Products", new[] { "TypeCategory_TypeCategoryID" });
            DropIndex("dbo.Products", new[] { "GeneroCategory_GenCategoryID" });
            DropColumn("dbo.Products", "TypeCategory_TypeCategoryID");
            DropColumn("dbo.Products", "GeneroCategory_GenCategoryID");
            DropTable("dbo.TypeCategories");
            DropTable("dbo.GeneroCategories");
        }
    }
}
