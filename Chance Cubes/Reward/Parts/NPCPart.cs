using System;
using Microsoft.Xna.Framework;

namespace Chance_Cubes.Reward.Parts
{
    class NPCPart
    {
        private Type npcType;
        private object[] args;

        public NPCPart(Type npcType)
        {
            NPCType = npcType;
            args = new object[0];
        }

        public NPCPart(Type npcType, object[] args)
        {
            NPCType = npcType;
            Args = args;
        }

        public Type NPCType
        {
            get => npcType;
            set => npcType = value;
        }

        public object[] Args
        {
            get => args;
            set => args = value;
        }

        public object[] getAdjustedArgs(NPCPart part, Vector2 pos, StardewValley.Farmer farmer)
        {
            object[] toReturn = new object[args.Length];

            for(int i = 0; i < args.Length; i++)
            {
                if(args[i] is string)
                {
                    switch((string)args[i])
                    {
                        case "%farmer%":
                            toReturn[i] = farmer;
                            break;
                        default:
                            toReturn[i] = args[i];
                            break;
                    }
                }
                else
                {
                    toReturn[i] = args[i];
                }
            }

            return toReturn;
        }
    }
}
