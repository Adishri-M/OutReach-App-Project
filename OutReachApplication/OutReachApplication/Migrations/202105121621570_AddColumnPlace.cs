namespace OutReachApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnPlace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "Place", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendances", "Place");
        }
    }
}
