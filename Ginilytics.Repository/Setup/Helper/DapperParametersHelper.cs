using Dapper;
using System.Data;
using System.Reflection;

namespace Ginilytics.Repository.Setup.Helper
{
    public static class DapperParametersHelper
    {
        /// <summary>
        /// Converts Type "T" to type "DynamicParameters"
        /// </summary>
        /// <returns></returns>
        public static DynamicParameters GetDynamicParameters<T>(T model)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(model);

            return dynamicParameters;
        }

        /// <summary>
        /// Converts any List of type "T" to DataTable
        /// </summary>        
        /// <returns>DataTable</returns>
        public static DataTable CreateDataTable<T>(List<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

    }
}