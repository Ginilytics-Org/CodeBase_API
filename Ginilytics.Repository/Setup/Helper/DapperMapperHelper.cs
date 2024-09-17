using System.Reflection;

namespace Ginilytics.Repository.Setup.Helper
{
    internal class DapperMapperHelper
    {
        public static T ConvertFromDapperResponse<T>(dynamic data)
        {
            var row = (IDictionary<string, object>)data;
            var instance = Activator.CreateInstance(typeof(T));

            foreach (var prop in row)
            {
                PropertyInfo info = typeof(T).GetProperties().FirstOrDefault(x => x.Name.ToLower() == prop.Key.ToLower());
                if (info != null)
                {
                    var value = prop.Value;
                    try
                    {
                        if (value != null)
                            if (info.PropertyType.IsGenericType)
                                info.SetValue(instance, Convert.ChangeType(value, info.PropertyType.GenericTypeArguments[0]));
                            else
                                info.SetValue(instance, Convert.ChangeType(value, info.PropertyType));
                    }
                    catch (Exception ex)
                    {
                        Exception exception;

                        if (info.PropertyType.IsGenericType)
                            exception =
                                new Exception(
                                        message:
                                            string.Format("Error occured when trying to convert 'PropertyType.GenericTypeArgument': {0} to {1} for 'Property Name': {2}",
                                                value,
                                                info.PropertyType.GenericTypeArguments[0].FullName,
                                                info.Name),
                                        innerException: ex);
                        else
                            exception =
                                new Exception(
                                        message:
                                            string.Format("Error occured when trying to convert 'PropertyType': {0} to {1} for 'Property Name': {2}",
                                                value,
                                                info.PropertyType.FullName,
                                                info.Name),
                                        innerException: ex);

                        throw exception;
                    }
                }
            }

            return (T)instance;
        }

        public static List<T> ConvertFromDapperResponse<T>(IEnumerable<dynamic> data)
        {
            IEnumerable<T> _default = Default<IEnumerable<T>>.Value;
            var result = _default.ToList();
            foreach (var item in data)
            {
                result.Add(ConvertFromDapperResponse<T>(item));
            }

            return result;
        }

        private static class Default<T>
        {
            static Default()
            {
                if (typeof(T).IsArray)
                {
                    if (typeof(T).GetArrayRank() > 1)
                        Value = (T)(object)Array.CreateInstance(typeof(T).GetElementType(), new int[typeof(T).GetArrayRank()]);
                    else
                        Value = (T)(object)Array.CreateInstance(typeof(T).GetElementType(), 0);
                    return;
                }

                if (typeof(T) == typeof(string))
                {
                    // string is IEnumerable<char>, but don't want to treat it like a collection
                    Value = default;
                    return;
                }

                if (typeof(IEnumerable).IsAssignableFrom(typeof(T)))
                {
                    // check if an empty array is an instance of T
                    if (typeof(T).IsAssignableFrom(typeof(object[])))
                    {
                        Value = (T)(object)new object[0];
                        return;
                    }

                    if (typeof(T).IsGenericType && typeof(T).GetGenericArguments().Length == 1)
                    {
                        Type elementType = typeof(T).GetGenericArguments()[0];
                        if (typeof(T).IsAssignableFrom(elementType.MakeArrayType()))
                        {
                            Value = (T)(object)Array.CreateInstance(elementType, 0);
                            return;
                        }
                    }

                    throw new NotImplementedException("No default value is implemented for type " + typeof(T).FullName);
                }

                Value = default;
            }

            public static T Value { get; private set; }
        }
    }
}