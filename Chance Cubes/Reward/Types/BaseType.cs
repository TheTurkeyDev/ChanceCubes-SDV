using Microsoft.Xna.Framework;

namespace Chance_Cubes.Reward.Types
{
    abstract class BaseType<T> : IType
    {
        protected T[] rewards;

        public BaseType(T[] rewards)
        {
            this.rewards = rewards;
        }

        public void Trigger(Vector2 pos, StardewValley.Farmer farmer)
        {
            foreach (T t in rewards)
                Trigger(t, pos, farmer);
        }

        protected abstract void Trigger(T obj, Vector2 pos, StardewValley.Farmer farmer);
    }
}
