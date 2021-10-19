using System;
using System.Diagnostics;
using System.Threading;

namespace ExerciceThreads
{
    public class MinerThread
    {
        #region ThreadMiner

        private int _bagAmount = 0;
        

        public MinerThread(int goldToFarm)
        {
            GoldToFarm = goldToFarm;
        }

        public int GoldToFarm { get; set; }

        public Thread MineForGold()
        {
            return new Thread(StartMining);
        }

        private void StartMining()
        {

            while (_bagAmount < GoldToFarm)
            {
                var bagOfGold = new BagOfGold(RandomNumberGenerator.RandomNumber(), "Miner Thread");
                _bagAmount++;
                Interlocked.Add(ref ThreadsGoldMine._goldAmount, bagOfGold.GoldNuggets);
            }
        }

        #endregion
    }
}