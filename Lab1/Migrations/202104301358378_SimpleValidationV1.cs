namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimpleValidationV1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApartmentTypes", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApartmentTypes", "Type", c => c.String());
        }
    }
}
