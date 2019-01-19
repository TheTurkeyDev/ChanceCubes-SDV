using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using Chance_Cubes.Reward;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using System.Collections.Generic;
using Chance_Cubes.config;

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

            Helper.Events.Display.MenuChanged += this.MenuChanged;

            CustomRewardsLoader.LoadCustomRewards(helper.Data, helper.DirectoryPath);

            logger.Info("Chance Cubes has loaded!");

            //Game1.objectInformation.Add(System.Linq.Enumerable.Last(Game1.objectInformation).Key + 1, "Chance Cube/150/-1/Basic/Chance Cube/Want to play a game?");
        }

        private void MenuChanged(object sender, MenuChangedEventArgs e)
        {
            if (Game1.activeClickableMenu is ShopMenu)
            {
                var shop = (ShopMenu)Game1.activeClickableMenu;
                if (shop.portraitPerson != null && shop.portraitPerson.Name == "Pierre") // && Game1.dayOfMonth % 7 == )
                {
                    var items =
                        this.Helper.Reflection.GetField<Dictionary<Item, int[]>>(shop, "itemPriceAndStock").GetValue();
                    var selling = this.Helper.Reflection.GetField<List<Item>>(shop, "forSale").GetValue();

                    var cube = new ChanceCube();
                    items.Add(cube, new[] { 150, int.MaxValue });
                    selling.Add(cube);
                }
            }
        }
    }
}
