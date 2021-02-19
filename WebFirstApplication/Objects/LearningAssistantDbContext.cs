using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.Migrations;
using WebFirstApplication.Objects;

namespace WebFirstApplication.objects
{
    public class LearningAssistantDbContext : DbContext
    {
        public LearningAssistantDbContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<DailyNote> DailyNotes { get; set; }
        public DbSet<StudentCourses> StudentCourse { get; set; }


        public DbSet<UploadedDocuments> UploadedDocuments { get; set; }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}
