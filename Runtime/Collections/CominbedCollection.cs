using System;
using System.Collections;
using System.Collections.Generic;
using kroon.Utils.Maths;

namespace kroon.Utils.Collections
{
    /// <summary>
    /// Provides functionality for acutally appending lists instead of their items
    /// With enumerator, go over each item in sequence seamlessly
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CominbedList<T> : IReadOnlyCollection<T>
    {
        List<List<T>> _lists;

        public CominbedList(params List<T>[] collection)
        {
            _lists = new List<List<T>>(collection);
        }

        public int Count => _lists.Sum((List<T> l) => l.Count);

        public void AddRange(params List<T>[] lists)
        {
            AddRange((IEnumerable<List<T>>)lists);
        }

        public void AddRange(IEnumerable<List<T>> lists)
        {
            _lists.AddRange(lists);
        }

        /// <summary>
        /// Generates new list from combined list
        /// </summary>
        /// <returns></returns>
        public List<T> ToList()
        {
            List<T> l = new List<T>(_lists.Sum(l => l.Count));
            foreach (var list in _lists)
            {
                l.AddRange(list);
            }
            return l;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var list in _lists)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    yield return list[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();
    }

    public static class RRIterator
    {
        public static IEnumerable<(T before, T current, T next)> Kernel<T>(this IEnumerable<T> enumerable)
        {
            var enumerator = enumerable.GetEnumerator();
            var (before, current, after) = ((T)default, (T)default, (T)default);

            if (!SetInitial())
            {
                yield return Kernel();
            }

            yield return (before, current, after);

            while (enumerator.MoveNext())
            {
                (before, current, after) = (current, after, enumerator.Current);
                yield return (before, current, after);

            }

            (T, T, T) Kernel() => (before, current, after);
            bool SetValue(IEnumerator<T> enumerator, ref T val)
            {
                if (enumerator.MoveNext())
                {
                    val = enumerator.Current;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            bool SetInitial()
            {
                if (!SetValue(enumerator, ref before))
                {
                    return false;
                }
                if (!SetValue(enumerator, ref current))
                {
                    return false;
                }
                if (!SetValue(enumerator, ref after))
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Iterate only over items that match filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        {
            foreach (var item in enumerable)
            {
                if (predicate(item))
                    yield return item;
            }
        }
    }
}