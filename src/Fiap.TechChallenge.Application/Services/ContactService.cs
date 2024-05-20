using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.Domain.Repositories;
using Fiap.TechChallenge.Domain.Request;
using FluentValidation;

namespace Fiap.TechChallenge.Application.Services;

public class ContactService(IContactRepository contactRepository)
{
    public async Task<List<Contact>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await contactRepository.FindAllAsync(cancellationToken);
    }
    
    public async Task<List<Contact>> GetAllByDddAsync(short dddNumber, CancellationToken cancellationToken)
    {
        return await contactRepository.FindAllByDddAsync(dddNumber, cancellationToken);
    }
    
    public async Task<Contact?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await contactRepository.FindByIdAsync(id, cancellationToken);
    }
    
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

    public async Task<bool> UpdateAsync(long id, ContactPostRequest request, CancellationToken cancellationToken)
    {
        var contact = await GetByIdAsync(id, cancellationToken);

        if(contact is null)
            return false;

        var validator = new ContactPostRequestValidator();
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var contactUpdated = new Contact(request.Name,request.Email, request.PhoneNumber, request.Ddd);    
        contactUpdated.Id = id;

        return await contactRepository.UpdateAsync(contactUpdated, cancellationToken);
    }
}