using Fiap.TechChallenge.Application.Services;
using Fiap.TechChallenge.Domain.Request;
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
    
}