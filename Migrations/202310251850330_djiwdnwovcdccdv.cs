namespace TiendaZapatillas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class djiwdnwovcdccdv : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        IDCARD = c.Int(nullable: false, identity: true),
                        NameCard = c.String(),
                        CardNumber = c.String(),
                        ExpDate = c.String(),
                        CVV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDCARD);
            
            CreateTable(
                "dbo.depositos",
                c => new
                    {
                        DepID = c.Int(nullable: false, identity: true),
                        DepName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        ImagePath = c.String(),
                        ubicacion = c.String(),
                    })
                .PrimaryKey(t => t.DepID);
            
            CreateTable(
                "dbo.prodendeps",
                c => new
                    {
                        IngID = c.Int(nullable: false, identity: true),
                        Observaciones = c.String(),
                        cantingreso = c.Int(nullable: false),
                        Depositos_DepID = c.Int(),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.IngID)
                .ForeignKey("dbo.depositos", t => t.Depositos_DepID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Depositos_DepID)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        ImagePath = c.String(),
                        UnitPrice = c.Double(nullable: false),
                        MarcaID = c.Int(),
                        GenCategoryID = c.Int(),
                        TypeCategoryID = c.Int(),
                        stock = c.Int(),
                        vendido = c.Int(),
                        Visible = c.Boolean(nullable: false),
                        Depositos_DepID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.depositos", t => t.Depositos_DepID)
                .ForeignKey("dbo.GeneroCategories", t => t.GenCategoryID)
                .ForeignKey("dbo.Marcas", t => t.MarcaID)
                .ForeignKey("dbo.TypeCategories", t => t.TypeCategoryID)
                .Index(t => t.MarcaID)
                .Index(t => t.GenCategoryID)
                .Index(t => t.TypeCategoryID)
                .Index(t => t.Depositos_DepID);
            
            CreateTable(
                "dbo.Detalles_Movimientos",
                c => new
                    {
                        ID_Det_Movimientoss = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        precio = c.Int(),
                        factid = c.Int(),
                        movimientos_ID_Movimiento = c.Int(),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Det_Movimientoss)
                .ForeignKey("dbo.movimientos", t => t.movimientos_ID_Movimiento)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.movimientos_ID_Movimiento)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.movimientos",
                c => new
                    {
                        ID_Movimiento = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        stringn = c.String(),
                        descripcion = c.String(),
                        importe = c.Int(),
                        fechamovimiento = c.String(),
                        dateTime = c.DateTime(nullable: false),
                        ProvID = c.Int(),
                        Pagado = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID_Movimiento);
            
            CreateTable(
                "dbo.GeneroCategories",
                c => new
                    {
                        GenCategoryID = c.Int(nullable: false, identity: true),
                        GeneroName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.GenCategoryID);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        MarcaID = c.Int(nullable: false, identity: true),
                        MarcaName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        paisorigen = c.String(),
                        Imagen_marca = c.String(),
                        paginaweb_marca = c.String(),
                    })
                .PrimaryKey(t => t.MarcaID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        totalprod = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(),
                        Username = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(maxLength: 24),
                        Email = c.String(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.TypeCategories",
                c => new
                    {
                        TypeCategoryID = c.Int(nullable: false, identity: true),
                        TypeCategoryName = c.String(nullable: false, maxLength: 100),
                        TypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.TypeCategoryID);
            
            CreateTable(
                "dbo.historials",
                c => new
                    {
                        idhist = c.Int(nullable: false, identity: true),
                        cant = c.Int(),
                        ingegr = c.String(),
                        dateTime = c.DateTime(nullable: false),
                        ProductName = c.String(),
                        DepID = c.Int(),
                    })
                .PrimaryKey(t => t.idhist)
                .ForeignKey("dbo.depositos", t => t.DepID)
                .Index(t => t.DepID);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        CartId = c.String(),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.historials", "DepID", "dbo.depositos");
            DropForeignKey("dbo.Products", "TypeCategoryID", "dbo.TypeCategories");
            DropForeignKey("dbo.prodendeps", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "MarcaID", "dbo.Marcas");
            DropForeignKey("dbo.Products", "GenCategoryID", "dbo.GeneroCategories");
            DropForeignKey("dbo.Detalles_Movimientos", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Detalles_Movimientos", "movimientos_ID_Movimiento", "dbo.movimientos");
            DropForeignKey("dbo.Products", "Depositos_DepID", "dbo.depositos");
            DropForeignKey("dbo.prodendeps", "Depositos_DepID", "dbo.depositos");
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropIndex("dbo.historials", new[] { "DepID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Detalles_Movimientos", new[] { "Product_ProductID" });
            DropIndex("dbo.Detalles_Movimientos", new[] { "movimientos_ID_Movimiento" });
            DropIndex("dbo.Products", new[] { "Depositos_DepID" });
            DropIndex("dbo.Products", new[] { "TypeCategoryID" });
            DropIndex("dbo.Products", new[] { "GenCategoryID" });
            DropIndex("dbo.Products", new[] { "MarcaID" });
            DropIndex("dbo.prodendeps", new[] { "Product_ProductID" });
            DropIndex("dbo.prodendeps", new[] { "Depositos_DepID" });
            DropTable("dbo.CartItems");
            DropTable("dbo.historials");
            DropTable("dbo.TypeCategories");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Marcas");
            DropTable("dbo.GeneroCategories");
            DropTable("dbo.movimientos");
            DropTable("dbo.Detalles_Movimientos");
            DropTable("dbo.Products");
            DropTable("dbo.prodendeps");
            DropTable("dbo.depositos");
            DropTable("dbo.Cards");
        }
    }
}
