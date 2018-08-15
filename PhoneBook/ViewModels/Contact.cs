using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.ViewModels
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }

        public string ToString()
        {
            var numbers = string.Join("", PhoneNumbers.Select(pn => pn.Number).ToArray());
            return $"{Name}{Email}{Organization}{numbers}";
        }
    }
}
