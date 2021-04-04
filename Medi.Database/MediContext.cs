using Medi.Core.Domain;
using Microsoft.EntityFrameworkCore;

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
        
        public DbSet<Doctor> Doctors { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}