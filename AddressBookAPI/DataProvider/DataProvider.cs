using AddressBookAPI.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AddressBookAPI.DataProvider
{
    public class DataProvider : IDataProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection db;

        public DataProvider(IConfiguration configuration)
        {
            _configuration = configuration;

            db = new SqlConnection(_configuration.GetConnectionString("tempConnection")); ;
        }

        public IDbConnection GetDb()
        {
            return db;
        }
    }
}
