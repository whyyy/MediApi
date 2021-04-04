using System.IO;
using Medi.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Medi.Database
{
    public class MediContext : DbContext
    {
        public MediContext() : base()
        {
        }
        
        public MediContext(DbContextOptions<MediContext> options):
            base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MediApiDB;Trusted_Connection=True;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
        }

        public DbSet<Doctor> Doctors { get; set; }
    }
}