using System.Collections.Generic;
using PhoneBook.ViewModels;

namespace PhoneBook.Services
{
    public interface IContactFilter
    {
        List<Contact> Search(string searchCriteria);
        Contact FindById(long id);
        void Add(Contact contact);
        void Save(Contact contact);
        void Delete(long id);
        long LastId();
    }
}
