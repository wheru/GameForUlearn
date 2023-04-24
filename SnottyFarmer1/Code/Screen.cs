using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnottyFarmer1
{
    static class Screen
    {
        public static Texture2D Back { get; set; }
        public static SpriteFont SpriteFont { get; set; }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Back, Vector2.Zero, Color.White);
            spriteBatch.DrawString(SpriteFont, "Snotty Farmer", new Vector2(620, 100), Color.White);
        }
    }
}
