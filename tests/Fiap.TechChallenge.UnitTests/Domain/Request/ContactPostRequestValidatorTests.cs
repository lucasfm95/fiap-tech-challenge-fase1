using AutoFixture;
using Fiap.TechChallenge.Domain.Request;
using FluentAssertions;

namespace Fiap.TechChallenge.UnitTests.Domain.Request;

public class ContactPostRequestValidatorTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void ShouldReturnErrorWhenEmailIsInvalid()
    {
        // Arrange
        var request = _fixture.Build<ContactPostRequest>()
            .With(x => x.Ddd, 11)
            .With(x => x.PhoneNumber, "123456789")
            .With(x => x.Email, "teste_arroba_gmail.com")
            .Create();

        var requestValidator = new ContactPostRequestValidator();

        //Act
        var requestValidatorResult = requestValidator.Validate(request);

        //Assert
        requestValidatorResult.IsValid.Should().BeFalse();
        requestValidatorResult.Errors.Should().HaveCount(1);
        requestValidatorResult.Errors.Should().Contain(x => x.ErrorMessage == "Invalid email format");
    }
}