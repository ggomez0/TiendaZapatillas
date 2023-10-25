namespace TiendaZapatillas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jidejo : DbMigration
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
                "dbo.comprobantesdets",
                c => new
                    {
                        idcomprdet = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        precio = c.Int(),
                        factid = c.Int(),
                        Comprobantes_idcomp = c.Int(),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.idcomprdet)
                .ForeignKey("dbo.comprobantes", t => t.Comprobantes_idcomp)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Comprobantes_idcomp)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.comprobantes",
                c => new
                    {
                        idcomp = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        stringn = c.String(),
                        descripcion = c.String(),
                        importe = c.Int(),
                        fechacomprobante = c.String(),
                        dateTime = c.DateTime(nullable: false),
                        ProvID = c.Int(),
                        Pagado = c.Boolean(),
                        idcomprobante = c.Int(),
                    })
                .PrimaryKey(t => t.idcomp)
                .ForeignKey("dbo.tipocomprobantes", t => t.idcomprobante)
                .Index(t => t.idcomprobante);
            
            CreateTable(
                "dbo.tipocomprobantes",
                c => new
                    {
                        idcomprobante = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.idcomprobante);
            
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
            
            AddColumn("dbo.Products", "stock", c => c.Int());
            AddColumn("dbo.Products", "vendido", c => c.Int());
            AddColumn("dbo.Products", "Depositos_DepID", c => c.Int());
            CreateIndex("dbo.Products", "Depositos_DepID");
            AddForeignKey("dbo.Products", "Depositos_DepID", "dbo.depositos", "DepID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.historials", "DepID", "dbo.depositos");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "Depositos_DepID", "dbo.depositos");
            DropForeignKey("dbo.prodendeps", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.prodendeps", "Depositos_DepID", "dbo.depositos");
            DropForeignKey("dbo.comprobantesdets", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.comprobantes", "idcomprobante", "dbo.tipocomprobantes");
            DropForeignKey("dbo.comprobantesdets", "Comprobantes_idcomp", "dbo.comprobantes");
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropIndex("dbo.historials", new[] { "DepID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.prodendeps", new[] { "Product_ProductID" });
            DropIndex("dbo.prodendeps", new[] { "Depositos_DepID" });
            DropIndex("dbo.comprobantes", new[] { "idcomprobante" });
            DropIndex("dbo.comprobantesdets", new[] { "Product_ProductID" });
            DropIndex("dbo.comprobantesdets", new[] { "Comprobantes_idcomp" });
            DropIndex("dbo.Products", new[] { "Depositos_DepID" });
            DropColumn("dbo.Products", "Depositos_DepID");
            DropColumn("dbo.Products", "vendido");
            DropColumn("dbo.Products", "stock");
            DropTable("dbo.CartItems");
            DropTable("dbo.historials");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.prodendeps");
            DropTable("dbo.depositos");
            DropTable("dbo.tipocomprobantes");
            DropTable("dbo.comprobantes");
            DropTable("dbo.comprobantesdets");
            DropTable("dbo.Cards");
        }
    }
}
