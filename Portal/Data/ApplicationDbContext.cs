using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Models;

namespace Portal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Leadership> Leaderships { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Choices> Choices { get; set; }
        public DbSet<MeetAMember> MeetAMembers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<VolunteerEvent> VolunteerEvents { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
    }
}
