using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System;

namespace Chance_Cubes
{
    public class CCubesCore : Mod
    {
        private CCubesConfig config;
        private Texture2D giantRingTexture;
        public override void Entry(IModHelper helper)
        {
            this.Monitor.Log("Chance Cubes has loaded!");
            this.giantRingTexture = this.Helper.Content.Load<Texture2D>("assets/chance_cube.png");
            ChanceCube.texture = this.giantRingTexture;
        }
    }
}
