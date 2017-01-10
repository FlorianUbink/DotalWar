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
        Vector2 seperation;

        float seekWeight = 1f;
        float seperationWeight = 0f;
        List<GameObject> subscribers;

        public Behaviour()
        {
            subscribers = new List<GameObject>();
            seeking = new Vector2();
        }

        public void Add(GameObject subject, float decayCoeffcient)
        {
            subscribers.Add(subject);
            subject.decay_Coefficient = decayCoeffcient;
        }

        public void RunSystem()
        {
            foreach(GameObject update in subscribers)
            {
                seeking = Seek(update) * seekWeight;
                seperation = Seperation(update) * seperationWeight;
                Arrival(update);
                update.LiniarSteer = seeking + seperation;
            }
        }

        #region Behaviours

        private Vector2 Seek(GameObject update)
        {
            Vector2 temp = update.Target - update.Position;
            if (temp.Length() != 0)
            {
                seekWeight = 1;
            }
            temp.Normalize();
            temp *= update.max_Acceleration;
            if (float.IsNaN(temp.Length()))
            {
                temp = Vector2.Zero;
            }
            return temp;
        }

        private void Arrival(GameObject update)
        {
            Vector2 temp = update.Target - update.Position;
            if (temp.Length() <=3)
            {
                update.Target = update.Position;
                seekWeight = 0;
                update.Velocity = Vector2.Zero;
            }
        }

        private Vector2 Seperation(GameObject update)
        {
            Vector2 temp = new Vector2();

            foreach(Vector2 anchor in update.ThresholdObjects)
            {
                Vector2 direction = update.Position - anchor;
                float distance = direction.Length();

                float strength = update.max_Acceleration * (50 - distance) / 50;

                direction.Normalize();
                temp += direction * strength;
            }
            update.ThresholdObjects.Clear();
            return temp;
        }

        #endregion
    }
}
