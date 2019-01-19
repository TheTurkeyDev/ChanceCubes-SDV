using Chance_Cubes.Reward;
using Chance_Cubes.Reward.Types;
using Microsoft.Xna.Framework;
using StardewValley;

namespace Chance_Cubes.Reward
{
    class BasicReward : IReward
    {
        string name;
        int chanceValue;
        private IType[] rewards;

        public BasicReward(string name, int chance, IType[] rewards)
        {
            this.name = name;
            this.chanceValue = chance;
            this.rewards = rewards;
        }

        public void Trigger(Vector2 pos, StardewValley.Farmer farmer)
        {
            foreach (IType rewardType in rewards)
                rewardType.Trigger(pos, farmer);
        }

        public int GetChanceValue()
        {
            return chanceValue;
        }

        public string GetName()
        {
            return name;
        }

        public int getNumRewards()
        {
            return rewards.Length;
        }
    }
}
