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
            // modelBuilder.Entity<Author>().ToTable("Authors");
            // modelBuilder.Entity<Author>().HasKey(a => a.Id);
        }


        public void SeedData()
        {
            if (!ThemeModes.Any())
            {
                ThemeModes.AddRange(
                    new ThemeMode { CreatedDate = DateTime.Now, Description = "Dark", Id = Guid.NewGuid(), Mode = (int)Portfolio.Common.Enum.ThemeMode.Dark, Status = (int)Portfolio.Common.Enum.StatusEnum.Active },
                    new ThemeMode { CreatedDate = DateTime.Now, Description = "Light", Id = Guid.NewGuid(), Mode = (int)Portfolio.Common.Enum.ThemeMode.Light, Status = (int)Portfolio.Common.Enum.StatusEnum.Passive }
                );
                SaveChanges();
            }
        }

        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Educations> Educations { get; set; }
        public DbSet<HobbiesAndInterests> HobbiesAndInterests { get; set; }
        public DbSet<JobExperiences> JobExperiences { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<ProjectsDefinitions> ProjectsDefinitions { get; set; }
        public DbSet<SeminarsAndCourses> SeminarsAndCourses { get; set; }
        public DbSet<TechnicalSkills> TechnicalSkills { get; set; }
        public DbSet<ThemeMode> ThemeModes { get; set; }
    }
}
