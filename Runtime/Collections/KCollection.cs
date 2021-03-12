using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace kroon.Utils.Collections
{
    //TODO: Add zip
    public static partial class KCollection
    {
        public static bool All<T>(this IEnumerable<T> options, Func<T, bool> predicate)
        {
            foreach (var option in options)
            {
                if (!predicate(option)) return false;
            }
            return true;
        }

        public static bool Any<T>(this IEnumerable<T> options, Func<T, bool> predicate)
        {
            foreach (var option in options)
            {
                if (predicate(option)) return true;
            }
            return false;
        }

        public static T Pick<T>(this IEnumerable<T> options, Comparer<T> comparer)
        {
            var enumerator = options.GetEnumerator();
            T pick = enumerator.Current;
            while (enumerator.MoveNext())
            {
                var cur = enumerator.Current;
                if (comparer.Compare(cur, pick) == 1) pick = cur;
            }

            return pick;
        }

        public static T Pick<T>(Comparer<T> comparer, params T[] options)
        {
            T pick = options[0];
            for (int i = 1; i < options.Length; i++)
            {
                if (comparer.Compare(options[i], pick) == 1) pick = options[i];
            }

            return pick;
        }

        /// <summary>
        /// Shuffles list in place
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ShuffleNonAlloc<T>(this List<T> list)
        {
            System.Random rnd = new System.Random();
            for (int i = 0; i < list.Count; i++)
            {
                int j = rnd.Next(0, i);
                T value = list[j];
                list[j] = list[i];
                list[i] = value;
            }
            return list;
        }

        /// <summary>
        /// Returns a copy of list with shuffled elements
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Shuffle<T>(this List<T> list)
        {
            List<T> newList = new List<T>(list);
            System.Random rnd = new System.Random();
            for (int i = 0; i < list.Count; i++)
            {
                int j = rnd.Next(0, i);
                T value = newList[j];
                newList[j] = newList[i];
                newList[i] = value;
            }
            return list;
        }

        public static T Min<T>(this IEnumerable<T> enumerable, Func<T, float> extractor)
        {
            return Pick(enumerable, Comparer<T>.Create((a, b) => (int)math.sign(extractor(b) - extractor(a))));
        }

        public static T Max<T>(this IEnumerable<T> enumerable, Func<T, float> extractor)
        {
            return Pick(enumerable, Comparer<T>.Create((a, b) => (int)math.sign(extractor(a) - extractor(b))));
        }

        public static bool AnyEquals<T>(this T item, IEnumerable<T> options)
        {
            return options.Any(option => option.Equals(item));
        }

        public static bool AnyEquals<T>(this T item, params T[] options)
        {
            return AnyEquals(item, (IEnumerable<T>)options);
        }

        public static bool AnyEquals<T>(this IEnumerable<T> options, T item)
        {
            return AnyEquals(item, options);
        }

        public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            return collection.Count == 0;
        }

        public static int LastIndex<T>(this IList<T> collection)
        {
            return collection.Count - 1;
        }

        public static T LastItem<T>(this IList<T> collection)
        {
            if (collection.Count > 0)
                return collection[LastIndex(collection)];
            return default;
        }

        public static List<OUT> Cast<IN, OUT>(this IEnumerable<IN> enumerable, Converter<IN, OUT> converter, int capacity = 0)
        {
            List<OUT> convertedList = new List<OUT>(capacity);
            foreach (var item in enumerable)
            {
                convertedList.Add(converter(item));
            }
            return convertedList;
        }

        public static List<OUT> Cast<IN, OUT>(this IReadOnlyCollection<IN> collection, Converter<IN, OUT> converter)
        {
            return Cast(collection, converter, collection.Count);
        }

        public static List<T> Take<T>(this List<T> list, Predicate<T> extractor)
        {
            var removed = new List<T>();

            foreach (var item in removed)
            {
                if (extractor(item))
                {
                    removed.Add(item);
                }
            }

            list.RemoveAll(item => removed.Contains(item));
            return removed;
        }

        public static IEnumerable<K> Map<T, K>(this IEnumerable<T> enumerable, Func<T, K> extractor)
        {
            foreach (var item in enumerable)
            {
                yield return extractor(item);
            }
        }

        public static List<T> ListFrom<T>(this T item)
        {
            return new List<T> { item };
        }

        /// <summary>
        /// Mirrors LINQ Enumerable.Repeat()
        /// Adds item, amount times to list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="amount"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Repeat<T>(this List<T> list, int amount, T item)
        {
            for (int i = 0; i < amount; i++)
            {
                list.Add(item);
            };
            return list;
        }

        /// <summary>
        /// Mirrors LINQ Enumerable.Repeat()
        /// Returns list with same item, amount times
        /// </summary>
        /// <param name="list"></param>
        /// <param name="amount"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Repeat<T>(int amount, T item)
        {
            List<T> list = new List<T>(amount);
            for (int i = 0; i < amount; i++)
            {
                list.Add(item);
            };
            return list;
        }

        /// <summary>
        /// Remove all elements in collection which are contained in toBeRemoved. 
        /// Also works if collection and toBeRemoved are pointing to same reference
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="toBeRemoved"></param>
        /// <typeparam name="T"></typeparam>
        public static void RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> toBeRemoved)
        {
            if (collection.Equals(toBeRemoved))
            {
                collection.Clear();
                return;
            }

            foreach (var item in toBeRemoved)
            {
                collection.Remove(item);
            }
        }

        public static void RemoveMatch<T>(this List<T> list, List<T> toBeRemoved)
        {
            list.RemoveAll(elem => toBeRemoved.Contains(elem));
        }
    }
}