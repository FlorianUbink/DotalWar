using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Components
{
    public class KinematicComponent:IComponent
    {
        GameObject parent;
        float speed;
        Vector2 direction;
        Vector2 velocity;
        public GameTime gameTime { get; set; }

        public KinematicComponent(GameObject gameObject, float speed)
        {
            parent = gameObject;
            parent.targetList = new List<Vector2>();
            this.speed = speed;
        }

        public void Update()
        {
            if (parent.targetList.Count != 0)
            {
                direction = parent.targetList[0] - parent.Position;
                direction.Normalize();

                velocity = direction * speed;
                parent.rotation = (float)(Math.Atan2(velocity.Y, velocity.X) + Math.PI/2);
                parent.Position += velocity * gameTime.ElapsedGameTime.Milliseconds / 1000;
                float d = Vector2.Distance(parent.targetList[0], parent.Position);
                if (d <= 2)
                {
                    parent.targetList.Remove(parent.targetList[0]);
                }
            }

            else
            {
                direction = Vector2.Zero;
                velocity = Vector2.Zero;
            }
        }
    }
}
