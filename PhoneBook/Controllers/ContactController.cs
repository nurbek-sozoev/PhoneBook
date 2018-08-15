using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services;
using PhoneBook.ViewModels;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IContactFilter _filter;

        public ContactController(IContactFilter filter)
        {
            _filter = filter;
        }

        [HttpGet]
        public IEnumerable<Contact> Search(string searchCriteria)
        {
            Console.WriteLine($"Search by {searchCriteria}");
            return _filter.Search(searchCriteria);
        }

        [HttpGet("{id}", Name = "GetContact")]
        public ActionResult<Contact> FindById(long id)
        {
            Console.WriteLine($"Find contact by {id}");
            return _filter.FindById(id);
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            Console.WriteLine($"Create contact {contact.Name}");
            contact.Id = _filter.LastId();
            _filter.Add(contact);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Contact contact)
        {
            Console.WriteLine($"Update contact {contact.Name}");
            _filter.Save(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Console.WriteLine($"Delete contact {id}");
            _filter.Delete(id);
            return NoContent();
        }
    }
}
