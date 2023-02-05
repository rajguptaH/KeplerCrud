namespace KeplerCrud.Utility
{
    /// <summary>
    /// Attribute For Table
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
