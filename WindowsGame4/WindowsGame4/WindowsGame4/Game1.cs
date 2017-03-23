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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //List<Rectangle> bulletRects;
        //Texture2D bulletTex;
        //int bulletCount;
        //int bulletSpeed;

        KeyboardState kb;
        KeyboardState oldKb;
        int gameTime;
        public enum gameState { setUp,mainMenu,paused,slow,play};

        int globalMovementSpeed;
        Texture2D playerText;

        Player player1;
        Player player2;

        Boolean firstLoop;

        Double timeSpeed;
        Boolean timeSlow;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //bulletRects = new List<Rectangle>();
            //bulletSpeed = 2;
            //bulletCount = 0;
            globalMovementSpeed = 2;

            firstLoop = true;
            //player1 = new Player(new Rectangle(50, 50, 20, 20), playerText, (double)50, (double)50, globalMovementSpeed, Keys.W, Keys.S, Keys.A, Keys.D);

            gameTime = 0;
            timeSpeed = 1.0;
            timeSlow = false;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerText = Content.Load<Texture2D>("White Square");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            kb = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if(firstLoop)
            {
                player1 = new Player(new Rectangle(50, 50, 20, 20), playerText, (double)50, (double)50, globalMovementSpeed, Keys.W, Keys.S, Keys.A, Keys.D);
                player2 = new Player(new Rectangle(200, 200, 20, 20), playerText, (double)200, (double)200, globalMovementSpeed, Keys.Up, Keys.Down, Keys.Left, Keys.Right);
            }

            player1.playerMovement(kb, timeSpeed);
            player2.playerMovement(kb, timeSpeed);

            if (kb.IsKeyDown(Keys.T) && oldKb != kb)
            {
                if (timeSlow)
                {
                    timeSpeed = 1;
                    timeSlow = false;
                }
                else
                {
                    timeSpeed = .5;
                    timeSlow = true;
                }
            }


            
            oldKb = kb;
            // TODO: Add your update logic here

            firstLoop = false;
            base.Update(gameTime);
        }

        //public void playerMovement(Double playerX, Double playerY)
        //{
        //    if (kb.IsKeyDown(Keys.W))
        //    {
        //        player1Y -= movementSpeed * timeSpeed;
        //    }
        //    if (kb.IsKeyDown(Keys.S))
        //    {
        //        player1Y += movementSpeed * timeSpeed;
        //    }
        //    if (kb.IsKeyDown(Keys.A))
        //    {
        //        player1X -= movementSpeed * timeSpeed;
        //    }
        //    if (kb.IsKeyDown(Keys.D))
        //    {
        //        player1X += movementSpeed * timeSpeed;
        //    }
        //    //if (kb.IsKeyDown(Keys.))
        //}

        ////public void bulletMove(int position)
        ////{
        ////    bulletRects[position] = (new Rectangle(bulletRects[position].X, bulletRects[position].Y - bulletSpeed, bulletRects[position].Width, bulletRects[position].Height));
        ////}

        ////public void createBullet()
        ////{
        ////    bulletRects.Add(new Rectangle(player1.X + player1.Width / 2, player1.Y + player1.Height / 2, 5, 5));
        ////    bulletCount++;
        ////}

        ////public void deleteBullet(int currentBullet)
        ////{
        ////    bulletRects.RemoveAt(currentBullet);
        ////    bulletCount--;
        ////}

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(player1.getPlayerTexture(), player1.getPlayerRectangle(), Color.White);
            spriteBatch.Draw(player2.getPlayerTexture(), player2.getPlayerRectangle(), Color.White);
            spriteBatch.Draw(player1.getPlayerTexture(),player1.getArrowRect(),null,Color.White,player1.getAngle(),player1.getOrigin(),SpriteEffects.None,0);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
