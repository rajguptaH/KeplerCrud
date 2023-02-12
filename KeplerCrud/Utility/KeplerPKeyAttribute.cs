using System;

namespace KeplerCrud.Utility
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KeplerPKeyAttribute : Attribute
    {
        public string PKey { get; set; }
        /// <summary>
        /// Provide Primary Key Of Your Table
        /// </summary>
        /// <param name="name"></param>
        public KeplerPKeyAttribute(string name)
        {
            PKey = name;
        }
    }
}
