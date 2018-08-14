using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Contact> Contacts()
        {
            return new List<Contact>(new []
            {
                new Contact
                {
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
                },
                new Contact
                {
                    Name = "Петров Петр Алесеевич",
                    Email = "petr@gmail.com",
                    Organization = "SoftTechical Company LTD",
                    PhoneNumbers = new List<PhoneNumber>(new[]
                    {
                        new PhoneNumber
                        {
                            Number = "+996 788 600119",
                            Type = "mobile"
                        },
                        new PhoneNumber
                        {
                            Number = "+996 998 699009",
                            Type = "home"
                        }
                    })
                },
                new Contact
                {
                    Name = "Иванов Михаил Алесеевич",
                    Email = "ivin@gmail.com",
                    Organization = "MicroHard Techical Company LTD",
                    PhoneNumbers = new List<PhoneNumber>(new[]
                    {
                        new PhoneNumber
                        {
                            Number = "+996 998 900109",
                            Type = "mobile"
                        },
                        new PhoneNumber
                        {
                            Number = "+996 888 999009",
                            Type = "work"
                        }
                    })
                },
            });
        }

        public class Contact
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Organization { get; set; }
            public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        }

        public class PhoneNumber
        {
            public string Type { get; set; }
            public string Number { get; set; }
        }
    }
}
