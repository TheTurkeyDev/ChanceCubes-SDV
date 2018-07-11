using Microsoft.Xna.Framework;

namespace Chance_Cubes.Reward.Types
{
    interface IType
    {
        void Trigger(Vector2 pos, StardewValley.Farmer farmer);
    }
}
