using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.objects;

namespace WebFirstApplication.Migrations
{
    public class CourseConfiguration:IEntityTypeConfiguration<Course>
    {
       public void Configure(EntityTypeBuilder<Course> builder)
       
    {
            builder.ToTable("Courses");
            builder.HasData
                (
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseName = "English",
                    CourseCode = "EN",
                    CoruseDate = DateTime.Now,
                    CoruseTime = "12:00"
                },
                new Course
                    {
                        Id = Guid.NewGuid(),
                        CourseName = "French",
                        CourseCode = "FN",
                        CoruseDate = DateTime.Now,
                        CoruseTime = "9:00"
                    },
                new Course
                     {
                         Id = Guid.NewGuid(),
                         CourseName = "Mathematic",
                         CourseCode = "MATH",
                         CoruseDate = DateTime.Now,
                         CoruseTime = "10:00"
                     }
                );
    }
    }
}
