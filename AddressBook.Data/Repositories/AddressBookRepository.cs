using System.Collections.Generic;
using System.Linq;
using AddressBook.Data.Interfaces;
using AddressBook.Data.Models;

namespace AddressBook.Data.Repositories
{
    public class AddressBookRepository : IAddressBookRepository
    {
        public static List<Address> addressBooks = new List<Address>()
        {
            new Address
            {
                Id = 1,
                Name = "Lukas",
                LastName = "Kowalski",
                Town = "Lachowice",
                Street = "Kasztanowa",
                HouseNumber = 199
            },
            new Address
            {
                Id = 2,
                Name = "Jan",
                LastName = "Nowak",
                Town = "Sucha Beskidzka",
                Street = "Miodowa",
                HouseNumber = 100
            },
            new Address
            {
                Id = 3,
                Name = "Sylwia",
                LastName = "Rogalska",
                Town = "Lachowice",
                Street = "Sportowa",
                HouseNumber = 209
            }
        };
        
        public Address GetAddress()
        {
            return addressBooks.LastOrDefault();
        }

        public void CreateAddress(Address address)
        {
            addressBooks.Add(address);
        }

        IEnumerable<Address> IAddressBookRepository.GetAddressTown(string town)
        {
            return addressBooks.Where(x => x.Town == town).ToList();
        }
    }
}
