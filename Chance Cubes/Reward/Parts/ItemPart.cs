
namespace Chance_Cubes.Reward.Parts
{
    class ItemPart : IPart
    {
        public int delay;

        public ItemPart(int id, int stackSize)
        {
            ItemID = id;
            StackSize = stackSize;
        }

        public int ItemID { get; private set; }

        public int StackSize { get; private set; }

        public int Delay { get; }

        public ItemPart SetDelay(int delay)
        {
            this.delay = delay;
            return this;
        }
    }
}
