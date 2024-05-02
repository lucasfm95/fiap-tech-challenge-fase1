using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.Domain.Repositories;
using Fiap.TechChallenge.Infrastructure.Context;

namespace Fiap.TechChallenge.Infrastructure.Repositories;

public class ContactRepository(ContactDbContext dbContext) : IContactRepository
{
    
    public async Task<long> CreateAsync(Contact contact, CancellationToken cancellationToken)
    {
        await dbContext.Contacts.AddAsync(contact, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return contact.Id;
    }
}