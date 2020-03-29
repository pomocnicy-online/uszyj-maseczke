using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UszyjMaseczke.Application.Presentations;
using UszyjMaseczke.Domain.HelpOffers;
using UszyjMaseczke.Domain.MedicalCentres;
using UszyjMaseczke.Domain.Requests;
using UszyjMaseczke.Infrastructure.EntityMappings.DisinfectionMeasures;
using UszyjMaseczke.Infrastructure.EntityMappings.Gloves;
using UszyjMaseczke.Infrastructure.EntityMappings.Groceries;
using UszyjMaseczke.Infrastructure.EntityMappings.Helpers;
using UszyjMaseczke.Infrastructure.EntityMappings.HelpOffers;
using UszyjMaseczke.Infrastructure.EntityMappings.Masks;
using UszyjMaseczke.Infrastructure.EntityMappings.MedicalCentres;
using UszyjMaseczke.Infrastructure.EntityMappings.OtherCleaningMaterials;
using UszyjMaseczke.Infrastructure.EntityMappings.Others;
using UszyjMaseczke.Infrastructure.EntityMappings.Prints;
using UszyjMaseczke.Infrastructure.EntityMappings.PsychologicalSupport;
using UszyjMaseczke.Infrastructure.EntityMappings.Requests;
using UszyjMaseczke.Infrastructure.EntityMappings.SewingSupplies;
using UszyjMaseczke.Infrastructure.EntityMappings.Suits;
using UszyjMaseczke.Infrastructure.EntityMappings.Views;

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
        public DbSet<HelpOffer> HelpOffers { get; set; }
        public DbSet<MedicalCentre> MedicalCentres { get; set; }

        public DbSet<AggregatedRequestsView> AggregatedRequestsViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestMappings());
            modelBuilder.ApplyConfiguration(new MedicalCentreMappings());
            modelBuilder.ApplyConfiguration(new DisinfectionMeasureRequestMappings());
            modelBuilder.ApplyConfiguration(new DisinfectionMeasureRequestPositionMappings());
            modelBuilder.ApplyConfiguration(new SuitRequestMappings());
            modelBuilder.ApplyConfiguration(new SuitRequestPositionMappings());
            modelBuilder.ApplyConfiguration(new GloveRequestMappings());
            modelBuilder.ApplyConfiguration(new GloveRequestPositionMappings());
            modelBuilder.ApplyConfiguration(new GroceryRequestMappings());
            modelBuilder.ApplyConfiguration(new GroceryRequestPositionMappings());
            modelBuilder.ApplyConfiguration(new MaskRequestMappings());
            modelBuilder.ApplyConfiguration(new MaskRequestPositionMappings());
            modelBuilder.ApplyConfiguration(new OtherCleaningMaterialRequestMappings());
            modelBuilder.ApplyConfiguration(new OtherCleaningMaterialRequestPositionMappings());
            modelBuilder.ApplyConfiguration(new PsychologicalSupportRequestMappings());
            modelBuilder.ApplyConfiguration(new SewingSuppliesRequestMappings());
            modelBuilder.ApplyConfiguration(new OtherRequestMapping());
            modelBuilder.ApplyConfiguration(new PrintRequestMappings());
            modelBuilder.ApplyConfiguration(new PrintRequestPositionMappings());
            modelBuilder.ApplyConfiguration(new AggregatedRequestsViewMappings());
            modelBuilder.ApplyConfiguration(new HelperMappings());
            modelBuilder.ApplyConfiguration(new HelpOffersMappings());
        }
    }
}