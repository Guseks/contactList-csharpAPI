using System.ComponentModel.DataAnnotations;

namespace contactList.Models;

public class Contact
{
  [Required]
  public string Name { get; set; }
  [EmailAddress]
  public string? Email { get; set; }
  public string? PhoneNumber { get; set; }

  public Contact(string name, string? phoneNumber = null, string? email = null)
  {
    Name = name;
    PhoneNumber = phoneNumber;
    Email = email;
  }

}
