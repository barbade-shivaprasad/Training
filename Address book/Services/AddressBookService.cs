using Address_book.Interfaces;
using Address_book.Models;
using Dapper;
using System.Data;

namespace Address_book.Services
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IDataProvider _dataProvider;
        private readonly IDbConnection _db;
        public AddressBookService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _db = _dataProvider.GetDb();
        }

        public async void AddContact(Contact contact)
        {
            try
            {
                var query = $"INSERT INTO Shiva([Name], [Email], [Mobile], [Landline], [website], [Address]) VALUES ('{contact.Name}','{contact.Email}','{contact.Mobile}','{contact.Landline}','{contact.website}','{contact.Address}')";
                await _db.QueryAsync<Contact>(query);
            }
            catch(Exception)
            {
                throw;
            }

        }

        public async void EditContact(Contact contact)
        {
            try
            {
                var query = $"UPDATE Shiva SET Name='{contact.Name}',Email='{contact.Email}',mobile='{contact.Mobile}',landline='{contact.Landline}',website='{contact.website}',Address='{contact.Address}' where id='{contact.Id}'";
                await _db.QueryAsync<Contact>(query);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async void DeleteContact(int id)
        {
            try
            {
                var query = $"DELETE FROM Shiva WHERE Id = {id}";
                await _db.QueryAsync<Contact>(query);
            }
            catch(Exception)
            {
                throw;
            }

        }

        public async Task<Contact?> GetContact(int id)
        {
            try
            {
                var query = $"SELECT * FROM shiva WHERE Id =   {id}";
                return (await _db.QueryAsync<Contact>(query)).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<Contact>> GetContactList()
        {
            try
            {
                var query = "SELECT * FROM shiva";
                return (await _db.QueryAsync<Contact>(query)).ToList();
            }
            catch(Exception)
            {
                throw;
            }

        }

        public async Task<int?> GetFirstContactId()
        {
            try
            {
                var query = "SELECT Top 1 * FROM shiva";
                IEnumerable<Contact> contacts = (await _db.QueryAsync<Contact>(query)).ToList();
                Contact contact = contacts.ElementAt(0);
                return contact.Id;
            }
            catch(Exception )
            {
                throw;
            }
        }

        public async Task<int?> GetPreviousContactId(int id)
        {
            try
            {
                IEnumerable<Contact> contacts = await this.GetContactList();

                int length = contacts.Count();
                if(length != 0)
                {
                    if (contacts.ElementAt(0).Id == id && length >= 2)
                        return contacts.ElementAt(1).Id;

                    for(int i = 1; i < length; i++)
                    {
                        if(contacts.ElementAt(i).Id == id)
                        {
                            return contacts.ElementAt(i-1).Id;
                        }
                    }
                }

                return -1;

            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
