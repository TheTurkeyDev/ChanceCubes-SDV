using Chance_Cubes.Reward.Parts;
using Microsoft.Xna.Framework;
using StardewValley;

namespace Chance_Cubes.Reward.Types
{
    internal class MessageType : BaseType<MessagePart>
    {
        public MessageType(MessagePart[] items)
            : base(items)
        {

        }

        protected override void Trigger(MessagePart part, Vector2 pos, Farmer farmer)
        {
            Game1.chatBox.addMessage(part.Message, part.MessageColor);
        }
    }
}
