using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ExerciceThreads
{
    public class TasksGoldMine
    {
        public static int _goldBagFarmAmount { get; set; }
        private static List<MinerTask> _minerTasks;

        private static void GetMinerTasks(int amount)
        {
            _minerTasks = new List<MinerTask>();
            for (var i = 1; i < amount; i++) _minerTasks.Add(new MinerTask(_goldBagFarmAmount));
        }

        public static async Task SimpleMiner(int amount)
        {
            GetMinerTasks(amount);

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            foreach (var task in _minerTasks)
            {
                await task.RunMineForGoldTasks();
            }
            stopwatch.Stop();

            int totalGold = 0;
            foreach (var minerTask in _minerTasks)
            {
                totalGold += minerTask._goldAmount;
            }

            Console.WriteLine("Tasks gold mine made {0}, nuggets of gold ! It took {1} ms to complete", totalGold, stopwatch.ElapsedMilliseconds);
        }
    }
}