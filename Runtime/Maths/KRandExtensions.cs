using System;
namespace kroon.Utils.Maths
{
    public static class KRandExtensions
    {
        private static KRand _rand = new KRand((uint)DateTimeOffset.UtcNow.Millisecond);

        public static T Sample<T>(this T[] items)
        {
            return _rand.Sample(items);
        }
    }
}
