using Chance_Cubes.Reward.Parts;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Monsters;
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

        }
    }
}
