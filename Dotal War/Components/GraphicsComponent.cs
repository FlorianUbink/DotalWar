using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Components
{
    public class GraphicsComponent:IComponent
    {
        public GameObject parent { get; set; }
        Rectangle sourceRectangle;
        public GraphicsComponent(GameObject subject, Texture2D sprite, Color color)
        {
            parent = subject;
            parent.Sprite = sprite;
            parent.RenderOffset = new Vector2(sprite.Width / 2, sprite.Height / 2);
            parent.Color = color;
        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(parent.Sprite, parent.Position + parent.RenderOffset,null, parent.Color, parent.rotation, parent.RenderOffset, 1f, SpriteEffects.None, 0);
        }
    }
}
