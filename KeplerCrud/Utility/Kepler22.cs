using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KeplerCrud.Utility
{
    internal static class Kepler22
    {
        public static string GetTableName<T>()
        {
            var tableAttribute = typeof(T).GetCustomAttribute(typeof(KeplerTableAttribute), true) as KeplerTableAttribute;
            if (tableAttribute != null)
            {
                return tableAttribute.TableName;
            }
            return null;
        }
        public static List<string> GetDbColumnName<T>()
        {
            var _columns = new List<string>();
            PropertyInfo[] propertieList = typeof(T).GetProperties();
            foreach (var prop in propertieList)
            {
                if (Attribute.IsDefined(prop, typeof(KeplerColumnAttribute)))
                {
                    var colName = prop.GetCustomAttribute<KeplerColumnAttribute>().ColumnName;
                    if (colName != null)
                    {
                        _columns.Add(colName);
                    }
                    else
                    {
                        _columns.Add(prop.Name);
                    }
                }
            }
            return _columns;
        }
        public static string GetPKey<T>()
        {
            string _columns = null;
            PropertyInfo[] propertieList = typeof(T).GetProperties();
            var attributePair = propertieList.Where(x => Attribute.IsDefined(x, typeof(KeplerPKeyAttribute)))
                .Select(x => new KeyValuePair<string, string>(x.GetCustomAttribute<KeplerPKeyAttribute>().PKey, x.Name)).First();
            if (attributePair.Key != null)
            {
                _columns = attributePair.Key;
            }
            else
            {
                _columns = attributePair.Value;
            }
            return _columns;
        }

    }
}
