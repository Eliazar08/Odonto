using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Odonto.Models;

namespace Odonto.Data
{
    public class DateContext : DbContext
    {
        public DateContext (DbContextOptions<DateContext> options)
            : base(options)
        {
        }

        public DbSet<Odonto.Models.Date> Date { get; set; } = default!;
        
        public DbSet<Patient> Patients { get; set; } =default;
        public DbSet<Doctor> Doctors { get; set; }= default;
        public DbSet<Date> Dates { get; set; }= default;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
        modelBuilder.Entity<Date>()
        .HasOne(d => d.Doctor)
        .WithMany()
        .HasForeignKey(d => d.DoctorId);
        
    modelBuilder.Entity<Date>()
        .HasOne(d => d.Patient)
        .WithMany()
        .HasForeignKey(d => d.PatientId);
}
    }

}
