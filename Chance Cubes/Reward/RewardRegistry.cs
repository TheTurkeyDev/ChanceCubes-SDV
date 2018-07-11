using System.Collections.Generic;

using Chance_Cubes.Reward.Types;
using Chance_Cubes.Reward.Parts;

namespace Chance_Cubes.Reward
{
    class RewardRegistry
    {
        private static List<IReward> rewards = new List<IReward>();

        public static void initRewards()
        {
            rewards.Add(new BasicReward("Test 1", 0, new IType[]{ new ItemType(new ItemPart[]{ new ItemPart(1, 1)})}));
        }
    }
}
