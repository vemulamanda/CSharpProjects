namespace MVCAppCodeFirstMigrationExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Fees", c => c.Single());
            AddColumn("dbo.Students", "Marks", c => c.Single());
            AddColumn("dbo.Students", "City", c => c.String());
            AddColumn("dbo.Students", "State", c => c.String());
            AddColumn("dbo.Students", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Country");
            DropColumn("dbo.Students", "State");
            DropColumn("dbo.Students", "City");
            DropColumn("dbo.Students", "Marks");
            DropColumn("dbo.Students", "Fees");
        }
    }
}
