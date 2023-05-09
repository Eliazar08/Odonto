using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Odonto.Models;

namespace Odonto.Data
{
    public class PatientContext : DbContext
    {
       
        public PatientContext (DbContextOptions<PatientContext> options)
            : base(options)
        {
        }

        public DbSet<Odonto.Models.Patient> Patient { get; set; } = default!;
        public DbSet<Patient> Patients { get; set; } =default;
        public DbSet<Doctor> Doctors { get; set; }= default;
        public DbSet<Date> Dates { get; set; }= default;

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Date>()
            .HasOne(d => d.Patient)
            .WithMany(p => p.Dates)
            .HasForeignKey(d => d.PatientId);

        modelBuilder.Entity<Date>()
            .HasOne(d => d.Doctor)
            .WithMany(p => p.Dates)
            .HasForeignKey(d => d.DoctorId);
    }
    }
}
