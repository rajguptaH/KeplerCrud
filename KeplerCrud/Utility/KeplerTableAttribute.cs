using System;

namespace KeplerCrud.Utility
{
    /// <summary>
    /// Provide Your Table Name
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class KeplerTableAttribute : Attribute
    {
        public string TableName { get; set; }
        /// <summary>
        /// Provide Table Name 
        /// </summary>
        /// <param name="name"></param>
        public KeplerTableAttribute(string name)
        {
            TableName = name;
        }
    }
}
