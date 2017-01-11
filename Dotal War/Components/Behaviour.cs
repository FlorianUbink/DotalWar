using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Components
{
    public class Behaviour
    {

        Vector2 seperation;
        Vector2 findTarget;

        List<GameObject> subscribers;

        public Behaviour()
        {
            subscribers = new List<GameObject>();
        }

        public void Add(GameObject subject, float decayCoeffcient,float threshold)
        {
            subscribers.Add(subject);
            subject.decay_Coefficient = decayCoeffcient;
            subject.threshold = threshold;
        }

        public void RunSystem()
        {
            foreach(GameObject update in subscribers)
            {
                findTarget = TargetSeek(update);
                seperation = Seperation(update);

                Debug.WriteLine("seekStrength: {0} seperationStrength: {1}", findTarget.Length(), seperation.Length());
                update.LiniarSteer = (findTarget + seperation)/2;
            }
        }

        #region Behaviours

        private Vector2 Seperation(GameObject update)
        {
            Vector2 temp = new Vector2();
            if (update.ThresholdObjects != null)
            {
                if (update.Velocity.Length() > 0)
                {
                    foreach (Vector2 anchor in update.ThresholdObjects)
                    {
                        Vector2 direction = update.Position - anchor;
                        float distance = direction.Length();

                        float strength = update.max_Acceleration * (update.threshold - distance) / update.threshold;

                        direction.Normalize();
                        temp += direction * strength;
                    }
                    update.ThresholdObjects.Clear();
                }

                else
                {
                    update.ThresholdObjects.Clear();
                }
            }
            return temp;
        }

        private Vector2 TargetSeek(GameObject update)
        {
            float targetRadius = 3;
            float slowRadius = 35;
            float timeToTarget = 0.1f;
            float speed;
            Vector2 steer = new Vector2();
            Vector2 velocity;
            //finding the geometrical relation to the target
            Vector2 direction = update.Target - update.Position;
            float distance = direction.Length();
            direction.Normalize();

            
            if(distance <= targetRadius)
            {
                update.Velocity = Vector2.Zero;
                update.Position = update.Target;
                return Vector2.Zero;
            }

            else
            {
                if(distance > slowRadius)
                {
                    speed = update.max_Speed;
                }

                else
                {
                    speed = (update.max_Speed * distance) / slowRadius;
                }

                velocity = direction * speed;

                steer = velocity - update.Velocity;
                steer /= timeToTarget;


                if (steer.Length() > update.max_Acceleration)
                {
                    steer.Normalize();
                    steer *= update.max_Acceleration;
                }

                return steer;
            }

        }

        #endregion
    }
}
