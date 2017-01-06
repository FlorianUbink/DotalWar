using Dotal_War.Collections;
using Dotal_War.Components;
using Dotal_War.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Dotal_War
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int WindowWidth = 1280;
        int WindowHeight = 720;

        int returnID;

        public SelectionRectange select;
        ObjectManager objectManger;
        ComponentManager componentManager;
        TargetManager targetManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;

            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            objectManger = new ObjectManager();
            componentManager = new ComponentManager(this);
            select = new SelectionRectange(this);
            targetManager = new TargetManager();



            #region TESTOBJECTEN

            for (int i = 0; i < 3; i++)
            {
                returnID = objectManger.AddObject(new Vector2(WindowWidth / 2 + 20*i, WindowHeight / 2));
                componentManager.perception.Add(objectManger.objectDictionary[returnID], selectType.Movable);
                componentManager.behaviour.Add(objectManger.objectDictionary[returnID]);
                componentManager.kinematic.Add(objectManger.objectDictionary[returnID], 100, 10f);
                componentManager.graphics.Add(objectManger.objectDictionary[returnID], componentManager.graphics.Unit0, Color.White);
            }

            #endregion

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

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState mouse = Mouse.GetState();
            select.Run(mouse);
            targetManager.RunManager(objectManger, mouse);
            componentManager.RunSystems(gameTime, select);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            componentManager.graphics.RunSystem(spriteBatch);
            select.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
