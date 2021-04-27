namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterMergeMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "ApartmentsId", c => c.Int());
            CreateIndex("dbo.Bookings", "ApartmentsId");
            AddForeignKey("dbo.Bookings", "ApartmentsId", "dbo.Apartments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "ApartmentsId", "dbo.Apartments");
            DropIndex("dbo.Bookings", new[] { "ApartmentsId" });
            DropColumn("dbo.Bookings", "ApartmentsId");
        }
    }
}
