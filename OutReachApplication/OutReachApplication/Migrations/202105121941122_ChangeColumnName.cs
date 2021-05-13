namespace OutReachApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "Attended", c => c.String(nullable: false));
            DropColumn("dbo.Attendances", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "Status", c => c.String(nullable: false));
            DropColumn("dbo.Attendances", "Attended");
        }
    }
}
