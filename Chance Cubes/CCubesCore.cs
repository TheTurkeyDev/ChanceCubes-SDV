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
            chanceCubeTexture = this.Helper.Content.Load<Texture2D>("assets/chance_cube.png");
            ChanceCube.texture = this.chanceCubeTexture;

            logger = new Log(this);

            InitEvents(helper.Events);

            helper.Content.AssetEditors.Add(new CCubesInjector());

            CustomRewardsLoader.LoadCustomRewards(helper.Data, helper.DirectoryPath);

            logger.Info("Death and destruction prepared! (And Cookies. Cookies were also prepared.)");
        }

        private void MenuChanged(object sender, MenuChangedEventArgs e)
        {
            if (Game1.activeClickableMenu is ShopMenu)
            {
                var shop = (ShopMenu)Game1.activeClickableMenu;
                if (shop.portraitPerson != null && shop.portraitPerson.Name == "Pierre") // && Game1.dayOfMonth % 7 == )
                {
                    var cube = new ChanceCube(Game1.currentCursorTile);
                    shop.itemPriceAndStock.Add(cube, new[] { 150, int.MaxValue });
                    shop.forSale.Add(cube);
                }
            }
        }

        private void InitEvents(IModEvents events)
        {
            events.Display.MenuChanged += this.MenuChanged;
        }
    }
}
