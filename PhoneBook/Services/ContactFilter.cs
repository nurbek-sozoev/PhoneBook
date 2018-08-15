using System;
using System.Collections.Generic;
using System.Linq;
using PhoneBook.ViewModels;

namespace PhoneBook.Services
{
    public class ContactFilter : IContactFilter
    {
        private readonly List<Contact> _contacts;

        public ContactFilter()
        {
            _contacts = new List<Contact>(new []
            {
                new Contact
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
                },
                new Contact
                {
                    Id = 2,
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
                    Id = 3,
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
                }
            });
        }

        public ContactFilter(List<Contact> contacts)
        {
            _contacts = contacts;
        }

        public List<Contact> Search(string searchCriteria)
        {
            if (string.IsNullOrEmpty(searchCriteria))
                return _contacts;

            var criteria = searchCriteria.ToLower().Trim();

            return _contacts.Where(
                    c => c.ToString().ToLower().Contains(criteria)
                ).ToList();
        }
    }
}
