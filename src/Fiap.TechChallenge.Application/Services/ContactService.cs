using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.Domain.Repositories;
using Fiap.TechChallenge.Domain.Request;

namespace Fiap.TechChallenge.Application.Services;

public class ContactService(IContactRepository contactRepository)
{
    public async Task<long> CreateAsync(ContactPostRequest request, CancellationToken cancellationToken)
    {
        //TODO: Validar se ddd existe
        var contact = new Contact(request.Name,request.Email, request.PhoneNumber, request.Ddd);
        var result = await contactRepository.CreateAsync(contact, cancellationToken);
        return result;
    }
}