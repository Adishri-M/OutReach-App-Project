namespace OutReachApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrimaryKeyColumn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Attendances");
            DropPrimaryKey("dbo.Feedbacks");
            AddColumn("dbo.Attendances", "PK_AttendanceId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Feedbacks", "PK_FeedbackId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Attendances", "VolunteerId", c => c.String(nullable: false));
            AlterColumn("dbo.Feedbacks", "VolunteerId", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Attendances", "PK_AttendanceId");
            AddPrimaryKey("dbo.Feedbacks", "PK_FeedbackId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Feedbacks");
            DropPrimaryKey("dbo.Attendances");
            AlterColumn("dbo.Feedbacks", "VolunteerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Attendances", "VolunteerId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Feedbacks", "PK_FeedbackId");
            DropColumn("dbo.Attendances", "PK_AttendanceId");
            AddPrimaryKey("dbo.Feedbacks", "VolunteerId");
            AddPrimaryKey("dbo.Attendances", "VolunteerId");
        }
    }
}
