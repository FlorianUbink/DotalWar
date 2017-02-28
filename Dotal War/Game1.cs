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

        Player firstPlayer;
        public SelectionRectange select;
        public ObjectManager objectManager;
        public ComponentManager componentManager;
        DammageDistribution dmgDistribution;
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

            objectManager = new ObjectManager();
            componentManager = new ComponentManager(this);
            firstPlayer = new Player(this, 1);
            select = new SelectionRectange(this,firstPlayer.PlayerID);
            dmgDistribution = new DammageDistribution();
            targetManager = new TargetManager();



            #region TESTOBJECTEN

            for (int i = 0; i <10; i++)
            {
                firstPlayer.Add(new Vector2(20 + 20 * i, WindowHeight / 2));
            }


            // Test Enemies
            int objectID;
            objectID = objectManager.AddObject(2, true, new Vector2(WindowWidth/2,WindowHeight/2));
            componentManager.perception.Add(objectManager.objectDictionary[objectID], selectType.NonMovable);
            componentManager.combat.Add(objectManager.objectDictionary[objectID], 100f, 5f, 0.72f, 30f, true, true);
            componentManager.graphics.Add(objectManager.objectDictionary[objectID], componentManager.graphics.Unit0, Color.White);


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
            targetManager.RunManager(objectManager, mouse);
            componentManager.RunSystems(gameTime, select,objectManager,dmgDistribution);
            objectManager.CleanUp(componentManager);
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
            foreach (TMaping tmap in targetManager.target_maps)
            {
                tmap.draw(spriteBatch, componentManager.graphics.Piksel);
            }
            componentManager.graphics.RunSystem(spriteBatch);
            


            select.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
