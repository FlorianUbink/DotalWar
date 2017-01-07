using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Components
{
    public class Graphics
    {
        List<GameObject> subscribers;


        public Texture2D Unit0 { get; set; }


        public Graphics(ContentManager content)
        {
            subscribers = new List<GameObject>();
            Unit0 = content.Load<Texture2D>(@"Placeholders\Unit0");
        }

        public void Add(GameObject subject, Texture2D sprite, Color color)
        {
            subject.Color = color;
            subject.Sprite = sprite;
            subject.RenderOffset = new Vector2(sprite.Width / 2, sprite.Height / 2);
            subscribers.Add(subject);
        }

        public void RunSystem(SpriteBatch spriteBatch)
        {
            foreach (GameObject update in subscribers)
            {
                // ### TEST #####
                switch (update.Selected)
                {
                    case true:
                        update.Color = Color.Black;
                        break;
                    default:
                        update.Color = Color.White;
                        break;
                }
                // ### TESTEND ####

                spriteBatch.Draw(update.Sprite, update.Position, update.Color);
            }
        }

    }
}
