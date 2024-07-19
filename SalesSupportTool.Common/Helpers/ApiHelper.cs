using System;
using System.Collections.Generic;

namespace SFFilter.Common.Helpers
{
    public static class ApiHelper
    {
        /// <summary>
        /// If parameter is DateTime, output in a formatted string (default ISO 8601), customizable with Configuration.DateTime.
        /// If parameter is a list of string, join the list with ",".
        /// If parameter is an Enum, returns string representation of the enum value.
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter (header, path, query, form).</param>
        /// <returns>Formatted string.</returns>
        public static string ParameterToString(object obj)
        {
            if (obj is DateTime)
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTime)obj).ToString("o");
            else if (obj is ICollection<string>)
                return string.Join(",", (obj as ICollection<string>));
            else if (obj?.GetType() == typeof(string[]))
                return string.Join(",", (obj as string[]));
            else if (obj is Enum)
                return Enum.GetName(obj.GetType(), obj) ?? string.Empty;
            else
                return Convert.ToString(obj ?? string.Empty);
        }
    }
}