using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircompanyTests
{
    internal static class IEnumerableExtensions
    {

        
        public static bool IsOrderedBy<TSource, TSelected>(this IEnumerable<TSource> source, Func<TSource, TSelected> selector) where TSelected : IComparable<TSelected>
            => source.Select(selector).IsOrdered();

        public static bool IsOrderedBy<TSource, TSelected>(this IEnumerable<TSource> source, Func<TSource, TSelected> selector, Comparison<TSelected> comparator) 
            => source.Select(selector).IsOrderedBy(comparator);


        public static bool IsOrdered<TSource>(this IEnumerable<TSource> source) where TSource : IComparable<TSource>
            => source.IsOrderedBy(comparator: (l, r) => l.CompareTo(r));
        

        public static bool IsOrderedBy<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparator) 
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));

            ArgumentNullException.ThrowIfNull(comparator, nameof(comparator));

            bool isOrdered = true;

            foreach (var (current, next) in source.Zip(source.Skip(1)))
            {
                if (next is not null)
                {
                    isOrdered &= comparator(next, current) >= 0;
                }
            }

            return isOrdered;
        }
    }
}
