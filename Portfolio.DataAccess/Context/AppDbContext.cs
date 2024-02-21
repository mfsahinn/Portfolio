using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Author>().HasKey(a => a.Id);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Educations> Educations { get; set; }
        public DbSet<HobbiesAndInterests> HobbiesAndInterests { get; set; }
        public DbSet<JobExperiences> JobExperiences { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<ProjectsDefinitions> ProjectsDefinitions { get; set; }
        public DbSet<SeminarsAndCourses> SeminarsAndCourses { get; set; }
        public DbSet<TechnicalSkills> TechnicalSkills { get; set; }
    }
}
