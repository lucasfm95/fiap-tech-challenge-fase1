using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.Domain.Repositories;
using Fiap.TechChallenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TechChallenge.Infrastructure.Repositories;

public class ContactRepository(ContactDbContext dbContext) : IContactRepository
{
    public async Task<List<Contact>> FindAllAsync(CancellationToken cancellationToken)
    {
        var contacts = await dbContext.Contacts.ToListAsync();
        return contacts;
    }

    public async Task<Contact?> FindByIdAsync(long id, CancellationToken cancellationToken)
    {
        var contact = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == id, cancellationToken: cancellationToken);
        return contact;
    }

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