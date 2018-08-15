using System.Collections.Generic;
using PhoneBook.ViewModels;

namespace PhoneBook.Services
{
    public interface IContactFilter
    {
        List<Contact> Search(string searchCriteria);
    }
}
