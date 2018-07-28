using System.Collections.Generic;

using Chance_Cubes.Reward.Types;
using Chance_Cubes.Reward.Parts;
using Microsoft.Xna.Framework;
using System;
using StardewValley.Monsters;
using StardewValley.Characters;

namespace Chance_Cubes.Reward
{
    class RewardRegistry
    {
        private static Random rand = new Random();
        private static List<IReward> rewards = new List<IReward>();

        public static void initRewards()
        {
            rewards.Add(new BasicReward("Test 1", 0, new IType[] { new ItemType(new ItemPart[] { new ItemPart(2, 1) }) }));
            rewards.Add(new BasicReward("Test 2", 0, new IType[] { new ItemType(new ItemPart[] { new ItemPart(64, 1) }) }));
            rewards.Add(new BasicReward("Test 3", 0, new IType[] { new NPCType(new NPCPart[] { new NPCPart(typeof(GreenSlime), new object[] { Vector2.Zero }) }) }));
            //rewards.Add(new BasicReward("Test 4", 0, new IType[] { new NPCType(new NPCPart[] { new NPCPart(typeof(Child), new object[] { "Mira", false, false, "%farmer%"}) }) }));
        }

        public static void triggerRandomReward(Vector2 pos, StardewValley.Farmer farmer)
        {
            rewards[rand.Next(rewards.Count)].Trigger(pos, farmer);
        }
    }
}
