using System;
using System.Threading;

namespace ExerciceThreads
{
    public class MinerThreadPool
    {
        #region ThreadPoolMiner

        private int _bagAmount = 0;
        public int _goldAmount { get; set; }
        public int GoldToFarm { get; set; }
        public static int _doneCounter = 0;
        public static int _maxDoneCounter { get; set; }
        public static ManualResetEvent _resetEvent { get; set; } = new(false);

        public MinerThreadPool(int goldToFarm)
        {
            GoldToFarm = goldToFarm;
        }

        public void MineForGold()
        {
            ThreadPool.QueueUserWorkItem(MineForGoldMethod);
        }

        private void MineForGoldMethod(object state)
        {
            while (_bagAmount < GoldToFarm)
            {
                var bagOfGold = new BagOfGold(RandomNumberGenerator.RandomNumber(), "Miner ThreadPool");
                _bagAmount++;
                _goldAmount += bagOfGold.GoldNuggets;
            }

            //Increment WaitHandler counter (For when the amount of ThreadPools is higher than 64)
            Interlocked.Increment(ref _doneCounter);

            if (_doneCounter >= _maxDoneCounter - 1)
            {
                _resetEvent.Set();
            }
        }
    }

    #endregion
}