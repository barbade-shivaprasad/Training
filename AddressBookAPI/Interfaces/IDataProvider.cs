using System.Data;

namespace AddressBookAPI.Interfaces
{
    public interface IDataProvider
    {
        IDbConnection GetDb();
    }
}