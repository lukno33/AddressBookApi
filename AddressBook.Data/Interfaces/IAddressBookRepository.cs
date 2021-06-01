using System.Collections.Generic;
using AddressBook.Data.Models;

namespace AddressBook.Data.Interfaces
{
    public interface IAddressBookRepository
    {
        Address GetAddress();
        IEnumerable<Address> GetAddressTown(string town);
        void CreateAddress(Address address);
    }
}