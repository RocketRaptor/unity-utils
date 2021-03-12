using System;
using Unity.Mathematics;
using kroon.Utils.Collections;
using System.Collections.Generic;

namespace kroon.Utils.Maths
{
    public static partial class KRMath
    {
        public static int Sum<T>(this IEnumerable<T> options, Func<T, int> extractor)
        {
            int val = 0;
            foreach (var option in options)
                val += extractor(option);

            return val;
        }

        public static float Sum<T>(this IEnumerable<T> options, Func<T, float> extractor)
        {
            float val = 0;
            foreach (var option in options)
                val += extractor(option);

            return val;
        }

        public static double Sum<T>(this IEnumerable<T> options, Func<T, double> extractor)
        {
            double val = 0;
            foreach (var option in options)
                val += extractor(option);

            return val;
        }

        public static float Slope(int2 A, int2 B)
        {
            return (float)(A.y - B.y) / (float)(A.x - B.x);
        }

        public static float Slope(float2 A, float2 B)
        {
            return (A.y - B.y) / (A.x - B.x);
        }

        public static float Slope((int x, int y) A, (int x, int y) B)
        {
            return (float)(A.y - B.y) / (float)(A.x - B.x);
        }

        public static float Slope((float x, float y) A, (float x, float y) B)
        {
            return (A.y - B.y) / (A.x - B.x);
        }

        public static float AngleRad(float2 a, float2 b) =>
            math.degrees(math.atan2(b.y - a.y, b.x - a.x));

        public static float AngleRad(int2 a, int2 b) =>
            math.degrees(math.atan2(b.y - a.y, b.x - a.x));

        public static int2 ClosestPoint(int2 point, params int2[] options)
        {
            return options.Min(option => math.distance(point, option));
        }

        public static float2 ClosestPoint(float2 point, params float2[] options)
        {
            return options.Min(option => math.distance(point, option));
        }
    }

    public static class RRPhysics
    {
        /**
         * Accelaration code snippets from:
         * https://www.engineeringtoolbox.com/acceleration-velocity-d_1769.html
         * */

        /// <summary>
        /// Distance based on (a)cceleration and (t)ime
        /// </summary>
        /// <param name="a"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float GetDistanceAcc(float a, float t)
        {
            return (a * math.pow(t, 2f)) / 2f;
        }

        /// <summary>
        /// Distance based on constant velocity and (t)ime
        /// </summary>
        /// <param name="vConst"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float GetDistanceConst(float vConst, float t)
        {
            return vConst * t;
        }

        /// <summary>
        /// Time based on average speed and (d)istance
        /// </summary>
        /// <param name="vAverage"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static float GetTime(float vAverage, float d)
        {
            return d / vAverage;
        }

        /// <summary>
        /// Acceleration based on initial and final velocity and time
        /// </summary>
        /// <param name="vInit"></param>
        /// <param name="vFinal"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float GetAcceleration(float vInit, float vFinal, float t)
        {
            if (t == 0) return int.MaxValue;
            return (vFinal - vInit) / t; ;
        }

        public static float GetAccelerationWithDst(float vInit, float vFinal, float d)
        {
            return (math.pow(vFinal, 2f) - math.pow(vInit, 2f)) / (2f * d);
        }

        public static float GetAverageVelocity(float vInit, float vFinal)
        {
            return (vInit + vFinal) / 2f;
        }

        public static float GetVelocity(float d, float t)
        {
            return d / t;
        }
    }
}
