using Fiap.TechChallenge.Application.Services;
using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.Domain.Request;
using Fiap.TechChallenge.Domain.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.TechChallenge.Api.Controllers;

[Route("api/contacts")]
[ApiController]
[AllowAnonymous]
public class ContactController(ContactService contactService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]ContactPostRequest request, CancellationToken cancellationToken)
    {
        var result = await contactService.CreateAsync(request, cancellationToken);
        return Ok(result);
    }
    
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete([FromRoute]long id, CancellationToken cancellationToken)
    {
        var result = await contactService.DeleteAsync(id, cancellationToken);
        if (!result)
        {
            ;
            return NotFound(new DefaultResponse<Contact> { Message = $"Contact with ID: {id} not found."});
        }
        return Ok(new DefaultResponse<Contact> { Message = "Contact removed successfully."});
    }
    
}