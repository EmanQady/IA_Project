namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "image", c => c.String(maxLength: 100));
        }
    }
}
