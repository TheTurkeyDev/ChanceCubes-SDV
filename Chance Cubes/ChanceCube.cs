using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using System;

namespace Chance_Cubes
{
    class ChanceCube : StardewValley.Object
    {
        //The texture of the Chance Cube
        public static Texture2D texture;

        /*  I'm not totally positive which constructors are needed and which aren't 
            since I don't have the item placed in the world yet. Only in the players inventory
        */
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

        // Tool tip info
        public override string getDescription()
        {
            return "What's in the cube?";
        }

        //Draws the Item in the menu
        public override void drawInMenu(SpriteBatch spriteBatch, Vector2 location, float scaleSize, float transparency, float layerDepth, bool drawStackNumber)
        {
            spriteBatch.Draw(texture, // The texture to use. Most items use the game larger texture sheet
                location + new Vector2(Game1.tileSize / 2, Game1.tileSize / 2) * scaleSize, // Location on the screen to render at
                Game1.getSourceRectForStandardTileSheet(texture, 0, 64, 64), // The area of the texture to render (so I guess usefull for texture sheets with many textures)
                Color.White * transparency, // White color seems to render the texture normally. This may be used for tinting textures?
                0.0f, // Rotation
                new Vector2(32f, 32f) * scaleSize, // Not quite sure what this is, but it affects where the texture is drawn on the screen
                (scaleSize * Game1.pixelZoom) / 4f, //scaleSize * Game1.pixelZoom is the default. I divide by 4 to fit my 64 by 64 texture
                SpriteEffects.None, // No effects needed 
                layerDepth); // IDK
        }

        public override void drawWhenHeld(SpriteBatch spriteBatch, Vector2 objectPosition, StardewValley.Farmer f)
        {
            spriteBatch.Draw(texture, // Texture / Sheet of textures to use
                objectPosition, // Position to draw the texture at. Not sure if screen or world relative
                new Rectangle?(Game1.getSourceRectForStandardTileSheet(texture, 0, 64, 64)), // Same as above
                Color.White, // Same as above
                0.0f, // Still same
                Vector2.Zero, // Not sure why this one is zero and the one above isn't
                Game1.pixelZoom / 4f, // I divide by 4 for the same reason as above
                SpriteEffects.None, // No effects needed
                Math.Max(0.0f, (float)(f.getStandingY() + 2) / 10000f)); // IDK again
        }
    }
}
