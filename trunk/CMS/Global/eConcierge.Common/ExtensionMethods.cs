using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace eConcierge.Common
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> source, string sortExpression, string sortDicection)
        {
            var param = Expression.Parameter(typeof(T), string.Empty);
            try
            {
                var property = Expression.Property(param, sortExpression);
                var sortLambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), param);

                if (sortDicection.Equals("DESC", StringComparison.OrdinalIgnoreCase))
                {
                    return source.AsQueryable<T>().OrderByDescending<T, object>(sortLambda);
                }
                return source.AsQueryable<T>().OrderBy<T, object>(sortLambda);
            }
            catch (ArgumentException)
            {
                return source;
            }
        }

        public static int ToInteger(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return Convert.ToInt32(value);
        }

    }
}
