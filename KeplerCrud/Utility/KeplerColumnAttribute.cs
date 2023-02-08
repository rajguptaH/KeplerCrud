namespace KeplerCrud.Utility
{
    /// <summary>
    /// Use As Column Name Which Exist in Database Or Put Empty () For Using Property Name As Well As
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class KeplerColumnAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public KeplerColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
        /// <summary>
        /// This Will Take Property Name Automaticly
        /// </summary>
        public KeplerColumnAttribute()
        {

        }
    }
}
