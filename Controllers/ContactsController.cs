using Microsoft.AspNetCore.Mvc;
using contactList.Models;

namespace contactList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
  private static List<Contact> contacts = new List<Contact>();

  public ContactsController()
  {
    if (contacts.Count == 0)
    {
      InitContacts();
    }
  }

  [HttpGet]
  public ActionResult<List<Contact>> GetAllContacts()
  {
    return Ok(contacts);
  }

  [HttpPost("new")]
  public ActionResult AddNewContact(Contact contact)
  {
    contacts.Add(contact);
    return Created($"Contact with name {contact.Name} created!", contact);
  }

  private void InitContacts()
  {
    var names = new string[3] { "Erik", "James", "Thomas" };
    var phoneNumbers = new string[3] { "0734-124102", "0721-128923", "0737-828191" };
    var emails = new string[3] { "test@gmail.com", "test2@gmail.com", "test3@gmail.com" };

    for (var i = 0; i < names.Length; i++)
    {
      contacts.Add(new Contact(names[i], phoneNumbers[i], emails[i]));
    }
  }
}





