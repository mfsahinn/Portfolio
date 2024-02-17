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

        // Constructor'lar birleştirildi ve IConfiguration parametresi eklendi.
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>().ToTable("Authors");

            // Author sınıfının Id özelliğinin birincil anahtar olarak belirlenmesi
            modelBuilder.Entity<Author>().HasKey(a => a.Id);

        }

      

        public DbSet<Author> Authors { get; set; }


    }
}
