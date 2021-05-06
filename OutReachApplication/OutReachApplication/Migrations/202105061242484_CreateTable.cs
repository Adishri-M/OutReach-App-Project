namespace OutReachApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
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
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Activity = c.String(nullable: false),
                        Description = c.String(),
                        Place = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ContactNumber = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.EventId);
            
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
            DropTable("dbo.Events");
            DropTable("dbo.Admins");
        }
    }
}
