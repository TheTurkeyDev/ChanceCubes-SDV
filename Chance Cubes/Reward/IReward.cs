using Microsoft.Xna.Framework;
using System;

namespace Chance_Cubes.Reward
{
    interface IReward
    {
        void Trigger(Vector2 pos, StardewValley.Farmer farmer);

        int GetChanceValue();

        string GetName();
    }
}
