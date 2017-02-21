
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dotal_War
{
    public class SelectionRectange
    {

        #region Fields

        public Rectangle selectRectangle;
        public bool lockedSelection { get; set;}
        Game1 myGame;
        bool mSelect = false;
        Point mInitial = new Point();
        Texture2D piksel;
        Color drawColor;
        const int Thickness = 1;
        public int AccessID { get;} // which player has access to function?


        #endregion

        public SelectionRectange(Game1 myGame, int AccessID)
        {
            this.AccessID = AccessID;
            selectRectangle = new Rectangle();
            lockedSelection = false;
            this.myGame = myGame;
            piksel = myGame.Content.Load<Texture2D>(@"Misc\Piksel");
            drawColor = Color.White;

        }

        public void Run(MouseState mouse)
        {
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                if (!mSelect)
                {
                    mInitial.X = mouse.X;
                    mInitial.Y = mouse.Y;
                    mSelect = true;
                    lockedSelection = false;

                }

                else
                {

                    if (mouse.X > mInitial.X)
                    {
                        selectRectangle.X= mInitial.X;
                        selectRectangle.Width = mouse.X - mInitial.X;
                    }
                    else if (mouse.X < mInitial.X)
                    {
                        selectRectangle.X = mouse.X;
                        selectRectangle.Width = mInitial.X - mouse.X;
                    }

                    if (mouse.Y > mInitial.Y)
                    {
                        selectRectangle.Y = mInitial.Y;
                        selectRectangle.Height = mouse.Y - mInitial.Y;
                    }

                    else if (mouse.Y < mInitial.Y)
                    {
                        selectRectangle.Y = mouse.Y;
                        selectRectangle.Height = mInitial.Y - mouse.Y;
                    }
                }
            }

            if (mSelect && mouse.LeftButton == ButtonState.Released)
            {
                mSelect = false;
                selectRectangle = Rectangle.Empty;
                lockedSelection = true;

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
                //Top
                spriteBatch.Draw(piksel, new Rectangle(selectRectangle.X, selectRectangle.Y, selectRectangle.Width, Thickness), drawColor);
                //Left
                spriteBatch.Draw(piksel, new Rectangle(selectRectangle.X, selectRectangle.Y, Thickness, selectRectangle.Height), drawColor);
                //Bottom
                spriteBatch.Draw(piksel, new Rectangle(selectRectangle.X, (selectRectangle.Y + selectRectangle.Height), selectRectangle.Width + 1, Thickness), drawColor);
                //Right
                spriteBatch.Draw(piksel, new Rectangle((selectRectangle.X + selectRectangle.Width), selectRectangle.Y, Thickness, selectRectangle.Height), drawColor);
        }
    }
}

