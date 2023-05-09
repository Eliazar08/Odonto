using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Odonto.Models;

namespace Odonto.Data
{
    public class DoctorContext : DbContext
    {
        public DoctorContext (DbContextOptions<DoctorContext> options)
            : base(options)
        {
        }

        public DbSet<Odonto.Models.Doctor> Doctor { get; set; } = default!;
    }
}
