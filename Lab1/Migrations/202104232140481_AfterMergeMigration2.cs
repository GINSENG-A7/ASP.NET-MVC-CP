namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterMergeMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "Booking_Id", c => c.Int());
            CreateIndex("dbo.Apartments", "Booking_Id");
            AddForeignKey("dbo.Apartments", "Booking_Id", "dbo.Bookings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Apartments", "Booking_Id", "dbo.Bookings");
            DropIndex("dbo.Apartments", new[] { "Booking_Id" });
            DropColumn("dbo.Apartments", "Booking_Id");
        }
    }
}
