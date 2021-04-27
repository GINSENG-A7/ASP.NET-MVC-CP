namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterMergeMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "ApartmentsId", "dbo.Apartments");
            DropIndex("dbo.Bookings", new[] { "ApartmentsId" });
            RenameColumn(table: "dbo.AditionServices", name: "ServiceTypesId", newName: "ServiceTypes_Id");
            RenameColumn(table: "dbo.Livings", name: "ApartmentsId", newName: "Apartments_Id");
            RenameColumn(table: "dbo.Livings", name: "ClientId", newName: "Client_Id");
            RenameColumn(table: "dbo.Apartments", name: "ApartmentTypeId", newName: "ApartmentType_Id");
            RenameColumn(table: "dbo.Photos", name: "ApartmentsId", newName: "Apartments_Id");
            RenameColumn(table: "dbo.Bookings", name: "ClientId", newName: "Client_Id");
            RenameIndex(table: "dbo.AditionServices", name: "IX_ServiceTypesId", newName: "IX_ServiceTypes_Id");
            RenameIndex(table: "dbo.Livings", name: "IX_ApartmentsId", newName: "IX_Apartments_Id");
            RenameIndex(table: "dbo.Livings", name: "IX_ClientId", newName: "IX_Client_Id");
            RenameIndex(table: "dbo.Apartments", name: "IX_ApartmentTypeId", newName: "IX_ApartmentType_Id");
            RenameIndex(table: "dbo.Photos", name: "IX_ApartmentsId", newName: "IX_Apartments_Id");
            RenameIndex(table: "dbo.Bookings", name: "IX_ClientId", newName: "IX_Client_Id");
            DropColumn("dbo.AditionServices", "LivingsId");
            DropColumn("dbo.Bookings", "ApartmentsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "ApartmentsId", c => c.Int());
            AddColumn("dbo.AditionServices", "LivingsId", c => c.Int());
            RenameIndex(table: "dbo.Bookings", name: "IX_Client_Id", newName: "IX_ClientId");
            RenameIndex(table: "dbo.Photos", name: "IX_Apartments_Id", newName: "IX_ApartmentsId");
            RenameIndex(table: "dbo.Apartments", name: "IX_ApartmentType_Id", newName: "IX_ApartmentTypeId");
            RenameIndex(table: "dbo.Livings", name: "IX_Client_Id", newName: "IX_ClientId");
            RenameIndex(table: "dbo.Livings", name: "IX_Apartments_Id", newName: "IX_ApartmentsId");
            RenameIndex(table: "dbo.AditionServices", name: "IX_ServiceTypes_Id", newName: "IX_ServiceTypesId");
            RenameColumn(table: "dbo.Bookings", name: "Client_Id", newName: "ClientId");
            RenameColumn(table: "dbo.Photos", name: "Apartments_Id", newName: "ApartmentsId");
            RenameColumn(table: "dbo.Apartments", name: "ApartmentType_Id", newName: "ApartmentTypeId");
            RenameColumn(table: "dbo.Livings", name: "Client_Id", newName: "ClientId");
            RenameColumn(table: "dbo.Livings", name: "Apartments_Id", newName: "ApartmentsId");
            RenameColumn(table: "dbo.AditionServices", name: "ServiceTypes_Id", newName: "ServiceTypesId");
            CreateIndex("dbo.Bookings", "ApartmentsId");
            AddForeignKey("dbo.Bookings", "ApartmentsId", "dbo.Apartments", "Id");
        }
    }
}
