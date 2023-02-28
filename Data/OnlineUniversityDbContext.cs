using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_3_4.Entities.Data
{
    internal class OnlineUniversityDbContext : DbContext
    {


        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(eb =>
            {
                eb.HasKey(e => e.CourseId);

                eb.Property(e => e.CourseName).HasMaxLength(200).IsRequired();

                eb.HasMany(c => c.Modules)
                .WithOne(m => m.Course)
                .HasForeignKey(m => m.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Module>(eb => 
            {
                eb.HasKey(e => e.ModuleId);

                eb.Property(e => e.ModuleName)
                        .HasMaxLength(200)
                        .IsRequired();

                eb.HasOne(m => m.Course)
                .WithMany(c => c.Modules)
                .HasForeignKey(m => m.CourseId);
            
            });

            modelBuilder.Entity<Student>(eb =>
            {
                eb.HasKey(e => e.StudentId);
                
                eb.Property(e => e.FirstName)
                         .HasMaxLength(50)
                         .IsRequired();

                eb.Property(e => e.LastName)
                        .HasMaxLength(50)
                        .IsRequired();

                eb.Property(e => e.BirthDate)
                        .IsRequired();

                eb.HasMany(s => s.EnrolledCourses)
                .WithMany(c => c.Students);

                eb.HasMany(s => s.CompletedCourses)
                .WithMany(c => c.Students);

            });

            modelBuilder.Entity<StudentGrade>(eb => 
            {
                eb.HasKey(e => new { e.StudentId, e.ModuleId });

                eb.ToTable(t => t.HasCheckConstraint("CK_ModuleGrade_Grade", "[Grade] BETWEEN 3 AND 5"));

                eb.HasOne(sg => sg.Student)
                    .WithMany(s => s.StudentGrades)
                    .HasForeignKey(sg => sg.StudentId);
                eb.HasOne(sg => sg.Module)
                    .WithMany(m => m.StudentGrades)
                    .HasForeignKey(sg => sg.ModuleId);

            });

        }

    }
}
