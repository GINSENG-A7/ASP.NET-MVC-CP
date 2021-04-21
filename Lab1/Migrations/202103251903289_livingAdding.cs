namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class livingAdding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValueOfGuests = c.Int(nullable: false),
                        ValueOfKids = c.Int(nullable: false),
                        Settling = c.DateTime(nullable: false),
                        Eviction = c.DateTime(nullable: false),
                        NumberOfApartments = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Livings");
        }
    }
}
