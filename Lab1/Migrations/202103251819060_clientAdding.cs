namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientAdding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        PassportNumber = c.String(),
                        PassportSeries = c.String(),
                        Birgthday = c.DateTime(nullable: false),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
