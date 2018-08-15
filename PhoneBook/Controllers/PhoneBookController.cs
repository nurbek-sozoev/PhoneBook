using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services;
using PhoneBook.ViewModels;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    public class PhoneBookController : Controller
    {
        private readonly IContactFilter _filter;

        public PhoneBookController(IContactFilter filter)
        {
            _filter = filter;
        }

        [HttpGet("[action]")]
        public IEnumerable<Contact> Contacts(string searchCriteria)
        {
            Console.WriteLine($"Search value is {searchCriteria}");
            return _filter.Search(searchCriteria);
        }
    }
}
