Create Database OutReachApplication

use OutReachApplication

---Admin Table

Create table Admins (AdminId int not null Primary Key identity(1,1),AdminPassword varchar(Max))

insert into Admins(AdminPassword) values ('Admin@123')

Select * from Admins

---Volunteer Table

Create table Volunteers(FirstName nvarchar(25) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	DOB Datetime,
	Gender nvarchar(Max) NOT NULL,
	ContactNumber nvarchar(10) NOT NULL,
	VolunteerId int Primary Key IDENTITY,
	VolunteerPassword nvarchar(Max) NOT NULL)

Select * from Volunteers

Create table EventDetails(EventId int Primary Key Identity(1,1),
      EventType nvarchar(Max) not null,
	  Activity nvarchar(Max) not null,
	  Description nvarchar(Max),
	  Place nvarchar(Max) not null,
	  Date datetime,
	  ContactNumber nvarchar(10) not null,
	  NoOfVolunteers int not null);

Select * from EventDetails

Create table Attendances(VolunteerId int primary key identity not null,
      Name nvarchar(40) not null,
	  EventName nvarchar(Max) not null,
	  DOE datetime,
	  Status nvarchar(Max) not null);

Select * from Attendances

Create table Feedbacks(VolunteerId int Primary key,
      FirstName nvarchar(Max),
	  LastName nvarchar(Max),
	  Are_you_satisfied_for_this_Event nvarchar(Max),
	  Have_you_faced_any_difficulties_in_this_Event nvarchar(Max),
	  Do_you_think_the_duration_of_the_event_was_good_enough_as_per_your_expectation nvarchar(Max),
	  Did_the_event_content_and_delivery_meet_your_expectation nvarchar(Max),
	  Do_you_like_to_recommand_this_event_to_someone nvarchar(Max));

Select * from Feedbacks