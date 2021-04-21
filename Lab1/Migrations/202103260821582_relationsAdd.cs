namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationsAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AditionServices", "Living_Id", c => c.Int());
            AddColumn("dbo.AditionServices", "ServiceTypes_Id", c => c.Int());
            AddColumn("dbo.Apartments", "ApartmentType_Id", c => c.Int());
            AddColumn("dbo.Apartments", "Booking_Id", c => c.Int());
            AddColumn("dbo.Bookings", "Client_Id", c => c.Int());
            AddColumn("dbo.Livings", "Client_Id", c => c.Int());
            AddColumn("dbo.Livings", "Apartments_Id", c => c.Int());
            AddColumn("dbo.Photos", "Apartments_Id", c => c.Int());
            AlterColumn("dbo.Photos", "Photo", c => c.String());
            CreateIndex("dbo.AditionServices", "Living_Id");
            CreateIndex("dbo.AditionServices", "ServiceTypes_Id");
            CreateIndex("dbo.Livings", "Client_Id");
            CreateIndex("dbo.Livings", "Apartments_Id");
            CreateIndex("dbo.Apartments", "ApartmentType_Id");
            CreateIndex("dbo.Apartments", "Booking_Id");
            CreateIndex("dbo.Bookings", "Client_Id");
            CreateIndex("dbo.Photos", "Apartments_Id");
            AddForeignKey("dbo.AditionServices", "Living_Id", "dbo.Livings", "Id");
            AddForeignKey("dbo.Apartments", "ApartmentType_Id", "dbo.ApartmentTypes", "Id");
            AddForeignKey("dbo.Apartments", "Booking_Id", "dbo.Bookings", "Id");
            AddForeignKey("dbo.Bookings", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Livings", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Livings", "Apartments_Id", "dbo.Apartments", "Id");
            AddForeignKey("dbo.Photos", "Apartments_Id", "dbo.Apartments", "Id");
            AddForeignKey("dbo.AditionServices", "ServiceTypes_Id", "dbo.ServiceTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AditionServices", "ServiceTypes_Id", "dbo.ServiceTypes");
            DropForeignKey("dbo.Photos", "Apartments_Id", "dbo.Apartments");
            DropForeignKey("dbo.Livings", "Apartments_Id", "dbo.Apartments");
            DropForeignKey("dbo.Livings", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Bookings", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Apartments", "Booking_Id", "dbo.Bookings");
            DropForeignKey("dbo.Apartments", "ApartmentType_Id", "dbo.ApartmentTypes");
            DropForeignKey("dbo.AditionServices", "Living_Id", "dbo.Livings");
            DropIndex("dbo.Photos", new[] { "Apartments_Id" });
            DropIndex("dbo.Bookings", new[] { "Client_Id" });
            DropIndex("dbo.Apartments", new[] { "Booking_Id" });
            DropIndex("dbo.Apartments", new[] { "ApartmentType_Id" });
            DropIndex("dbo.Livings", new[] { "Apartments_Id" });
            DropIndex("dbo.Livings", new[] { "Client_Id" });
            DropIndex("dbo.AditionServices", new[] { "ServiceTypes_Id" });
            DropIndex("dbo.AditionServices", new[] { "Living_Id" });
            AlterColumn("dbo.Photos", "Photo", c => c.Binary());
            DropColumn("dbo.Photos", "Apartments_Id");
            DropColumn("dbo.Livings", "Apartments_Id");
            DropColumn("dbo.Livings", "Client_Id");
            DropColumn("dbo.Bookings", "Client_Id");
            DropColumn("dbo.Apartments", "Booking_Id");
            DropColumn("dbo.Apartments", "ApartmentType_Id");
            DropColumn("dbo.AditionServices", "ServiceTypes_Id");
            DropColumn("dbo.AditionServices", "Living_Id");
        }
    }
}
