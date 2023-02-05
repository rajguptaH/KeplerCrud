using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerCrud.Utility
{

    [AttributeUsage(AttributeTargets.Class)]
    public class KeplerTableAttribute : Attribute
    {
        public string TableName { get; set; }
        public KeplerTableAttribute(string name)
        {
            TableName = name;
        }
    }
}
