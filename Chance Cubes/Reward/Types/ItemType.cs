using Chance_Cubes.Reward.Parts;
using Microsoft.Xna.Framework;
using StardewValley;

namespace Chance_Cubes.Reward.Types
{
    class ItemType : BaseType<ItemPart>
    {
        public ItemType(ItemPart[] items)
            : base(items)
        {

        }

        protected override void Trigger(ItemPart part, Vector2 pos, StardewValley.Farmer farmer)
        {
            farmer.currentLocation.dropObject(new StardewValley.Object(part.ItemID , part.StackSize, false, -1, 0), pos * 64f, Game1.viewport, true, farmer);
        }
    }
}
