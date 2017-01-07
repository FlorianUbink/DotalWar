using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Components
{
    public class Behaviour
    {
        Vector2 seeking;
        List<GameObject> subscribers;

        public Behaviour()
        {
            subscribers = new List<GameObject>();
            seeking = new Vector2();
        }

        public void Add(GameObject subject)
        {
            subscribers.Add(subject);
        }

        public void RunSystem()
        {
            foreach(GameObject update in subscribers)
            {
                seeking = Seek(update) * 1;
                Arrival(update);
                update.LiniarSteer = seeking;
            }
        }

        private Vector2 Seek(GameObject update)
        {
            Vector2 temp = update.Target - update.Position;
            temp.Normalize();
            temp *= update.MaxAcceleration;
            if (float.IsNaN(temp.Length()))
            {
                temp = Vector2.Zero;
            }
            return temp;
        }

        private void Arrival(GameObject update)
        {
            Vector2 temp = update.Target - update.Position;
            if (temp.Length() <= 2)
            {
                update.Target = update.Position;
                update.Velocity = Vector2.Zero;
            }
        }
    }
}
