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
            return new Contact
            {
                Id = 1,
                Name = "Созоев Нурбек Алмасович",
                Email = "sozoev@gmail.com",
                Organization = "IT-Attractor",
                PhoneNumbers = new List<PhoneNumber>(new[]
                {
                    new PhoneNumber
                    {
                        Number = "+996 708 699119",
                        Type = "mobile"
                    },
                    new PhoneNumber
                    {
                        Number = "+996 708 699119",
                        Type = "home"
                    },
                    new PhoneNumber
                    {
                        Number = "+996 708 699119",
                        Type = "work"
                    }
                })
            };
        }

        [HttpPut]
        public IActionResult Update(Contact contact)
        {
            Console.WriteLine($"Update contact {contact.Id}");
            return NoContent();
        }
    }
}
