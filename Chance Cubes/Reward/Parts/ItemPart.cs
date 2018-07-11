
namespace Chance_Cubes.Reward.Parts
{
    class ItemPart
    {
        private int itemID;
        private int stackSize;

        public ItemPart(int id, int stackSize)
        {
            this.itemID = id;
            this.stackSize = stackSize;
        }

        public int ItemID { get; }

        public int StackSize { get; }
    }
}
