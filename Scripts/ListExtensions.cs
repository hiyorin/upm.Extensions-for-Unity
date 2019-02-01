using System;
using System.Linq;
using System.Collections.Generic;

namespace UnityExtensions
{
    /// <summary>
    /// List extensions.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Replace the specified self, src and func.
        /// </summary>
        public static void Replace<TSource>(this List<TSource> self, IEnumerable<TSource> src, Func<TSource, TSource, bool> func)
        {
            if (func == null) return;
            IEnumerable<TSource> adds = src.Where(x => !self.Any(y => func(x, y)));
            IEnumerable<TSource> removes = self.Where(x => !src.Any(y => func(x, y)));
            adds.ForEach(x => self.Add(x));
            removes.ForEach(x => self.Remove(x));
        }

        /// <summary>
        /// Clears the with add range.
        /// </summary>
        public static void ClearWithAddRange<TSource>(this List<TSource> self, IEnumerable<TSource> adds)
        {
            if (adds == null) return;
            self.Clear();
            self.AddRange(adds);
        }

        /// <summary>
        /// Remove the specified self and func.
        /// </summary>
        public static void Remove<TSource>(this List<TSource> self, Func<TSource, bool> func)
        {
            if (func == null) return;
            IEnumerable<TSource> remove = self.Where(x => func(x)).ToList();
            remove.ForEach(x => self.Remove(x));
        }
    }
}
