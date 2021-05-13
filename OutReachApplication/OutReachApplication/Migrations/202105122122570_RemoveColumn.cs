namespace OutReachApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventDetails", "Attendance_PK_AttendanceId", "dbo.Attendances");
            DropIndex("dbo.EventDetails", new[] { "Attendance_PK_AttendanceId" });
            DropColumn("dbo.EventDetails", "Attendance_PK_AttendanceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventDetails", "Attendance_PK_AttendanceId", c => c.Int());
            CreateIndex("dbo.EventDetails", "Attendance_PK_AttendanceId");
            AddForeignKey("dbo.EventDetails", "Attendance_PK_AttendanceId", "dbo.Attendances", "PK_AttendanceId");
        }
    }
}
