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
            Vector2 debrisOrigin = new Vector2((float)(pos.X * Game1.tileSize + Game1.tileSize), (float)(pos.Y * Game1.tileSize + Game1.tileSize));
            Game1.createItemDebris((Item)new Object(part.ItemID, part.StackSize, false, -1, 0), debrisOrigin, -1, farmer.currentLocation);
        }
    }
}
