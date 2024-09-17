using Dapper;
using Ginilytics.Repository.Setup.Contract;

namespace Ginilytics.Repository.Setup.Provider
{
    internal class DbProvider : IDbProvider
    {
        private readonly string _connectionString;
        public DbProvider(string conn)
        {
            _connectionString = conn;
        }
        /// <inheritdoc/>
        public IEnumerable<T> ExecuteQuery<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            return conn.dbConn.Query<T>(procedureName, param, commandType: commandType);
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            return await conn.dbConn.QueryAsync<T>(procedureName, param, commandType: commandType);
        }
        /// <inheritdoc/>
        public T ExecuteFirst<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            return conn.dbConn.QueryFirstOrDefault<T>(procedureName, param, commandType: commandType);
        }

        /// <inheritdoc/>
        public async Task<T> ExecuteFirstAsync<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            return await conn.dbConn.QueryFirstOrDefaultAsync<T>(procedureName, param, commandType: commandType);
        }
        /// <inheritdoc/>
        public T ExecuteScalar<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            return conn.dbConn.ExecuteScalar<T>(procedureName, param, commandType: commandType);
        }
        /// <inheritdoc/>
        public async Task<T> ExecuteScalarAsync<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            return await conn.dbConn.ExecuteScalarAsync<T>(procedureName, param, commandType: commandType);
        }

        /// <inheritdoc/>
        public IEnumerable<IEnumerable<dynamic>> MultipleResultSet(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            using var result = conn.dbConn.QueryMultiple(procedureName, param, commandType: commandType);
            while (!result.IsConsumed)
            {
                yield return result.Read();
            }
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<IEnumerable<dynamic>> MultipleResultSetAsync(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            using var result = await conn.dbConn.QueryMultipleAsync(procedureName, param, commandType: commandType);
            while (!result.IsConsumed)
            {
                yield return result.Read();
            }
        }

        /// <inheritdoc/>
        public IEnumerable MultipleResultSet<TOut1, TOut2>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            using var result = conn.dbConn.QueryMultiple(procedureName, param, commandType: commandType);
            int index = 0;
            while (!result.IsConsumed)
            {
                if (index == 0)
                    yield return result.Read<TOut1>();
                if (index == 1)
                    yield return result.Read<TOut2>();

                index++;
            }
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<dynamic> MultipleResultSetAsync<TOut1, TOut2>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            using var result = await conn.dbConn.QueryMultipleAsync(procedureName, param, commandType: commandType);
            int index = 0;
            while (!result.IsConsumed)
            {
                if (index == 0)
                    yield return result.Read<TOut1>();
                if (index == 1)
                    yield return result.Read<TOut2>();

                index++;
            }
        }

        /// <inheritdoc/>
        public IEnumerable MultipleResultSet<TOut1, TOut2, TOut3>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            using var result = conn.dbConn.QueryMultiple(procedureName, param, commandType: commandType);
            int index = 0;
            while (!result.IsConsumed)
            {
                if (index == 0)
                    yield return result.Read<TOut1>();
                if (index == 1)
                    yield return result.Read<TOut2>();
                if (index == 2)
                    yield return result.Read<TOut3>();
                index++;
            }
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<dynamic> MultipleResultSetAsync<TOut1, TOut2, TOut3>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            using var result = await conn.dbConn.QueryMultipleAsync(procedureName, param, commandType: commandType);
            int index = 0;
            while (!result.IsConsumed)
            {
                if (index == 0)
                    yield return result.Read<TOut1>();
                if (index == 1)
                    yield return result.Read<TOut2>();
                if (index == 2)
                    yield return result.Read<TOut3>();
                index++;
            }
        }

        /// <inheritdoc/>
        public IEnumerable MultipleResultSet<TOut1, TOut2, TOut3, TOut4>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            using var result = conn.dbConn.QueryMultiple(procedureName, param, commandType: commandType);
            int index = 0;
            while (!result.IsConsumed)
            {
                if (index == 0)
                    yield return result.Read<TOut1>();
                if (index == 1)
                    yield return result.Read<TOut2>();
                if (index == 2)
                    yield return result.Read<TOut3>();
                if (index == 3)
                    yield return result.Read<TOut4>();
                index++;
            }
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<dynamic> MultipleResultSetAsync<TOut1, TOut2, TOut3, TOut4>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            using var result = await conn.dbConn.QueryMultipleAsync(procedureName, param, commandType: commandType);
            int index = 0;
            while (!result.IsConsumed)
            {
                if (index == 0)
                    yield return result.Read<TOut1>();
                if (index == 1)
                    yield return result.Read<TOut2>();
                if (index == 2)
                    yield return result.Read<TOut3>();
                if (index == 3)
                    yield return result.Read<TOut4>();
                index++;
            }
        }


        /// <inheritdoc/>
        public IEnumerable MultipleResultSet<TOut1, TOut2, TOut3, TOut4, TOut5>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            using var result = conn.dbConn.QueryMultiple(procedureName, param, commandType: commandType);
            int index = 0;
            while (!result.IsConsumed)
            {
                if (index == 0)
                    yield return result.Read<TOut1>();
                if (index == 1)
                    yield return result.Read<TOut2>();
                if (index == 2)
                    yield return result.Read<TOut3>();
                if (index == 3)
                    yield return result.Read<TOut4>();
                if (index == 4)
                    yield return result.Read<TOut5>();
                index++;
            }
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<dynamic> MultipleResultSetAsync<TOut1, TOut2, TOut3, TOut4, TOut5>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            using var result = await conn.dbConn.QueryMultipleAsync(procedureName, param, commandType: commandType);
            int index = 0;
            while (!result.IsConsumed)
            {
                if (index == 0)
                    yield return result.Read<TOut1>();
                if (index == 1)
                    yield return result.Read<TOut2>();
                if (index == 2)
                    yield return result.Read<TOut3>();
                if (index == 3)
                    yield return result.Read<TOut4>();
                if (index == 4)
                    yield return result.Read<TOut5>();
                index++;
            }
        }

        /// <inheritdoc/>
        public int Execute(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            return conn.dbConn.Execute(procedureName, param, commandType: commandType);
        }

        /// <inheritdoc/>
        public async Task<int> ExecuteAsync(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure)
        {
            using var conn = new ConnectionProvider(_connectionString);
            return await conn.dbConn.ExecuteAsync(procedureName, param, commandType: commandType);
        }
    }
}