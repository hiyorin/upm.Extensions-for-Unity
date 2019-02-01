using System;

namespace UnityExtensions
{
    /// <summary>
    /// Array extensions.
    /// </summary>
    public static class ArrayExtensions
    {
        public static void ForEach<TSource>(this TSource[] self, Action<TSource> func)
        {
            if (func == null)
            {
                return;
            }

            foreach(TSource row in self)
            {
                func(row);
            }
        }
    }
}
