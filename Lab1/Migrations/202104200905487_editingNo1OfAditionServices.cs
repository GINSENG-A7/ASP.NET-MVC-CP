namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editingNo1OfAditionServices : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AditionServices", "DateOfService", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AditionServices", "DateOfService");
        }
    }
}
