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

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var contact = dbContext.Contacts.FirstOrDefault(c => c.Id == id);
        if (contact == null)
        {
            return false;
        }
        dbContext.Contacts.Remove(contact);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}