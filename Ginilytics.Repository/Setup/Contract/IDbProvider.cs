namespace Ginilytics.Repository.Setup.Contract
{
    public interface IDbProvider
    {
        /// <summary>
        /// Executes the query/proc and returns a IEnumerable of the specified type "T"
        /// </summary>
        /// <typeparam name="T">Output type</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns></returns>
        IEnumerable<T> ExecuteQuery<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and returns a IEnumerable of the specified type "T"
        /// </summary>
        /// <typeparam name="T">Output type</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns></returns>
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and returns an object of the specified type "T"
        /// </summary>
        /// <typeparam name="T">Output type</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>First record from the list</returns>
        T ExecuteFirst<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and returns an object of the specified type "T"
        /// </summary>
        /// <typeparam name="T">Output type</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>First record from the list</returns>
        Task<T> ExecuteFirstAsync<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and returns a scallar of specified type "T"
        /// </summary>
        /// <typeparam name="T">Outypt type</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Scallar of type "T"</returns>
        T ExecuteScalar<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and returns a scallar of specified type "T"
        /// </summary>
        /// <typeparam name="T">Outypt type</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Scallar of type "T"</returns>
        Task<T> ExecuteScalarAsync<T>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and yeilds an IEnumerable of dynamic type 
        /// </summary>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Multiple IEnumerable objects</returns>
        IEnumerable<IEnumerable<dynamic>> MultipleResultSet(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and yeilds an IEnumerable of dynamic type 
        /// </summary>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Multiple IEnumerable objects</returns>
        IAsyncEnumerable<IEnumerable<dynamic>> MultipleResultSetAsync(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and yeilds an IEnumerable 
        /// </summary>
        /// <typeparam name="TOut1">Type of list at index 0</typeparam>
        /// <typeparam name="TOut2">Type of list at index 1</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Multiple IEnumerable objects of mentioned types</returns>
        IEnumerable MultipleResultSet<TOut1, TOut2>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and yeilds an IEnumerable 
        /// </summary>
        /// <typeparam name="TOut1">Type of list at index 0</typeparam>
        /// <typeparam name="TOut2">Type of list at index 1</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Multiple IEnumerable objects of mentioned types</returns>
        IAsyncEnumerable<dynamic> MultipleResultSetAsync<TOut1, TOut2>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and yeilds an IEnumerable 
        /// </summary>
        /// <typeparam name="TOut1">Type of list at index 0</typeparam>
        /// <typeparam name="TOut2">Type of list at index 1</typeparam>
        /// <typeparam name="TOut3">Type of list at index 2</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Multiple IEnumerable objects of mentioned types</returns>
        IEnumerable MultipleResultSet<TOut1, TOut2, TOut3>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and yeilds an IEnumerable 
        /// </summary>
        /// <typeparam name="TOut1">Type of list at index 0</typeparam>
        /// <typeparam name="TOut2">Type of list at index 1</typeparam>
        /// <typeparam name="TOut3">Type of list at index 2</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Multiple IEnumerable objects of mentioned types</returns>
        IAsyncEnumerable<dynamic> MultipleResultSetAsync<TOut1, TOut2, TOut3>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and yeilds a IEnumerable 
        /// </summary>
        /// <typeparam name="TOut1">Type of list at index 0</typeparam>
        /// <typeparam name="TOut2">Type of list at index 1</typeparam>
        /// <typeparam name="TOut3">Type of list at index 2</typeparam>
        /// <typeparam name="TOut4">Type of list at index 3</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Multiple IEnumerable objects of mentioned types</returns>
        IEnumerable MultipleResultSet<TOut1, TOut2, TOut3, TOut4>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and yeilds a IEnumerable 
        /// </summary>
        /// <typeparam name="TOut1">Type of list at index 0</typeparam>
        /// <typeparam name="TOut2">Type of list at index 1</typeparam>
        /// <typeparam name="TOut3">Type of list at index 2</typeparam>
        /// <typeparam name="TOut4">Type of list at index 3</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Multiple IEnumerable objects of mentioned types</returns>
        IAsyncEnumerable<dynamic> MultipleResultSetAsync<TOut1, TOut2, TOut3, TOut4>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and yeilds a IEnumerable 
        /// </summary>
        /// <typeparam name="TOut1">Type of list at index 0</typeparam>
        /// <typeparam name="TOut2">Type of list at index 1</typeparam>
        /// <typeparam name="TOut3">Type of list at index 2</typeparam>
        /// <typeparam name="TOut4">Type of list at index 3</typeparam>
        /// <typeparam name="TOut5">Type of list at index 4</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Multiple IEnumerable objects of mentioned types</returns>
        IEnumerable MultipleResultSet<TOut1, TOut2, TOut3, TOut4, TOut5>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc and yeilds a IEnumerable 
        /// </summary>
        /// <typeparam name="TOut1">Type of list at index 0</typeparam>
        /// <typeparam name="TOut2">Type of list at index 1</typeparam>
        /// <typeparam name="TOut3">Type of list at index 2</typeparam>
        /// <typeparam name="TOut4">Type of list at index 3</typeparam>
        /// <typeparam name="TOut5">Type of list at index 4</typeparam>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        /// <returns>Multiple IEnumerable objects of mentioned types</returns>
        IAsyncEnumerable<dynamic> MultipleResultSetAsync<TOut1, TOut2, TOut3, TOut4, TOut5>(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);


        /// <summary>
        /// Executes the query/proc
        /// </summary>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>        
        int Execute(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query/proc
        /// </summary>
        /// <param name="procedureName">Name of the procedure/ Query text</param>
        /// <param name="param">Parameters to the query or skip when none</param>
        /// <param name="commandType">Command type when query is not stored procedure</param>
        Task<int> ExecuteAsync(string procedureName, object param = null, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure);
    }
}