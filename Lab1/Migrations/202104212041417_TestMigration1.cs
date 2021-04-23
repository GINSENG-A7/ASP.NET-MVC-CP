namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Apartments", "Booking_Id", "dbo.Bookings");
            DropIndex("dbo.Apartments", new[] { "Booking_Id" });
            RenameColumn(table: "dbo.AditionServices", name: "ServiceTypes_Id", newName: "ServiceTypesId");
            RenameColumn(table: "dbo.Livings", name: "Apartments_Id", newName: "ApartmentsId");
            RenameColumn(table: "dbo.Livings", name: "Client_Id", newName: "ClientId");
            RenameColumn(table: "dbo.Apartments", name: "ApartmentType_Id", newName: "ApartmentTypeId");
            RenameColumn(table: "dbo.Photos", name: "Apartments_Id", newName: "ApartmentsId");
            RenameColumn(table: "dbo.Bookings", name: "Client_Id", newName: "ClientId");
            RenameIndex(table: "dbo.AditionServices", name: "IX_ServiceTypes_Id", newName: "IX_ServiceTypesId");
            RenameIndex(table: "dbo.Livings", name: "IX_Client_Id", newName: "IX_ClientId");
            RenameIndex(table: "dbo.Livings", name: "IX_Apartments_Id", newName: "IX_ApartmentsId");
            RenameIndex(table: "dbo.Apartments", name: "IX_ApartmentType_Id", newName: "IX_ApartmentTypeId");
            RenameIndex(table: "dbo.Photos", name: "IX_Apartments_Id", newName: "IX_ApartmentsId");
            RenameIndex(table: "dbo.Bookings", name: "IX_Client_Id", newName: "IX_ClientId");
            AddColumn("dbo.AditionServices", "LivingsId", c => c.Int());
            DropColumn("dbo.Apartments", "Booking_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Apartments", "Booking_Id", c => c.Int());
            DropColumn("dbo.AditionServices", "LivingsId");
            RenameIndex(table: "dbo.Bookings", name: "IX_ClientId", newName: "IX_Client_Id");
            RenameIndex(table: "dbo.Photos", name: "IX_ApartmentsId", newName: "IX_Apartments_Id");
            RenameIndex(table: "dbo.Apartments", name: "IX_ApartmentTypeId", newName: "IX_ApartmentType_Id");
            RenameIndex(table: "dbo.Livings", name: "IX_ApartmentsId", newName: "IX_Apartments_Id");
            RenameIndex(table: "dbo.Livings", name: "IX_ClientId", newName: "IX_Client_Id");
            RenameIndex(table: "dbo.AditionServices", name: "IX_ServiceTypesId", newName: "IX_ServiceTypes_Id");
            RenameColumn(table: "dbo.Bookings", name: "ClientId", newName: "Client_Id");
            RenameColumn(table: "dbo.Photos", name: "ApartmentsId", newName: "Apartments_Id");
            RenameColumn(table: "dbo.Apartments", name: "ApartmentTypeId", newName: "ApartmentType_Id");
            RenameColumn(table: "dbo.Livings", name: "ClientId", newName: "Client_Id");
            RenameColumn(table: "dbo.Livings", name: "ApartmentsId", newName: "Apartments_Id");
            RenameColumn(table: "dbo.AditionServices", name: "ServiceTypesId", newName: "ServiceTypes_Id");
            CreateIndex("dbo.Apartments", "Booking_Id");
            AddForeignKey("dbo.Apartments", "Booking_Id", "dbo.Bookings", "Id");
        }
    }
}
