using System.Collections.Generic;
using PhoneBook.ViewModels;

namespace PhoneBook.Services
{
    public static class ContactsList
    {
        public static List<Contact> Contacts()
        {
            return  new List<Contact>(new []
            {
                new Contact
                {
                    Id = 1,
                    Name = "Иванов Иван Иванович",
                    Email = "ivan@gmail.com",
                    Organization = "MacroSoft LTD",
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
    }
}
