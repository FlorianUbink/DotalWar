using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War
{
    public class TMaping
    {
        Vector2 anchor_position;
        List<GameObject> members;
        List<Rectangle> occupied_space;
        List<Rectangle> potential_space;
        int[] transformX;
        int[] transformY;
        float maping_radius = 50f;
        

        public TMaping(Vector2 anchor, List<GameObject> members)
        {
            anchor_position = anchor;
            this.members = members;
            occupied_space = new List<Rectangle>();
            potential_space = new List<Rectangle>();
            transformX = new int[9] {0, 1, 0, -1, -1,  0,  0, 1, 1};
            transformY = new int[9] {0, 0, 1,  0,  0, -1, -1, 0, 0};

            // low res target allocation
            foreach (GameObject subject in members)
            {
                subject.Target = anchor;
            }
        }

        public int UpdateLoop()
        {
            if (members.Count != 0)
            {
                foreach (GameObject subject in members)
                {
                    float distance = Vector2.Distance(anchor_position, subject.Position);

                    if (distance < maping_radius)
                    {
                        // Create rectangle on anchor position with the size of the subject
                        Rectangle sub_rectangle = new Rectangle((int)anchor_position.X - subject.Sprite.Width/2,
                                                                (int)anchor_position.Y - subject.Sprite.Height/2,
                                                                subject.Sprite.Width,
                                                                subject.Sprite.Height);
                        // Transform rectangle
                        for (int i = 0; i < 9; i++)
                        {
                            sub_rectangle.X += sub_rectangle.Width * transformX[i];
                            sub_rectangle.Y += sub_rectangle.Height * transformY[i];

                            potential_space.Add(sub_rectangle);
                        }

                        //TODO: compare potential to occupied, remove potentials that are occupied from list

                        // Compares potential_space with occupied_space
                        for (int i = 0; i < occupied_space.Count - 1; i++)
                        {
                            bool reloop = true;
                            while (reloop)
                            {
                                reloop = false;
                                foreach (Rectangle potential in potential_space)
                                {
                                    if (potential.Intersects(occupied_space[i]))
                                    {
                                        potential_space.Remove(potential);
                                        reloop = true;
                                        break;
                                    }
                                }
                            }
                        }

                    }
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void draw(SpriteBatch spriteBatch, Texture2D sprite)
        {
            foreach (Rectangle rect in potential_space)
            {
                spriteBatch.Draw(sprite, rect, Color.Green);
            }
        }
    }
}
