
namespace Chance_Cubes.Reward.Parts
{
    class ItemPart
    {
        public ItemPart(int id, int stackSize)
        {
            ItemID = id;
            StackSize = stackSize;
        }

        public int ItemID { get; private set; }

        public int StackSize { get; private set; }
    }
}
