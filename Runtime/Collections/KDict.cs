using System;
using System.Collections.Generic;

namespace kroon.Utils.Collections
{
    public static partial class KCollection
    {
        /// <summary>
        /// Get value of key, if null add defaultValue
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <returns></returns>
        public static K TryGetOrAddDefault<T, K>(this Dictionary<T, K> dict, T key, Func<K> defaultValue)
                where K : class
        {
            K val;
            if (!dict.TryGetValue(key, out val))
            {
                dict.Add(key, defaultValue?.Invoke() ?? default);
            };

            return val;
        }

        /// <summary>
        /// Get value by key and execute action either with value, or if null with inserted defaultValue
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <returns></returns>
        public static K ActionOnGetOrDefault<T, K>(this Dictionary<T, K> dict, T key, Func<K> defaultValue, Action<K> action)
            where K : class
        {
            K val = TryGetOrAddDefault(dict, key, defaultValue);
            action?.Invoke(val);

            return val;
        }
    }
}