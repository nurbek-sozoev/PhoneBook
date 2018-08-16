using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.ViewModels;

namespace PhoneBook.Services
{
    public class ContactRepo : IContactRepo
    {
        private readonly PhoneBookDbContext _dbContext;

        public ContactRepo(PhoneBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
        }

        public void Save(Contact contact)
        {
            //TODO: Переделать обновление контакта.
            Delete(contact.Id);
            Add(contact);
        }

        public void Delete(long id)
        {
            var contact = FindById(id);
            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
        }

        public Contact FindById(long id)
        {
            return _dbContext.Contacts.Include(c => c.PhoneNumbers).First(c => c.Id == id);
        }

        public List<Contact> Search(string searchCriteria)
        {
            if (string.IsNullOrEmpty(searchCriteria))
                return _dbContext.Contacts.Include(c => c.PhoneNumbers).ToList();

            var criteria = searchCriteria.ToLower().Trim();

            return _dbContext.Contacts.Include(c => c.PhoneNumbers).ToList()
                .Where(
                    c => c.ToString().ToLower().Contains(criteria)
                ).OrderBy(c => c.Name).ToList();
        }
    }
}
