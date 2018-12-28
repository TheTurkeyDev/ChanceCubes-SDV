using Chance_Cubes.Reward;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Locations;
using System;
using System.Collections.Generic;

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
            this.Type = "interactive";
            this.boundingBox.Set(new Rectangle((int)tileLocation.X * Game1.tileSize, (int)tileLocation.Y * Game1.tileSize, Game1.tileSize, Game1.tileSize));
        }

        public ChanceCube(Vector2 tileLocation)
        {
            this.name = "Chance Cube";
            this.Type = "interactive";
            this.TileLocation = tileLocation;
            this.boundingBox.Set(new Rectangle((int)tileLocation.X * Game1.tileSize, (int)tileLocation.Y * Game1.tileSize, Game1.tileSize, Game1.tileSize));
        }

        // Tool tip info
        public override string getDescription()
        {
            return "What's in the cube?";
        }

        // Whether or not the object can be placed in the world
        public override bool isPlaceable()
        {
            return true;
        }

        public override bool performObjectDropInAction(Item dropIn, bool probe, StardewValley.Farmer who)
        {
 
            return false;
        }

        //Called when the object is placed in the world
        public override bool performDropDownAction(StardewValley.Farmer who)
        {
            return false;
        }

        //
        public override bool performToolAction(Tool t, GameLocation location)
        {
            Game1.playSound("woodWhack");
            RewardRegistry.triggerRandomReward(tileLocation, Game1.player);
            return true;
        }

        //Draws the Item in the menu
        public override void drawInMenu(SpriteBatch spriteBatch, Vector2 location, float scaleSize, float transparency, float layerDepth, bool drawStackNumber, Color color, bool drawShadow)
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

        // Draws the item above the players head when they hold it
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


        // Called when drawing the object to be placed in the world
        public override void draw(SpriteBatch spriteBatch, int x, int y, float alpha = 1f)
        {
            spriteBatch.Draw(texture, // Texture / Sheet of textures to use
                Game1.GlobalToLocal(Game1.viewport, new Vector2((float)(x * Game1.tileSize), (float)(y * Game1.tileSize))), // Position to draw the texture on the screen. The location needs to be converted from World coordinates to screen cordinates
                new Rectangle?(Game1.getSourceRectForStandardTileSheet(texture, 0, 64, 64)), // Same as above
                Color.White * alpha, // Same as above
                0.0f, // Still same
                Vector2.Zero, // Not sure why this one is zero and the menu one above isn't
                (float)Game1.pixelZoom / 4f,
                SpriteEffects.None, // No effects needed
                (float)(this.boundingBox.Bottom - 8) / 10000f); // Still don't know
        }

        public override Item getOne()
        {
            return (Item)new ChanceCube();
        }
    }
}
