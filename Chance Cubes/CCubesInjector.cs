using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chance_Cubes
{
    class CCubesInjector : IAssetEditor
    {
        public bool CanEdit<T>(IAssetInfo asset)
        {
            if (asset.AssetNameEquals("Data\\ObjectInformation"))
                return true;
            if (asset.AssetNameEquals("Data\\CraftingRecipes"))
                return true;
            return false;
        }

        public void Edit<T>(IAssetData asset)
        {
            if (asset.AssetNameEquals("Data\\ObjectInformation"))
            {
                //int id = Enumerable.Last(Game1.objectInformation).Key + 1;
                //asset.AsDictionary<int, string>().Data.Add(ChanceCube.ID, $"{ChanceCube.NAME}/{ChanceCube.PRICE}/{ChanceCube.EDIBILITY}/{ChanceCube.TYPE} {ChanceCube.CATEGORY}/{ChanceCube.NAME}/{ChanceCube.DESCRIPTION}");
            }
            else if (asset.AssetNameEquals("Data\\CraftingRecipes"))
            {
                //asset.AsDictionary<string, string>().Data.Add("Cobalt Sprinkler", $"645 1 {CobaltBarItem.INDEX} 1/Home/{CobaltSprinklerObject.INDEX} 1/false/null");
            }
        }
    }
}
