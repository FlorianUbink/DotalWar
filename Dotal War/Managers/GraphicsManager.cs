using Dotal_War.Collections;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Managers
{
    public class GraphicsManager
    {
        public void Update(SpriteBatch spriteBatch)
        {
            foreach (GameObject subject in GameObjectDir.ObjectList.Values)
            {
                subject.graphicsComponent.Draw(spriteBatch);
            }
        }

    }
}
