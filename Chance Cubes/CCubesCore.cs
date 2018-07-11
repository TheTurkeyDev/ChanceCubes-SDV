using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using Chance_Cubes.Reward;

namespace Chance_Cubes
{
    public class CCubesCore : Mod
    {
        private CCubesConfig config;
        private Texture2D giantRingTexture;
        public override void Entry(IModHelper helper)
        {
            RewardRegistry.initRewards();

            this.giantRingTexture = this.Helper.Content.Load<Texture2D>("assets/chance_cube.png");
            ChanceCube.texture = this.giantRingTexture;

            this.Monitor.Log("Chance Cubes has loaded!");
        }
    }
}
