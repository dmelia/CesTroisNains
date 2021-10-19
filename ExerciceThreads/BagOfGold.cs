using System;

namespace ExerciceThreads
{
    public class BagOfGold
    {
        public int GoldNuggets { get; set; }

        public BagOfGold(int goldNuggets, string originName)
        {
            GoldNuggets = goldNuggets;
            //Below code is commented so as to not pollute the Console
            //Console.WriteLine("Got a Bag of {0} gold nuggets, from origin : {1}", goldNuggets, originName);
        }
    }
}