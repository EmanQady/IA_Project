namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        number_of_products = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Single(nullable: false),
                        image = c.String(maxLength: 100),
                        description = c.String(maxLength: 500),
                        category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Category", t => t.category_id, cascadeDelete: true)
                .Index(t => t.category_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "category_id", "dbo.Category");
            DropIndex("dbo.Product", new[] { "category_id" });
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
