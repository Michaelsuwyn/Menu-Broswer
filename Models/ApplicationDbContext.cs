using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foods.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Rest> Rests { get; set; }
        public DbSet<RestFood> RestFoods { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestFood>()
                .HasKey(x => new { x.FoodId, x.RestId });
            //modelBuilder.Entity<RestFood>()
            //    .HasKey(bc => new { bc.FoodId, bc.RestId });

            //modelBuilder.Entity<RestFood>()
            //    .HasOne(bc => bc.Food)
            //    .WithMany(b => b.RestFoods)
            //    .HasForeignKey(bc => bc.FoodId);

            //modelBuilder.Entity<RestFood>()
            //    .HasOne(bc => bc.Rest)
            //    .WithMany(c => c.RestFoods)
            //    .HasForeignKey(bc => bc.RestId);
        }
    }

}
