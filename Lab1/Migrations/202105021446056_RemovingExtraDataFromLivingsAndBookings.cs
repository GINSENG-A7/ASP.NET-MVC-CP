namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingExtraDataFromLivingsAndBookings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Livings", "NumberOfApartments", c => c.Int());
            AlterColumn("dbo.Bookings", "NumberOfApartments", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "NumberOfApartments", c => c.Int(nullable: false));
            AlterColumn("dbo.Livings", "NumberOfApartments", c => c.Int(nullable: false));
        }
    }
}
