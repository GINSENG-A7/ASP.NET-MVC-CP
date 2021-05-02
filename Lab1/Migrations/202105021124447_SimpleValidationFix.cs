namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimpleValidationFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "Photo", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceTypes", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceTypes", "Type", c => c.String());
            AlterColumn("dbo.Photos", "Photo", c => c.String());
        }
    }
}
