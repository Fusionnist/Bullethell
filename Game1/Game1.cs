using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D translation, nontranslation;
        Texture2D trans, nontrans;
        Vector2 translationV;
        float zoom;
        int width, height;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            width = graphics.PreferredBackBufferWidth;
            height = graphics.PreferredBackBufferHeight;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;
            translation = new RenderTarget2D(GraphicsDevice, 600, 600);
            nontranslation = new RenderTarget2D(GraphicsDevice, 600, 600);
            zoom = 1.5f;
            trans = Content.Load<Texture2D>("smallguy");
            nontrans = Content.Load<Texture2D>("smallguy");
            translationV = new Vector2(0, 0);

            graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
        }

        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            translationV.X -= 1;


            base.Update(gameTime);
        }

            protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(translation);
            //trans draw
            Matrix m = Matrix.CreateTranslation(-new Vector3(translationV.X, translationV.Y, 0)) * Matrix.CreateScale(zoom);
            spriteBatch.Begin(transformMatrix: m);
            spriteBatch.Draw(trans, position: Vector2.Zero);
            spriteBatch.End();


            GraphicsDevice.SetRenderTarget(nontranslation);
            GraphicsDevice.Clear(Color.TransparentBlack);
            //nontrans trans draw
            spriteBatch.Begin();
            spriteBatch.Draw(nontrans, position: new Vector2(300, 300));
            spriteBatch.End();


            GraphicsDevice.SetRenderTarget(null);
            //draw targets
            spriteBatch.Begin();
            spriteBatch.Draw(translation, position: Vector2.Zero);
            spriteBatch.Draw(nontranslation, position: Vector2.Zero);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
