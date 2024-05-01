namespace Fiap.TechChallenge.Domain;

public class Contact(string name, string email, string phoneNumber, int dddNumber)
{
    public long Id { get; set; }
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
    public string PhoneNumber { get; set; } = phoneNumber;

    public int DddNumber { get; set; } = dddNumber;
}