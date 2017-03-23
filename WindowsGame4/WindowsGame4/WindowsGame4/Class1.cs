using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame4
{
    class Platform
    {
        private int x;
        private int y;
        private int width;
        private int height;
        Rectangle platform;
        Texture2D platformText;

        public Platform(int X, int Y, int Width, int Height, Texture2D platformText)
        {
            x = X;
            y = Y;
            width = Width;
            height = Height;
            platform = new Rectangle(x, y, width, height);
            this.platformText = platformText;
        }

        public int getY()
        {
            return y;
        }

        public Texture2D getText()
        {
            return platformText;
        }

        public Rectangle getRect()
        {
            return platform;
        }

    }
}
