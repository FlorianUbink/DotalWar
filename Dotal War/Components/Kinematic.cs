using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Dotal_War.Components
{
    public class Kinematic
    {
        List<GameObject> subscribers;

        public Kinematic()
        {
            subscribers = new List<GameObject>();
        }

        public void Add(GameObject subject, float speed, float acceleration)
        {
            subscribers.Add(subject);
            subject.Velocity = new Vector2();
            subject.Target = subject.Position;
            subject.MaxSpeed = speed;
            subject.MaxAcceleration = acceleration;
            
        }

        public void RunSystem(GameTime gameTime)
        {
            foreach (GameObject update in subscribers)
            {
                update.Velocity += update.LiniarSteer * gameTime.ElapsedGameTime.Milliseconds / 1000;
                update.Velocity = SpeedClip(update.Velocity, update.MaxSpeed);

                update.Position += update.Velocity * gameTime.ElapsedGameTime.Milliseconds / 1000;
            }
        }

        private Vector2 SpeedClip(Vector2 velocity, float maxSpeed)
        {
            if (velocity.Length() > maxSpeed)
            {
                velocity.Normalize();
                return velocity * maxSpeed;
            }

            else
            {
                return velocity;
            }
        }
    }
}
