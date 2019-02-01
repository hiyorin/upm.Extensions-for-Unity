using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnityExtensions
{
    /// <summary>
    /// IEnumerable extensions.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Find min item.
        /// </summary>
        public static TSource FindMin<TSource, TResult>(this IEnumerable<TSource> self, Func<TSource, TResult> selector)
        {
            if (self.Count() <= 0)
            {
                return default(TSource);
            }
            return self.FirstOrDefault(c => selector(c).Equals(self.Min(selector)));
        }

        /// <summary>
        /// Find max item.
        /// </summary>
        public static TSource FindMax<TSource, TResult>(this IEnumerable<TSource> self, Func<TSource, TResult> selector)
        {
            if (self.Count() <= 0)
            {
                return default(TSource);
            }
            return self.FirstOrDefault(c => selector(c).Equals(self.Max(selector)));
        }

        /// <summary>
        /// foreach
        /// </summary>
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> self, Action<TSource> func)
        {
            if (func != null)
            {
                foreach (TSource source in self)
                {
                    func(source);
                }
            }
            return self;
        }

        /// <summary>
        /// foreach
        /// </summary>
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> self, Action<int, TSource> func)
        {
            if (func != null)
            {
                foreach (var row in self.Select((obj, index) => new { obj, index }))
                {
                    func(row.index, row.obj);
                }
            }
            return self;
        }

        /// <summary>
        /// foreach
        /// </summary>
        public static IEnumerable ForEach(this IEnumerable self, Action<object> func)
        {
            if (func != null)
            {
                foreach (var row in self)
                {
                    func(row);
                }
            }
            return self;
        }

        /// <summary>
        /// foreach
        /// </summary>
        public static IEnumerable ForEach(this IEnumerable self, Action<int, object> func)
        {
            if (func != null)
            {
                int index = 0;
                foreach (var row in self)
                {
                    func(index++, row);
                }
            }
            return self;
        }

        /// <summary>
        /// Distinct the specified source and selector.
        /// </summary>
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> self, Func<TSource, TKey> selector)
        {
            return self.Distinct(new CommonSelector<TSource, TKey>(selector));
        }

        /// <summary>
        /// Divide the specified collection and divisions.
        /// </summary>
        public static IEnumerable<IEnumerable<TSource>> Divide<TSource>(this IEnumerable<TSource> self, int divisions)
        {
            int capacity = self.Count() / divisions;
            int remainder = self.Count() % divisions;

            using (var enumerator = self.GetEnumerator())
            {
                for (int i = 0; i < remainder; i++)
                    yield return Take(enumerator, capacity + 1);

                for (int i = remainder; i < divisions; i++)
                    yield return Take(enumerator, capacity);
            }
        }

        /// <summary>
        /// Take the specified enumerator and count.
        /// </summary>
        public static IEnumerable<TSource> Take<TSource>(IEnumerator<TSource> self, int count)
        {
            while (--count >= 0 && self.MoveNext())
                yield return self.Current;
        }

        private sealed class CommonSelector<TSource, TKey> : IEqualityComparer<TSource>
        {
            private Func<TSource, TKey> m_selector;

            public CommonSelector(Func<TSource, TKey> selector)
            {
                m_selector = selector;
            }

            public bool Equals(TSource x, TSource y)
            {
                return m_selector(x).Equals(m_selector(y));
            }

            public int GetHashCode(TSource obj)
            {
                return m_selector(obj).GetHashCode();
            }
        }
    }
}
