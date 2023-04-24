using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnottyFarmer1.Code
{
    internal class Farmer
    {
        public static Texture2D Farmer1 { get; set; }
        Vector2 Pos;
        public Farmer(Vector2 pos)
        {
           this.Pos = pos;
        }
        public void Draw()
        {
            PlayingField.SpriteBatch.Draw(Farmer1, Pos, Color.White);  
        }

        public Vector2 GetPosForSnot() => new Vector2(Pos.X + 270, Pos.Y + 90);
    }

    class Snot
    {
        Vector2 Pos;
        Vector2 Dir;
        const int speed = 100;
        public static Texture2D Snot1 { get; set; }
        public Snot(Vector2 pos)
        {
            this.Pos = pos;
            this.Dir = new Vector2(speed, 0);
        }

        public bool Hidden 
        { 
            get 
            { 
                return Pos.X > PlayingField.Width; 
            } 
        }

        public void UpDate()
        {
            if (Pos.X <= PlayingField.Width)
            {
                Pos += Dir;
            }
        }

        public void Draw()
        {
            PlayingField.SpriteBatch.Draw(Snot1, Pos, Color.White);
        }
    }
}
