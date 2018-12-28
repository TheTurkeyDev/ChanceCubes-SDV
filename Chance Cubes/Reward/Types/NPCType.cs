using Chance_Cubes.Reward.Parts;
using Microsoft.Xna.Framework;
using StardewValley;
using System;

namespace Chance_Cubes.Reward.Types
{
    class NPCType : BaseType<NPCPart>
    {
        public NPCType(NPCPart[] npcs)
            : base(npcs)
        {

        }

        protected override void Trigger(NPCPart part, Vector2 pos, StardewValley.Farmer farmer)
        {
            NPC toSpawn = (NPC)Activator.CreateInstance(part.NPCType, part.getAdjustedArgs(part, pos, farmer));
            toSpawn.Position = pos;
            toSpawn.setTilePosition((int)pos.X, (int)pos.Y);
            toSpawn.currentLocation = Game1.player.currentLocation;
            Game1.currentLocation.characters.Add(toSpawn);
        }
    }
}
