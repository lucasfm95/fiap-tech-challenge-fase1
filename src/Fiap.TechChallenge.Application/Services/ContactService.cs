using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.Domain.Repositories;
using Fiap.TechChallenge.Domain.Request;
using FluentValidation;

namespace Fiap.TechChallenge.Application.Services;

public class ContactService(IContactRepository contactRepository)
{
    public async Task<long> CreateAsync(ContactPostRequest request, CancellationToken cancellationToken)
    {
        var validator = new ContactPostRequestValidator();
        await validator.ValidateAndThrowAsync(request, cancellationToken);
        
        var contact = new Contact(request.Name,request.Email, request.PhoneNumber, request.Ddd);
        var result = await contactRepository.CreateAsync(contact, cancellationToken);
        return result;
    }
    
    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
    {
       return await contactRepository.DeleteAsync(id, cancellationToken);
    }
}