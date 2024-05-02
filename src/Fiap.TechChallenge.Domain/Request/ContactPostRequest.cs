namespace Fiap.TechChallenge.Domain.Request;

public class ContactPostRequest(short ddd, string email, string phoneNumber, string name)
{
    public short Ddd { get; init; } = ddd;
    public string Email { get; init; } = email;
    public string PhoneNumber { get; init; } = phoneNumber;
    public string Name { get; init; } = name;
}