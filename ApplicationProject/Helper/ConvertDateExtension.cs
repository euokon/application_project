using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationProject.Helper
{
    public static class ConvertDateExtension
    {
        public static DateTime? ToNullableDateTime(this string date)
        {
            return string.IsNullOrEmpty(date) ? (DateTime?)null : Convert.ToDateTime(date);
        }
    }
}
