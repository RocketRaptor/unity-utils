using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace kroon.Utils.Collections
{
    public static partial class KConverter
    {
        /// <summary>
        /// Returns new list with converted elements
        /// </summary>
        /// <param name="oldList"></param>
        /// <typeparam name="IN"></typeparam>
        /// <typeparam name="OUT"></typeparam>
        /// <returns></returns>
        public static List<OUT> ToList<IN, OUT>(this List<IN> oldList, Converter<IN, OUT> converter)
        {
            return oldList.ConvertAll<OUT>(converter);
        }

        /// <summary>
        /// Returns new list with converted elements
        /// </summary>
        /// <param name="oldArr"></param>
        /// <typeparam name="IN"></typeparam>
        /// <typeparam name="OUT"></typeparam>
        /// <returns></returns>
        public static List<OUT> ToList<IN, OUT>(this IN[] oldArr, Converter<IN, OUT> converter)
        {
            return new List<OUT>(
                Array.ConvertAll<IN, OUT>(oldArr, converter)
            );
        }

        /// <summary>
        ///  Returns new array with converted elements
        /// </summary>
        /// <param name="oldArr"></param>
        /// <typeparam name="IN"></typeparam>
        /// <typeparam name="OUT"></typeparam>
        /// <returns></returns>
        public static OUT[] ToArray<IN, OUT>(this IN[] oldArr, Converter<IN, OUT> converter)
        {
            return Array.ConvertAll<IN, OUT>(oldArr, converter);
        }

        public static OUT[] ToArray<IN, OUT>(this List<IN> oldList, Converter<IN, OUT> converter)
        {
            OUT[] array = new OUT[oldList.Count];

            for (int i = 0; i < oldList.Count; i++)
            {
                array[i] = converter(oldList[i]);
            }
            return array;
        }

        public static List<T> ToList<T>(this (T, T) tuple)
        {
            return new List<T> {
                tuple.Item1, tuple.Item2
            };
        }

        public static List<T> ToList<T>(this (T, T, T) tuple)
        {
            return new List<T> {
                tuple.Item1, tuple.Item2, tuple.Item3
            };
        }

        public static List<T> ToList<T>(this (T, T, T, T) tuple)
        {
            return new List<T> {
                tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4
            };
        }
    }

    public static partial class KConverter
    {
        public static Vector2 ToVector2(Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }

        public static Vector2 ToVector2(float2 f)
        {
            return (Vector2)f;
        }

        public static Vector3 ToVector3(Vector2 v)
        {
            return new Vector3(v.x, v.y);
        }

        public static Vector3 ToVector3(float3 f)
        {
            return (Vector3)f;
        }

        public static float2 ToFloat2(Vector2 v)
        {
            return (float2)v;
        }

        public static float2 ToFloat2(Vector3 v)
        {
            return new float2(v.x, v.y);
        }

        public static float2 ToFloat2(float3 f)
        {
            return new float2(f.x, f.y);
        }
    }
}