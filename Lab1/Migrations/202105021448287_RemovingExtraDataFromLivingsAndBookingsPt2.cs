namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingExtraDataFromLivingsAndBookingsPt2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Livings", "NumberOfApartments");
            DropColumn("dbo.Bookings", "NumberOfApartments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "NumberOfApartments", c => c.Int());
            AddColumn("dbo.Livings", "NumberOfApartments", c => c.Int());
        }
    }
}
