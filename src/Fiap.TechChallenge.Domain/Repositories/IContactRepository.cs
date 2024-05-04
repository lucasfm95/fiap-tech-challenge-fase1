using Fiap.TechChallenge.Domain.Entities;

namespace Fiap.TechChallenge.Domain.Repositories;

public interface IContactRepository
{
    public Task<List<Contact>> FindAllAsync(CancellationToken cancellationToken);
    public Task<List<Contact>> FindAllByDddAsync(short dddNumber, CancellationToken cancellationToken);
    public Task<Contact?> FindByIdAsync(long id, CancellationToken cancellationToken);
    public Task<long> CreateAsync(Contact contact, CancellationToken cancellationToken);
    public Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);
}