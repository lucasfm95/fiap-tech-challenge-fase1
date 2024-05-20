using System.Net;
using Fiap.TechChallenge.Api.Controllers;
using Fiap.TechChallenge.Application.Services.Interfaces;
using Fiap.TechChallenge.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Fiap.TechChallenge.UnitTests.Presentation.Controllers;

public class ContactControllerTests
{
    [Fact]
    private async Task GetAllShouldBeSuccess()
    {
        var mockContactService = new Mock<IContactService>();
        var cancellationToken = new CancellationToken();
        
        var contacts = new List<Contact>
        {
            new("John Doe", "john@email.com", "123456789", 11),
            new("Jane Doe", "jane@email.com", "987654321", 21)
        };
        
        mockContactService
            .Setup(contactService => contactService.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(contacts);
        
        var controller = new ContactController(mockContactService.Object, It.IsAny<ILogger<ContactController>>());

        var result = await controller.GetAll(cancellationToken) as OkObjectResult;
        
        result.Should().BeOfType<OkObjectResult>().And.NotBeNull();
        result?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        result?.Value.Should().BeEquivalentTo(contacts);
        mockContactService.Verify(contactService => contactService.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    private async Task GetAllShouldBeSuccessWhenListOfContactsIsEmpty()
    {
        var mockContactService = new Mock<IContactService>();
        var cancellationToken = new CancellationToken();
        
        var contacts = new List<Contact>();
        
        mockContactService
            .Setup(contactService => contactService.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(contacts);
        
        var controller = new ContactController(mockContactService.Object, It.IsAny<ILogger<ContactController>>());

        var result = await controller.GetAll(cancellationToken) as OkObjectResult;
        
        result.Should().BeOfType<OkObjectResult>().And.NotBeNull();
        result?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        result?.Value.Should().BeEquivalentTo(contacts);
        mockContactService.Verify(contactService => contactService.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    private async Task GetByIdShouldBeSuccess()
    {
        var mockContactService = new Mock<IContactService>();
        var cancellationToken = new CancellationToken();

        var contact = new Contact("John Doe", "john@email.com", "123456789", 11);

        mockContactService
            .Setup(contactService => contactService.GetByIdAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(contact);

        var controller = new ContactController(mockContactService.Object, It.IsAny<ILogger<ContactController>>());

        var result = await controller.GetById(1, cancellationToken) as OkObjectResult;

        result.Should().BeOfType<OkObjectResult>().And.NotBeNull();
        result?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        result?.Value.Should().Be(contact);
        mockContactService.Verify(contactService => contactService.GetByIdAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    private async Task GetByIdShouldBeNoContent()
    {
        var mockContactService = new Mock<IContactService>();
        var cancellationToken = new CancellationToken();

        mockContactService
            .Setup(contactService => contactService.GetByIdAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Contact)null!);

        var controller = new ContactController(mockContactService.Object, It.IsAny<ILogger<ContactController>>());

        var result = await controller.GetById(1, cancellationToken) as NoContentResult;

        result.Should().BeOfType<NoContentResult>().And.NotBeNull();
        result?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
        mockContactService.Verify(contactService => contactService.GetByIdAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    private async Task GetByDddShouldBeSuccess()
    {
        var mockContactService = new Mock<IContactService>();
        var cancellationToken = new CancellationToken();

        var contacts = new List<Contact>
        {
            new("John Doe", "john@email.com", "123456789", 11),
            new("Tom Doe", "tom@email.com", "123451234", 11),
            new("Jane Doe", "jane@email.com", "987654321", 21)
        };

        var contactsWithDdd11 = contacts.Where(c => c.DddNumber == 11).ToList();

        mockContactService
            .Setup(contactService => contactService.GetAllByDddAsync(It.IsAny<short>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(contactsWithDdd11);

        var controller = new ContactController(mockContactService.Object, It.IsAny<ILogger<ContactController>>());

        var result = await controller.GetByDdd(11, cancellationToken) as OkObjectResult;

        result.Should().BeOfType<OkObjectResult>().And.NotBeNull();
        result?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        result?.Value.Should().Be(contactsWithDdd11);
        result?.Value.Should().NotBe(contacts);
        mockContactService.Verify(contactService => contactService.GetAllByDddAsync(It.IsAny<short>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    private async Task GetByDddShouldBeNoContent()
    {
        var mockContactService = new Mock<IContactService>();
        var cancellationToken = new CancellationToken();
        
        mockContactService
            .Setup(contactService => contactService.GetAllByDddAsync(It.IsAny<short>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Contact>());

        var controller = new ContactController(mockContactService.Object, It.IsAny<ILogger<ContactController>>());

        var result = await controller.GetByDdd(99, cancellationToken) as NoContentResult;

        result.Should().BeOfType<NoContentResult>().And.NotBeNull();
        result?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
        mockContactService.Verify(contactService => contactService.GetAllByDddAsync(It.IsAny<short>(), It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    private async Task DeleteShouldBeSuccess()
    {
        var mockContactService = new Mock<IContactService>();
        
        mockContactService.Setup(x =>
            x.DeleteAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);
        
        var controller = new ContactController(mockContactService.Object, It.IsAny<ILogger<ContactController>>());

        var result = await controller.Delete(1, new CancellationToken()) as OkObjectResult;
        
        result.Should().BeOfType<OkObjectResult>().And.NotBeNull();
        result?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        mockContactService.Verify(contactService => contactService.DeleteAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    private async Task DeleteShouldReturnBadRequest()
    {
        var mockContactService = new Mock<IContactService>();
        
        mockContactService.Setup(x =>
                x.DeleteAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
            .Throws<Exception>();
        
        var controller = new ContactController(mockContactService.Object, It.IsAny<ILogger<ContactController>>());

        await Assert.ThrowsAsync<Exception>(() => controller.Delete(1, new CancellationToken()));
        
        mockContactService.Verify(contactService => contactService.DeleteAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}