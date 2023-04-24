using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnottyFarmer1.Code
{
    class PlayingField
    {
        public static int Height, Width;
        public static SpriteBatch SpriteBatch { get; set; }
        static Location location;
        public static Farmer Farmer { get; set; }
        static List<Snot> snots = new List<Snot>();
        public static void Init(SpriteBatch spriteBatch, int height, int width)
        {
            PlayingField.Height = height;
            PlayingField.Width = width;
            PlayingField.SpriteBatch = spriteBatch;
            location = new Location();
            Farmer = new Farmer(new Vector2(100, 50));
        }

        public static void FarmerSnot()
        {
            snots.Add(new Snot(Farmer.GetPosForSnot()));
        }
        
        public static void Draw()
        {
            location.Draw();
            Farmer.Draw();
            foreach (Snot s in snots) s.Draw();
        }

        public static void UpDate()
        {
            for (int i = 0; i < snots.Count; i++)
            {
                snots[i].UpDate();
                if (snots[i].Hidden) 
                { 
                    snots.RemoveAt(i);
                    i--; 
                }
            }
        }
    }

    class Location
    {
        Vector2 Pos = Vector2.Zero;
        public static Texture2D Texture2D { get; set; }
        public void Draw()
        {
            PlayingField.SpriteBatch.Draw(Texture2D, Pos, Color.White);
        }
    }
}
