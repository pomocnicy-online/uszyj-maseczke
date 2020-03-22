using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UszyjMaseczke.Domain;
using UszyjMaseczke.Infrastructure.EntityMappings;

namespace UszyjMaseczke.Infrastructure
{
    public class UszyjMaseczkeDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public UszyjMaseczkeDbContext(DbContextOptions<UszyjMaseczkeDbContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestMappings());
            modelBuilder.ApplyConfiguration(new MedicalCentreMappings());
        }
    }
}