﻿using ShopBridge.Api.Abstraction;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ShopBridge.Api.SqlDataAccess
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private string connectionString = string.Empty;
        private IDbConnection dbConnection;
        public async Task<IDbConnection> CreateConnectionAsync()
        {
            connectionString = await getConnectionString();
            // get connection string
            dbConnection = new SqlConnection(connectionString);
            return dbConnection;
        }
        /// <summary>
        /// Should give the connection string 
        /// </summary>
        /// <returns></returns>
        private Task<string> getConnectionString() => throw new NotImplementedException();

        public void Dispose()
        {
            ((IDisposable)dbConnection).Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
