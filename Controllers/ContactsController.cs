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

  [HttpPost("new", Name = "newContact")]
  public ActionResult AddNewContact(Contact contact)
  {
    if (contacts.FindIndex(c => c.Name == contact.Name) != -1)
    {
      return BadRequest($"Contact with name {contact.Name} already exists");
    }
    contacts.Add(contact);
    return Created($"Contact with name {contact.Name} created!", contact);
  }

  [HttpDelete("delete", Name = "DeleteContact")]
  public ActionResult DeleteContact(string name)
  {

    var contactToRemove = contacts.Find((contact) => contact.Name == name);
    if (contactToRemove != null)
    {
      contacts.Remove(contactToRemove);
      return NoContent();
    }
    else
    {
      return NotFound($"Contact with name {name} not found!");
    }
  }

  [HttpPut("update", Name = "UpdateContact")]
  public ActionResult UpdateContact([FromBody] Contact updatedContact)
  {
    var contactToUpdate = contacts.Find((contact) => contact.Name == updatedContact.Name);
    if (contactToUpdate != null)
    {
      if (updatedContact.PhoneNumber != null)
        contactToUpdate.PhoneNumber = updatedContact.PhoneNumber;

      if (updatedContact.Email != null)
        contactToUpdate.Email = updatedContact.Email;
      return Ok(contactToUpdate);
    }
    else
    {
      return NotFound($"Contact with name {updatedContact.Name} not found!");
    }


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





