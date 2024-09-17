using System;
using System.Data.SqlClient;

namespace Ginilytics.Repository.Setup.Provider
{
    public class ConnectionProvider : IDisposable
    {
        internal SqlConnection dbConn;
        private readonly string _connString;
        internal ConnectionProvider(string connString)
        {
            _connString = connString;
            OpenDBConn();
        }

        void IDisposable.Dispose()
        {
            dbConn.Close();
            dbConn.Dispose();
        }
        void OpenDBConn()
        {
            dbConn = new SqlConnection(_connString);
            dbConn.Open();
        }
    }
}