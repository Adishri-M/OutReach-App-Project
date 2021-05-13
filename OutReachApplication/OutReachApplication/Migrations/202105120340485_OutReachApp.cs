namespace OutReachApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OutReachApp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminPassword = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);

            Sql("Insert into Admins values('Admin@123')");
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        VolunteerId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 40),
                        EventName = c.String(nullable: false),
                        DOE = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VolunteerId);
            
            CreateTable(
                "dbo.EventDetails",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventType = c.String(nullable: false),
                        Activity = c.String(nullable: false),
                        Description = c.String(),
                        Place = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ContactNumber = c.String(nullable: false, maxLength: 10),
                        NoOfVolunteers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        VolunteerId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Are_you_satisfied_for_this_Event = c.String(nullable: false),
                        Have_you_faced_any_difficulties_in_this_Event = c.String(nullable: false),
                        Do_you_think_the_duration_of_the_event_was_good_enough_as_per_your_expectation = c.String(nullable: false),
                        Did_the_event_content_and_delivery_meet_your_expectation = c.String(nullable: false),
                        Do_you_like_to_recommand_this_event_to_someone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VolunteerId);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        PK_VolunteerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 20),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false, maxLength: 10),
                        VolunteerId = c.String(),
                        VolunteerPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PK_VolunteerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Volunteers");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.EventDetails");
            DropTable("dbo.Attendances");
            DropTable("dbo.Admins");
        }
    }
}
