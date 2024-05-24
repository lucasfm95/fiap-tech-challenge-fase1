using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TechChallenge.Infrastructure.Context;

public class ContactDbContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<DddState> DddStates { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123456");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactConfiguration).Assembly);
    }
}