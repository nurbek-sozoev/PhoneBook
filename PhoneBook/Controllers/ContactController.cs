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
        private readonly IContactRepo _repo;

        public ContactController(IContactRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Contact> Search(string searchCriteria)
        {
            Console.WriteLine($"Search by {searchCriteria}");
            return _repo.Search(searchCriteria);
        }

        [HttpGet("{id}", Name = "GetContact")]
        public ActionResult<Contact> FindById(long id)
        {
            Console.WriteLine($"Find contact by {id}");
            return _repo.FindById(id);
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            Console.WriteLine($"Create contact {contact.Name}");
            _repo.Add(contact);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Contact contact)
        {
            Console.WriteLine($"Update contact {contact.Name}");
            _repo.Save(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Console.WriteLine($"Delete contact {id}");
            _repo.Delete(id);
            return NoContent();
        }
    }
}
