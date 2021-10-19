using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ExerciceThreads
{
    public class ThreadPoolsGoldMine
    {
        public static int _goldBagFarmAmount { get; set; }
        private static List<MinerThreadPool> _minerThreadPools;
        

        public static void SimpleMiner(int amount)
        {
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            //Set the max done counter to be the number of threads we're starting
            MinerThreadPool._maxDoneCounter = amount;
            GetMinerThreadPools(amount);
            
            //Wait for WaitHandler
            WaitHandle.WaitAny(new WaitHandle[] {MinerThreadPool._resetEvent});
            stopwatch.Stop();

            int totalGold = 0;
            foreach (var minerThreadPool in _minerThreadPools)
            {
                totalGold += minerThreadPool._goldAmount;
            }

            Console.WriteLine("ThreadPools gold mine made {0}, nuggets of gold ! It took {1} ms to complete", totalGold,
                stopwatch.ElapsedMilliseconds);
        }

        private static void GetMinerThreadPools(int amount)
        {
            _minerThreadPools = new List<MinerThreadPool>();
            for (var i = 1; i < amount; i++)
            {
                MinerThreadPool minerThreadPool = new MinerThreadPool(_goldBagFarmAmount);
                _minerThreadPools.Add(minerThreadPool);
                minerThreadPool.MineForGold();
            }
        }
    }
}