using Fiap.TechChallenge.Domain;
using Fiap.TechChallenge.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TechChallenge.Infrastructure.Context;

public class ContactDbContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var envConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING_DB_POSTGRES");
        optionsBuilder.UseNpgsql(envConnectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
    }
}