using Fiap.TechChallenge.Application.Services.Interfaces;
using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.Domain.Request;
using Fiap.TechChallenge.Domain.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.TechChallenge.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
[AllowAnonymous]
public class ContactController(IContactService contactService) : Controller
{
    /// <summary>
    /// List all contacts
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Contacts</returns>
    /// <response code="200">OK</response>
    /// <response code="500">Internal server error</response>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await contactService.GetAllAsync(cancellationToken);
        return Ok(result);
    }
    
    /// <summary>
    /// Find contact by id
    /// </summary>
    /// <param name="id">Unique contact identify</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Contact</returns>
    /// <response code="200">OK</response>
    /// <response code="204">No content</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById([FromRoute]long id, CancellationToken cancellationToken)
    {
        var result = await contactService.GetByIdAsync(id, cancellationToken);
        if (result == null)
        {
            return NoContent();
        }
        return Ok(result);
    }
    /// <summary>
    /// Find contacts by DDD
    /// </summary>
    /// <param name="dddNumber">Contact DDD</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Contacts</returns>
    /// <response code="200">OK</response>
    /// <response code="204">No content</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("/ddd/{dddNumber}")]
    public async Task<IActionResult> GetByDdd([FromRoute]short dddNumber, CancellationToken cancellationToken)
    {
        var result = await contactService.GetAllByDddAsync(dddNumber, cancellationToken);
        if (!result.Any())
        {
            return NoContent();
        }
        return Ok(result);
    }
    
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
            return BadRequest(new DefaultResponse<Contact> { Message = $"Contact with ID: {id} not found."});
        }
        return Ok(new DefaultResponse<Contact> { Message = "Contact removed successfully."});
    }
}