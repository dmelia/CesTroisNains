using System;

namespace ExerciceThreads
{
    public class RandomNumberGenerator
    {
        private static Random random = new(DateTime.Now.Millisecond);

        public static int RandomNumber()
        {
            return random.Next(1, 5);
        }
    }
}