using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OutReachApplication.Models
{
    public class OutReachAppDBContext:DbContext
    {
        public OutReachAppDBContext()
                   : base("name=OutReachAppDbContext")
        {
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
    }
}