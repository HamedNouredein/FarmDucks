using Microsoft.EntityFrameworkCore;
using FarmDucks.Models;

namespace FarmDucks.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
       public DbSet<Duck> Ducks { get; set; }
       public DbSet<Cycle> Cycles { get; set; }
       public DbSet<Farm> Farms { get; set; }
       public DbSet<Vaccine> Vaccines { get; set; }
       public DbSet<CycleVaccine> CycleVaccines { get;set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تحديد العلاقة many-to-many بين اللقاحات والدورات باستخدام جدول الوسيط CycleVaccine
            modelBuilder.Entity<CycleVaccine>()
                .HasKey(cv => new { cv.CycleId, cv.VaccineId });

            modelBuilder.Entity<CycleVaccine>()
                .HasOne(cv => cv.Cycle)
                .WithMany(c => c.CycleVaccines)
                .HasForeignKey(cv => cv.CycleId);

            modelBuilder.Entity<CycleVaccine>()
                .HasOne(cv => cv.Vaccine)
                .WithMany(v => v.CycleVaccines)
                .HasForeignKey(cv => cv.VaccineId);
        }

    }

}
