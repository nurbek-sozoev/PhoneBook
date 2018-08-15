using System.Collections.Generic;
using NUnit.Framework;
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
           _subject = new ContactRepo(new List<Contact>(new []
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
               }
           }));
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
            Assert.IsTrue(result.Count == 2);
        }

        [Test]
        public void SearchByEmtyCriteriaTest()
        {
            List<Contact> result = _subject.Search(" ");
            Assert.IsTrue(result.Count == 2);
        }

        [Test]
        public void FindByIdTest()
        {
            Contact result = _subject.FindById(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void LastIdTest()
        {
            var id = _subject.LastId();
            Assert.AreEqual(3, id);
        }

        [Test]
        public void AddTest()
        {
            _subject.Add(new Contact());
            Assert.AreEqual(3, _subject.Count());
        }

        [Test]
        public void DeleteTest()
        {
            _subject.Delete(1);
            Assert.AreEqual(1, _subject.Count());
        }
    }
}
