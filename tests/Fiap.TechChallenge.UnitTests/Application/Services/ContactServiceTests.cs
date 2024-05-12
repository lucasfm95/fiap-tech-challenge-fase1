using AutoFixture;
using Fiap.TechChallenge.Application.Repositories;
using Fiap.TechChallenge.Application.Services;
using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.Domain.Request;
using FluentAssertions;
using Moq;

namespace Fiap.TechChallenge.UnitTests.Application.Services;

public class ContactServiceTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public async Task ShouldCreateWithSuccessAsync()
    {
        // Arrange
        var contact = _fixture
            .Build<ContactPostRequest>()
            .With(c => c.Email, "Email@teste.com")
            .With(c => c.PhoneNumber, "123456789")
            .With(c => c.Name, "Teste")
            .With(c => c.Ddd, 11)
            .Create();

        var contactRepository = new Mock<IContactRepository>();
        contactRepository
            .Setup(x => x.CreateAsync(It.IsAny<Contact>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var contactService = new ContactService(contactRepository.Object);

        // Act
        var result = await contactService.CreateAsync(contact, CancellationToken.None);

        // Assert
        result.Should().Be(1);
        contactRepository.Verify(x => x.CreateAsync(It.IsAny<Contact>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task ShouldDeleteWithSuccess()
    {
        //Arrange
        var contactRepository = new Mock<IContactRepository>();
        contactRepository.Setup(c => c.DeleteAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var contactService = new ContactService(contactRepository.Object);

        //Act
        var result = await contactService.DeleteAsync(1, CancellationToken.None);

        //Assert
        result.Should().BeTrue();
        contactRepository.Verify(c =>
            c.DeleteAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()), Times.Once);
        contactRepository.Verify(c =>
            c.CreateAsync(It.IsAny<Contact>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}