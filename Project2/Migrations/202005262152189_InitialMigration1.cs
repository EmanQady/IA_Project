namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        added_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.product_id)
                .ForeignKey("dbo.Product", t => t.product_id)
                .Index(t => t.product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "product_id", "dbo.Product");
            DropIndex("dbo.Cart", new[] { "product_id" });
            DropTable("dbo.Cart");
        }
    }
}
