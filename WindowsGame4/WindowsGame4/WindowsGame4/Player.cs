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
    class Player
    {
        Texture2D playerText;
        Rectangle playerRect;
        Rectangle arrowRect;
        float rotAngle;
        Double playerX;
        Double playerY;
        int movementSpeed;
        Keys up;
        Keys down;
        Keys left;
        Keys right;

        public Player(int RectX, int RectY, int RectW, int RectH, Texture2D playerText, Double playerX, Double playerY, int movementSpeed, Keys up, Keys down, Keys left, Keys right)
        {
            this.playerRect = new Rectangle(RectX, RectY, RectW, RectH);
            this.playerText = playerText;
            this.playerX = playerX;
            this.playerY = playerY;
            this.movementSpeed = movementSpeed;
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
        }

        public Player(Rectangle playerRect, Texture2D playerText, Double playerX, Double playerY, int movementSpeed, Keys up, Keys down, Keys left, Keys right)
        {
            this.playerRect = playerRect;
            this.playerText = playerText;
            this.playerX = playerX;
            this.playerY = playerY;
            this.movementSpeed = movementSpeed;
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
        }

        public void playerMovement(KeyboardState kb, double timeSpeed)
        {
            if (kb.IsKeyDown(up))
            {
                playerY -= movementSpeed * timeSpeed;
            }
            if (kb.IsKeyDown(down))
            {
                playerY += movementSpeed * timeSpeed;
            }
            if (kb.IsKeyDown(left))
            {
                playerX -= movementSpeed * timeSpeed;
            }
            if (kb.IsKeyDown(right))
            {
                playerX += movementSpeed * timeSpeed;
            }

            playerRect.X = (int)playerX;
            playerRect.Y = (int)playerY;
        }
        public void playMovement(GamePadState g,double timeSpeed)
        {
            playerX = playerX + (movementSpeed*g.ThumbSticks.Left.X);
            playerY = playerY - (movementSpeed * g.ThumbSticks.Left.Y);
            //gravity();
            playerRect.X = (int)playerX;
            playerRect.Y = (int)playerY;
        }
        public Texture2D getPlayerTexture()
        {
            return playerText;
        }

        public Rectangle getPlayerRectangle()
        {
            return playerRect;
        }
        public Rectangle getArrowRect()
        {
            return arrowRect;
        }
        public Vector2 getOrigin()
        {
            Vector2 origin = new Vector2(playerRect.Width / 2, playerRect.Height / 2);
            return origin;
        }
        public void setArrow(GamePadThumbSticks gp)
        {
            rotAngle= (float)Math.Atan2(gp.Right.X, -gp.Right.Y);
        }
        public void setArrow(MouseState gp)
        {
            rotAngle = (float)Math.Atan2(gp.X, -gp.Y);
        }
        public float getAngle()
        {
            return rotAngle;
        }
    }
}
