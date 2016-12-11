
using Dotal_War.Collections;
using Dotal_War.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Dotal_War
{
    public class ComponentManager
    {

        public void Update(GameTime gameTime)
        {
            foreach (GameObject subject in GameObjectDir.ObjectList.Values)
            {
                subject.kinematicComponent.gameTime = gameTime;
                subject.kinematicComponent.Update();
            }
        }
    }
}
