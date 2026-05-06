using System.ComponentModel.DataAnnotations;
using StudentRecordSystem.Models;
using StudentRecordSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
// using MessagingPlatformBackend.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace StudentRecordSystem.Data
{
    public class StudentRecordDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public StudentRecordDbContext(DbContextOptions<StudentRecordDbContext> options) : base(options)
        {

        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<ModuleInstructor>().HasKey(mi => new { mi.ModuleId, mi.InstructorId });

            modelBuilder.Entity<User>().ToTable("Users");  
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Instructor>().ToTable("Instructors");
            Seed(modelBuilder);
        }

        public void Seed(ModelBuilder builder)
        {
           List<IdentityRole> identityRoles = new List<IdentityRole>
            {
                new IdentityRole {
                    Id = Guid.NewGuid().ToString(), 
                    Name = "Admin", 
                    NormalizedName = "ADMIN", 
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole {
                    Id = Guid.NewGuid().ToString(), 
                    Name = "Instructor", 
                    NormalizedName = "INSTRUCTOR", 
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole {
                    Id = Guid.NewGuid().ToString(), 
                    Name = "Student", 
                    NormalizedName = "STUDENT", 
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            };
            builder.Entity<IdentityRole>().HasData(identityRoles); 
        }
    }
}