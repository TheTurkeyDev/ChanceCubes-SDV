using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using System;

namespace Chance_Cubes
{
    class ChanceCube : StardewValley.Object
    {
        public static Texture2D texture;

        public ChanceCube()
        {
            this.name = "Chance Cube";
            this.type = "interactive";

            this.boundingBox = new Rectangle((int)this.tileLocation.X * Game1.tileSize, (int)this.tileLocation.Y * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        }

        public ChanceCube(Vector2 tileLocation)
        {
            this.name = "Chance Cube";
            this.type = "interactive";
            this.tileLocation = tileLocation;
            this.boundingBox = new Rectangle((int)this.tileLocation.X * Game1.tileSize, (int)this.tileLocation.Y * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        }

        public override string getDescription()
        {
            return "What's in the cube?";
        }

        public override void drawInMenu(SpriteBatch spriteBatch, Vector2 location, float scaleSize, float transparency, float layerDepth, bool drawStackNumber)
        {
            spriteBatch.Draw(texture, location + new Vector2(Game1.tileSize / 2, Game1.tileSize / 2) * scaleSize,
                Game1.getSourceRectForStandardTileSheet(texture, 0, 64, 64), Color.White * transparency, 0.0f,
                new Vector2(32f, 32f) * scaleSize, (scaleSize * Game1.pixelZoom) / 4f, SpriteEffects.None, layerDepth);
        }

        public override void drawWhenHeld(SpriteBatch spriteBatch, Vector2 objectPosition, StardewValley.Farmer f)
        {
            spriteBatch.Draw(texture, objectPosition, 
                new Rectangle?(Game1.getSourceRectForStandardTileSheet(texture, 0, 64, 64)), 
                Color.White, 0.0f, Vector2.Zero, Game1.pixelZoom / 4f, SpriteEffects.None, 
                Math.Max(0.0f, (float)(f.getStandingY() + 2) / 10000f));
        }
    }
}
