namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraApartmentsLinksFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Livings", "NumberOfApartments");
            DropColumn("dbo.Bookings", "NumberOfApartments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "NumberOfApartments", c => c.Int(nullable: false));
            AddColumn("dbo.Livings", "NumberOfApartments", c => c.Int(nullable: false));
        }
    }
}
