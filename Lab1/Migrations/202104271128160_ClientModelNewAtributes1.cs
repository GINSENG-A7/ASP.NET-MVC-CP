namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientModelNewAtributes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livings", "NumberOfApartments", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "NumberOfApartments", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "PassportNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "PassportSeries", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Telephone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Telephone", c => c.String());
            AlterColumn("dbo.Clients", "PassportSeries", c => c.String());
            AlterColumn("dbo.Clients", "PassportNumber", c => c.String());
            AlterColumn("dbo.Clients", "Name", c => c.String());
            AlterColumn("dbo.Clients", "Surname", c => c.String());
            DropColumn("dbo.Bookings", "NumberOfApartments");
            DropColumn("dbo.Livings", "NumberOfApartments");
        }
    }
}
