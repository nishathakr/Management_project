using Microsoft.EntityFrameworkCore;
using SchoolManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<StudentInfo> StudentSubjects { get; set; }
        public DbSet<SubjectLanguage> SubjectLanguages { get; set; }
        //public DbSet<TeacherInfo> TeachersInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
        }
        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, Name = "English" },
                new Language { Id = 2, Name = "Hindi" },
                new Language { Id = 3, Name = "Spenish" },
                new Language { Id = 4, Name = "Arbi" }
            );
        }
    }
}
