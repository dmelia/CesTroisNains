using System;

namespace ExerciceThreads
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Alors ces trois nains vont à la mine...");
            
            //Set to 1000000 bags of gold to farm for each mine
            TasksGoldMine._goldBagFarmAmount = 1000000;
            ThreadsGoldMine._goldBagFarmAmount = 1000000;
            ThreadPoolsGoldMine._goldBagFarmAmount = 1000000;
            
            //Make 100 of each miner type
            TasksGoldMine.SimpleMiner(100);
            ThreadsGoldMine.SimpleMiner(100);
            ThreadPoolsGoldMine.SimpleMiner(100);

            Console.ReadKey();
        }
    }
}