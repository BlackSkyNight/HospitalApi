using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions options) : base(options) { }

        public DbSet<Patient> Patient { get; set; }
    }
}
