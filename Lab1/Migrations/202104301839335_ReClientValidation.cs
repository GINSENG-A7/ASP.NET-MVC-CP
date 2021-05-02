namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReClientValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Patronymic", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Patronymic", c => c.String());
        }
    }
}
