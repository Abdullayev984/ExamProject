
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLayer.Concrete.Context
{
    public class DatabaseContext:IdentityDbContext<AppUser, AppRole,int>
    {
        
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {

        }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
              modelBuilder.Entity<Lesson>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Student>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Exam>().HasQueryFilter(m => !m.IsDeleted);


            modelBuilder.Entity<Lesson>()
            .HasIndex(p => new { p.LessonCode, p.Grade })
            .IsUnique(true).HasFilter("IsDeleted=0"); ;
            modelBuilder.Entity<Exam>()
            .HasIndex(p => new { p.LessonCode, p.StudentId })
            .IsUnique(true).HasFilter("IsDeleted=0");

        }


        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }

    }
}
