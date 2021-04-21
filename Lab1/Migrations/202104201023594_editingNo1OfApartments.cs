namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editingNo1OfApartments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Apartments", "Number");
        }
    }
}
