using System.Reflection;

namespace KeplerCrud.Utility
{
    public class Kepler22
    {
        public string GetTableName<T>() where T : class
        {
            var tableAttribute = typeof(T).GetCustomAttribute(typeof(KeplerTableAttribute),true) as KeplerTableAttribute;
            if (tableAttribute != null)
            {
                return tableAttribute.TableName;
            }
            return null;
        }
        public List<string> GetDbColumnName<T>()
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
    }
}
