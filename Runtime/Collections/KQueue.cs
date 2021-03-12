using System.Collections.Generic;

namespace kroon.Utils.Collections
{
    public static partial class KCollection
    {
        public static void EnqueueRange<T>(this Queue<T> queue, IEnumerable<T> toBeEnqueued)
        {
            foreach (var item in toBeEnqueued)
            {
                queue.Enqueue(item);
            }
        }

        /// <summary>
        /// Dequeues amount of items from queue, or all elements if less than amount was in queue
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="amount"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> DequeueRange<T>(this Queue<T> queue, int amount)
        {
            List<T> deqeueud = new List<T>(amount);
            for (int i = 0; i < amount || queue.Count <= 0; i++)
            {
                queue.Dequeue();
            }
            return deqeueud;
        }
    }
}