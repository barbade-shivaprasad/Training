using AddressBookAPI.Configurations;
using AddressBookAPI.Interfaces;
using AddressBookAPI.Models.CoreModels;
using AddressBookAPI.Models.DataModels;
using AutoMapper;
using Dapper;
using System.Data;

namespace AddressBookAPI.Services
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IDbConnection _db;
        private readonly IMapper _mapper;

        public AddressBookService(IDataProvider dataProvider, MapperConifg mapperConfig)
        {
            _db = dataProvider.GetDb();
            _mapper = mapperConfig.GetMapper();
        }

        public async Task<int> AddContact(Contact contact)
        {
            try
            {
                var contactDataModel = _mapper.Map<ContactDataModel>(contact);
                contactDataModel.CreatedOn = DateTime.UtcNow;
                contactDataModel.UpdatedOn = DateTime.UtcNow;

                var query = @"INSERT INTO [dbo].[Shiva]([Name], [Email], [Mobile], [Landline], [Website], [Address], [CreatedOn],[UpdatedOn],[DeletedOn],[IsDeleted]) 
                            VALUES (@Name, @Email, @Mobile, @Landline, @Website, @Address, @CreatedOn,@UpdatedOn, @DeletedOn, @IsDeleted)";

                await _db.ExecuteAsync(query, contactDataModel);

                int id = (await _db.QueryAsync<int>("SELECT IDENT_CURRENT('Shiva')")).ToList().FirstOrDefault();
                return id;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> EditContact(Contact contact)
        {
            try
            {
                var contactDataModel = _mapper.Map<ContactDataModel>(contact);
                contactDataModel.UpdatedOn = DateTime.Now;

                var query = @"UPDATE Shiva 
                            SET Name = @Name,Email=@Email,mobile=@Mobile,landline=@Landline,website=@Website,Address=@Address,UpdatedOn = @UpdatedOn where id=@Id";

                int rowsAffected = await _db.ExecuteAsync(query, contactDataModel);

                if(rowsAffected > 0)
                    return true;

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteContact(int id)
        {
            try
            {

                var query = @"UPDATE Shiva 
                            SET IsDeleted = @IsDeleted,DeletedOn = @DeletedOn where Id = @Id";

                int rowsAffected = await _db.ExecuteAsync(query, new
                {
                    Id = id,
                    IsDeleted = true,
                    DeletedOn = DateTime.UtcNow
                });

                if (rowsAffected > 0)
                    return true;

                return false;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Contact?> GetContact(int id)
        {
            try
            {

                var query = @"SELECT * From Shiva WHERE Id = @Id and IsDeleted = 0";
                ContactDataModel? contactDataModel = (await _db.QueryAsync<ContactDataModel>(query, new { Id = id })).FirstOrDefault();

                var contact = _mapper.Map<Contact>(contactDataModel);

                return contact;

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
                var query = "SELECT * FROM shiva where IsDeleted = 0";
                IEnumerable<ContactDataModel> contactsData = (await _db.QueryAsync<ContactDataModel>(query)).ToList();

                IEnumerable<Contact> contactList = contactsData.Select(item => _mapper.Map<Contact>(item)).ToList();

                return contactList;
            }
            catch (Exception)
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
                if (length != 0)
                {
                    if (contacts.ElementAt(0).Id == id && length >= 2)
                        return contacts.ElementAt(1).Id;

                    for (int i = 1; i < length; i++)
                    {
                        if (contacts.ElementAt(i).Id == id)
                        {
                            return contacts.ElementAt(i - 1).Id;
                        }
                    }
                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
