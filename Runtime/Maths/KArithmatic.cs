using Unity.Mathematics;

namespace kroon.Utils.Maths
{
    public static partial class KMath
    {
        public static float Round(this float value, float interval = 1f) =>
            math.round(value / interval) * interval;

        public static float Ceil(this float value, float interval = 1f) =>
            math.ceil(value / interval) * interval;

        public static float Floor(this float value, float interval = 1f) =>
            math.floor(value / interval) * interval;

        public static double Round(this double value, double interval = 1d) =>
            math.round(value / interval) * interval;

        public static double Ceil(this double value, double interval = 1d) =>
            math.ceil(value / interval) * interval;

        public static double Floor(this double value, double interval = 1d) =>
            math.floor(value / interval) * interval;

        /// <summary>
        /// Normalizes in range between 0 and 1
        /// </summary>
        /// <param name="v"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float MinMax(float x, float min, float max)
        {
            //Formula from https://stackoverflow.com/a/51389787/9950208

            if (max - min == 0) return 1; // or 0, it's up to you
            return (x - min) / (max - min);
        }

        /// <summary>
        /// Normalizes in range between 0 and 1
        /// </summary>
        /// <param name="v"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float2 MinMax(float2 x, float min, float max)
        {
            //Formula from https://stackoverflow.com/a/51389787/9950208

            return new float2(MinMax(x.x, min, max), MinMax(x.y, min, max));
        }

        /// <summary>
        /// Normalizes in between lower and upper normalized range
        /// </summary>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public static float Normalize(float x, (float min, float max) real, (float min, float max) norm)
        {
            if (real.max - real.min == 0) return 1;
            float mean = norm.max - norm.min; //Assuming upper > lower

            return norm.min + ((x - real.min) * (norm.max - norm.min) / (real.max - real.min)); //Wikipedia
        }
    }
}