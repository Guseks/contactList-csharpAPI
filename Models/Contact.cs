namespace contactList;

public class Contact
{
    public string Name {get; set;}
    public string Email {get; set;}
    public string PhoneNumber {get; set;}

    public Contact(string name, string phoneNumber, string email)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

}
