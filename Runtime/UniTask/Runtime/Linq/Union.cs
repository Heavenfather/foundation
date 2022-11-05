﻿using Pancake.Threading.Tasks.Internal;
using System.Collections.Generic;

namespace Pancake.Threading.Tasks.Linq
{
    public static partial class UniTaskAsyncEnumerable
    {
        public static IUniTaskAsyncEnumerable<TSource> Union<TSource>(this IUniTaskAsyncEnumerable<TSource> first, IUniTaskAsyncEnumerable<TSource> second)
        {
            Error.ThrowArgumentNullException(first, nameof(first));
            Error.ThrowArgumentNullException(second, nameof(second));

            return Union<TSource>(first, second, EqualityComparer<TSource>.Default);
        }

        public static IUniTaskAsyncEnumerable<TSource> Union<TSource>(this IUniTaskAsyncEnumerable<TSource> first, IUniTaskAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            Error.ThrowArgumentNullException(first, nameof(first));
            Error.ThrowArgumentNullException(second, nameof(second));
            Error.ThrowArgumentNullException(comparer, nameof(comparer));

            // improv without combinate?
            return first.Concat(second).Distinct(comparer);
        }
    }
}