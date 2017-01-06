using Dotal_War.Collections;
using Dotal_War.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Managers
{
    public class TargetManager
    {
        ButtonState rightPrevious;

        public TargetManager()
        {
        }

        public void RunManager(ObjectManager objectManager, MouseState mouse)
        {
            if (mouse.RightButton == ButtonState.Released && rightPrevious == ButtonState.Pressed)
            {
                foreach (GameObject update in objectManager.objectDictionary.Values)
                {
                    if (update.Selected && update.SelectType == selectType.Movable)
                    {
                        update.Target = new Vector2(mouse.X, mouse.Y);
                    }
                }
            }



            rightPrevious = mouse.RightButton;
        }
    }
}
