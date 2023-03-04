using Address_book.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Address_book.Data
{
    public class DataProvider : IDataProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection db;

        public DataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            db = new SqlConnection(_configuration.GetConnectionString("contactsConnection")); ;
        }

        public IDbConnection GetDb()
        {
            return db;
        }
    }
}
