using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            subject.max_Speed = speed;
            subject.max_Acceleration = acceleration;
            
        }

        public void RunSystem(GameTime gameTime)
        {
            foreach (GameObject update in subscribers)
            {
                update.Velocity += update.LiniarSteer * gameTime.ElapsedGameTime.Milliseconds / 1000;
                update.Velocity = SpeedClip(update.Velocity, update.max_Speed);

                if (update.Velocity.Length() != 0)
                {
                    update.Rotation = (float)(Math.Atan2(update.Velocity.Y, update.Velocity.X) + Math.PI / 2);
                }

                else
                {
                    update.Rotation = 0f;
                }

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
