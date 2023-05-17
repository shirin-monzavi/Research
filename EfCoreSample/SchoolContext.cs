using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Initial Catalog=SchoolDB;Integrated Security=true;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(s =>
            {
                s.HasKey(s => s.StudentId);
                s.Property(s => s.StudentId).ValueGeneratedNever();
                s.Property(s => s.Name).IsRequired();
                s.HasOne<Grade>().WithMany().HasForeignKey(g => g.GradeId);
             
            });

            modelBuilder.Entity<Course>(c =>
            {
                c.HasKey(c => c.CourseId);
                c.Property(c=>c.CourseId).ValueGeneratedNever();
                c.Property(c=>c.CourseName).IsRequired();
            });

            modelBuilder.Entity<Grade>(g => {
                g.HasKey(g => g.GradeId);
                g.Property(g => g.Section);
                g.Property(g=>g.GradeName).IsRequired();
            });

            modelBuilder.Entity<Address>(a =>
            {
                a.HasKey(a => a.AddressId);
                a.Property(a=>a.Name).IsRequired();
                a.Property(a=>a.StudentAddress).IsRequired();
                a.HasOne<Student>().WithOne().HasForeignKey<Address>(x=>x.IdOfStudent);
            });

            modelBuilder.Entity<StudentCourse>(sc =>
            {
                sc.HasKey(sc => new { sc.IdOfCourse, sc.IdOfStudent });
                sc.HasOne<Student>().WithMany().HasForeignKey(s => s.IdOfStudent);
                sc.HasOne<Course>().WithMany().HasForeignKey(c => c.IdOfCourse);
            });

        }

        //entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
    }
}
