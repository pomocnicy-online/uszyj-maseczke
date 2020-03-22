using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UszyjMaseczke.Domain;
using UszyjMaseczke.Infrastructure.EntityMappings;
using UszyjMaseczke.Infrastructure.EntityMappings.Dungarees;
using UszyjMaseczke.Infrastructure.EntityMappings.Groceries;
using UszyjMaseczke.Infrastructure.EntityMappings.OtherCleaningMaterials;
using UszyjMaseczke.Infrastructure.EntityMappings.PsychologicalSupport;

namespace UszyjMaseczke.Infrastructure
{
    public class UszyjMaseczkeDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public UszyjMaseczkeDbContext()
        {
            
        }
        
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
            modelBuilder.ApplyConfiguration(new HelperRequestMappings());
            modelBuilder.ApplyConfiguration(new HelperMappings());
            modelBuilder.ApplyConfiguration(new MaskRequestMappings());
            modelBuilder.ApplyConfiguration(new GloveRequestMappings());
            modelBuilder.ApplyConfiguration(new GroceryRequestMappings());
            modelBuilder.ApplyConfiguration(new DungareesRequestMappings());
            modelBuilder.ApplyConfiguration(new OtherCleaningMaterialRequestMappings());
            modelBuilder.ApplyConfiguration(new PsychologicalSupportRequestMappings());
        }
    }
}