﻿using System;
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
        int topSpeed;
        private Double verticalSpeed;
        private Double horizontalSpeed;
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
            verticalSpeed = 0;
            horizontalSpeed = 0;
            topSpeed = 5; //Add top speed to input
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
            verticalSpeed = 0;
            horizontalSpeed = 0;
            topSpeed = 5; //Add top speed to input
        }

        public void playerMovement(KeyboardState kb, double timeSpeed, List<Platform> allPlatforms)
        {
            //Take out + in += for more responsive movement
            if (kb.IsKeyDown(up))
            {
                horizontalSpeed += -movementSpeed * timeSpeed;
            }
            if (kb.IsKeyDown(down))
            {
                horizontalSpeed += movementSpeed * timeSpeed;
            }
            if (kb.IsKeyDown(left))
            {
                verticalSpeed += -movementSpeed * timeSpeed;
            }
            if (kb.IsKeyDown(right))
            {
                verticalSpeed += movementSpeed * timeSpeed;
            }

            gravity(allPlatforms);

            topSpeedFix();

            playerX += horizontalSpeed;
            playerY += verticalSpeed;
            playerRect.X = (int)playerX;
            playerRect.Y = (int)playerY;
        }
        public void playMovement(GamePadState g,double timeSpeed,List<Platform>allPlatforms)
        {
            playerX = playerX + (movementSpeed*g.ThumbSticks.Left.X);
            playerY = playerY - (movementSpeed * g.ThumbSticks.Left.Y);
            gravity(allPlatforms);
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

        public void topSpeedFix()
        {
            if (verticalSpeed > topSpeed)
            {
                verticalSpeed = topSpeed;
            }
            if (verticalSpeed < -topSpeed)
            {
                verticalSpeed = -topSpeed;
            }
            if (horizontalSpeed > topSpeed)
            {
                horizontalSpeed = topSpeed;
            }
            if (horizontalSpeed < -topSpeed)
            {
                horizontalSpeed = -topSpeed;
            }
        }

        public void gravity(List<Platform> platforms)
        {
            Platform p = floorIntersection(platforms);
            if (p == null)
            {
                verticalSpeed += 9.8;
            }
            else
            {
                verticalSpeed = 0;
                playerRect.X = p.getRect().X - playerRect.Height;
            }
        }

        public Platform floorIntersection(List<Platform> platforms)
        {
            Rectangle playerBottom = new Rectangle(playerRect.X, playerRect.Y + playerRect.Height, playerRect.Width, 1);
            foreach(Platform p in platforms)
            {
                if(playerBottom.Intersects(p.getRect()))
                {
                    return p;
                }
            }
            return null;
        }
        public void setArrowrect(Rectangle player)
        {
            arrowRect = new Rectangle(playerRect.X, playerRect.Y, playerRect.Width / 2, playerRect.Height / 2);
        }
        public Rectangle getArrowRect()
        {
            return arrowRect;
        }
        public Vector2 getOrigin()
        {
            Vector2 origin = new Vector2(playerRect.Width*2,playerRect.Height/2);
            //origin = new Vector2(0, 0);
            return origin;
        }
        public void setArrow(GamePadState gp)
        {
            if (gp.ThumbSticks.Right.X != 0 && -gp.ThumbSticks.Right.Y != 0)
            {
                rotAngle = (float)Math.Atan2(gp.ThumbSticks.Right.X, -gp.ThumbSticks.Right.Y);
            }
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
