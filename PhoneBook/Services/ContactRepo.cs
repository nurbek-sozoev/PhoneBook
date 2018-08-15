using System.Collections.Generic;
using System.Linq;
using PhoneBook.ViewModels;

namespace PhoneBook.Services
{
    public class ContactRepo : IContactRepo
    {
        private readonly List<Contact> _contacts;

        public ContactRepo()
        {
            _contacts = ContactsList.Contacts();
        }

        public ContactRepo(List<Contact> contacts)
        {
            _contacts = contacts;
        }

        public void Add(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void Save(Contact contact)
        {
            Delete(contact.Id);
            _contacts.Add(contact);
        }

        public void Delete(long id)
        {
            var c = FindById(id);
            _contacts.Remove(c);
        }

        public Contact FindById(long id)
        {
            return _contacts.First(c => c.Id == id);
        }

        public long LastId()
        {
            var maxId = _contacts.Max(c => c.Id);
            return maxId + 1;
        }

        public int Count()
        {
            return _contacts.Count;
        }

        public List<Contact> Search(string searchCriteria)
        {
            if (string.IsNullOrEmpty(searchCriteria))
                return _contacts;

            var criteria = searchCriteria.ToLower().Trim();

            return _contacts.Where(
                    c => c.ToString().ToLower().Contains(criteria)
                ).OrderBy(c => c.Name).ToList();
        }
    }
}
