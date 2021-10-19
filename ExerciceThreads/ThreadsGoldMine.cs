using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ExerciceThreads
{
    public class ThreadsGoldMine
    {
        public static int _goldBagFarmAmount { get; set; }
        public static int _goldAmount = 0;
        private static List<Thread> _minerThreads;

        public static void SimpleMiner(int amount)
        {
            GetMinerThreads(amount);
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            RunMinerThreads();
            stopwatch.Stop();

            Console.WriteLine("Threads gold mine made {0}, nuggets of gold ! It took {1} ms to complete", _goldAmount, stopwatch.ElapsedMilliseconds);
        }

        private static void RunMinerThreads()
        {
            foreach (var thread in _minerThreads) thread.Start();
            foreach (var thread in _minerThreads) thread.Join();
        }

        private static void GetMinerThreads(int amount)
        {
            _minerThreads = new List<Thread>();
            for (var i = 1; i < amount; i++) _minerThreads.Add(new MinerThread(_goldBagFarmAmount).MineForGold());
        }
    }
}