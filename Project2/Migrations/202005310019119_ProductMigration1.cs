namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "price", c => c.Single(nullable: false));
        }
    }
}
