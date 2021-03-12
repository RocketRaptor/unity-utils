using System.Collections.Generic;
using URandom = Unity.Mathematics.Random;

namespace kroon.Utils.Maths
{
    //TODO: RRRand with 3 r
    public class KRand
    {
        private URandom _random;

        public KRand(uint seed = 67)
        {
            _random = new URandom(seed);
        }

        public T Sample<T>(params T[] items) => items[_random.NextInt(0, items.Length)];
        public T Sample<T>(List<T> items) => items[_random.NextInt(0, items.Count)];
    }
}
