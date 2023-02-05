using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerCrud.Utility
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KeplerColumnAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public KeplerColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
        public KeplerColumnAttribute()
        {

        }
    }
}
