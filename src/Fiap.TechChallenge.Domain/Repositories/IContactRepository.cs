using Fiap.TechChallenge.Domain.Entities;

namespace Fiap.TechChallenge.Domain.Repositories;

public interface IContactRepository
{
    public Task<long> CreateAsync(Contact contact, CancellationToken cancellationToken);
    public Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);
}