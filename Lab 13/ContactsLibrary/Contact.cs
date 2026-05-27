namespace ContactsLibrary;

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Discord { get; set; }

    public Contact()
    {
    }

    public Contact(string firstName, string lastName, string phone, string email, string discord)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        Discord = discord;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} - {Phone} - {Email} - Discord: {Discord}";
    }
}
