using Microsoft.Xna.Framework;

namespace Chance_Cubes.Reward.Parts
{
    class MessagePart : IPart
    {
        public int delay;

        public MessagePart(string message, Color color)
        {
            Message = message;
            MessageColor = color;

        }

        public string Message { get; private set; }
        public Color MessageColor { get; private set; }
        public bool ServerWide { get; private set; }
        public int Range { get; private set; }

        public int Delay { get; }

        public MessagePart SetDelay(int delay)
        {
            this.delay = delay;
            return this;
        }
    }
}
