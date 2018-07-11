using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using Chance_Cubes.Reward;

namespace Chance_Cubes
{
    public class CCubesCore : Mod
    {
        private CCubesConfig config;
        private Texture2D chanceCubeTexture;
        public override void Entry(IModHelper helper)
        {
            RewardRegistry.initRewards();

            /*  Gets the texture that we will use for the Chance Cube. It feels weird to do it here, 
                but this is how the example i was following did it.
            */
            this.chanceCubeTexture = this.Helper.Content.Load<Texture2D>("assets/chance_cube.png");
            ChanceCube.texture = this.chanceCubeTexture;

            this.Monitor.Log("Chance Cubes has loaded!");
        }
    }
}
