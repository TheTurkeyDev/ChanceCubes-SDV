using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using Chance_Cubes.Reward;
using StardewModdingAPI.Events;
using System;
using StardewValley;
using StardewValley.Menus;
using System.Collections.Generic;

namespace Chance_Cubes
{
    public class CCubesCore : Mod
    {
        private CCubesConfig config;
        private Texture2D chanceCubeTexture;
        internal static Log logger;

        public override void Entry(IModHelper helper)
        {
            RewardRegistry.initRewards();

            /*  Gets the texture that we will use for the Chance Cube. It feels weird to do it here, 
                but this is how the example i was following did it.
            */
            this.chanceCubeTexture = this.Helper.Content.Load<Texture2D>("assets/chance_cube.png");
            ChanceCube.texture = this.chanceCubeTexture;

            logger = new Log(this);

            MenuEvents.MenuChanged += this.MenuChanged;

            logger.Info("Chance Cubes has loaded!");

            //Game1.objectInformation.Add(49494, "Chance Cube");
        }

        private void MenuChanged(object sender, EventArgsClickableMenuChanged e)
        {
            if (Game1.activeClickableMenu is ShopMenu)
            {
                var shop = (ShopMenu)Game1.activeClickableMenu;
                if (shop.portraitPerson != null && shop.portraitPerson.name == "Pierre") // && Game1.dayOfMonth % 7 == )
                {
                    var items =
                        this.Helper.Reflection.GetField<Dictionary<Item, int[]>>(shop, "itemPriceAndStock").GetValue();
                    var selling = this.Helper.Reflection.GetField<List<Item>>(shop, "forSale").GetValue();

                    var ring = new ChanceCube();
                    items.Add(ring, new[] { 150, int.MaxValue });
                    selling.Add(ring);
                }
            }
        }
    }
}
