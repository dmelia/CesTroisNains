using System.Threading.Tasks;

namespace ExerciceThreads
{
    public class MinerTask
    {
        #region TaskMiner

        public int _goldAmount { get; set; } = 0;
        private int _bagAmount = 0;
        

        public MinerTask(int goldToFarm)
        {
            GoldToFarm = goldToFarm;
        }

        public int GoldToFarm { get; set; }

        public Task RunMineForGoldTasks()
        {
            return Task.Run(() =>
            {
                

                while (_bagAmount < GoldToFarm)
                {
                    var bagOfGold = new BagOfGold(RandomNumberGenerator.RandomNumber(), "Miner Task");
                    _bagAmount++;
                    _goldAmount += bagOfGold.GoldNuggets;
                }
            });
        }

        #endregion
    }
}