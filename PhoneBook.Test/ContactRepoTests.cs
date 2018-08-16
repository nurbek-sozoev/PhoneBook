using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using PhoneBook.Data;
using PhoneBook.Services;
using PhoneBook.ViewModels;

namespace PhoneBook.Test
{
    [TestFixture]
    public class ContactRepoTests
    {
        private ContactRepo _subject;

        [SetUp]
        public void Init()
        {
            var contacts = new ObservableCollection<Contact>(new[]
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
                            Number = "+996 799 699119",
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
                            Number = "+996 998 699009",
                            Type = "home"
                        }
                    })
                }
            });

            var mock = new Mock<PhoneBookDbContext>();
            mock.Setup(ctx => ctx.Contacts)
                .ReturnsDbSet(new FakeDbSet<Contact>(contacts));

           _subject = new ContactRepo(mock.Object);
        }

        [Test]
        public void SearchByNameTest()
        {
            List<Contact> result = _subject.Search("Иванов Иван");

            Assert.IsTrue(result.Count == 1);
            Assert.AreEqual("Иванов Иван Иванович", result[0].Name);
        }

        [Test]
        public void SearchByPhoneNumberTest()
        {
            List<Contact> result = _subject.Search("699");
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void SearchByEmtyCriteriaTest()
        {
            List<Contact> result = _subject.Search(" ");
            Assert.AreEqual(2, result.Count);
        }
    }
}
