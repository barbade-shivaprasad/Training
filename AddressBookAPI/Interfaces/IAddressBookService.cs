using AddressBookAPI.Models.CoreModels;

namespace AddressBookAPI.Interfaces
{
    public interface IAddressBookService
    {
        Task<int> AddContact(Contact contact);
        Task<bool> DeleteContact(int id);
        Task<bool> EditContact(Contact contact);
        Task<Contact?> GetContact(int id);
        Task<IEnumerable<Contact>> GetContactList();
        Task<int?> GetPreviousContactId(int id);

    }
}