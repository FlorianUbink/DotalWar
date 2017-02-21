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
        public Texture2D Building0 { get; set; }
        public Texture2D Piksel { get; set; }
        Rectangle healthBar;

        public Graphics(ContentManager content)
        {
            subscribers = new List<GameObject>();
            Unit0 = content.Load<Texture2D>(@"Placeholders\Unit0");
            Building0 = content.Load<Texture2D>(@"Placeholders\Building0");
            Piksel = content.Load<Texture2D>(@"Misc\Piksel");
            healthBar = new Rectangle(0, 0, 0, 2);
        }

        public void Add(GameObject subject, Texture2D sprite, Color color)
        {
            subject.Color = color;
            subject.Sprite = sprite;
            subject.Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            subscribers.Add(subject);
        }

        public void Remove(GameObject removeObject)
        {
            if (subscribers.Contains(removeObject))
            {
                subscribers.Remove(removeObject);
            }
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

                spriteBatch.Draw(update.Sprite, update.Position, null, update.Color, update.Rotation, update.Origin, 1f, SpriteEffects.None, 0f);

                if (update.AttackAble)
                {
                    healthBar.Width = (int)update.defense_health/5;
                    healthBar.X = (int)(update.Position.X - healthBar.Width/2);
                    healthBar.Y = (int)(update.Position.Y - 15);

                    spriteBatch.Draw(Piksel, healthBar, Color.Green);
                }
            }
        }

    }
}
