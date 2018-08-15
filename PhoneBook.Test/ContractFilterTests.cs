using System.Collections.Generic;
using NUnit.Framework;
using PhoneBook.Services;
using PhoneBook.ViewModels;

namespace PhoneBook.Test
{
    [TestFixture]
    public class ContractFilterTests
    {
        private List<Contact> _contacts = new List<Contact>(new []
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
                            Number = "+996 798 690119",
                            Type = "mobile"
                        },
                        new PhoneNumber
                        {
                            Number = "+996 708 691119",
                            Type = "home"
                        },
                        new PhoneNumber
                        {
                            Number = "+996 799 699119",
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
                }
            });

        [Test]
        public void SearchByNameTest()
        {
            var filter = new ContactFilter(_contacts);
            List<Contact> result = filter.Search("Созоев Нурбек");

            Assert.IsTrue(result.Count == 1);
            Assert.AreEqual("Созоев Нурбек Алмасович", result[0].Name);
        }

        [Test]
        public void SearchByPhoneNumberTest()
        {
            var filter = new ContactFilter(_contacts);
            List<Contact> result = filter.Search("699");

            Assert.IsTrue(result.Count == 2);
        }

        [Test]
        public void SearchByEmtyCriteriaTest()
        {
            var filter = new ContactFilter(_contacts);
            List<Contact> result = filter.Search(" ");

            Assert.IsTrue(result.Count == 2);
        }
    }
}
