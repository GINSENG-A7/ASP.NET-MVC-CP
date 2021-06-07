namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CapacityColumnInApartmentTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApartmentTypes", "Capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApartmentTypes", "Capacity");
        }
    }
}
