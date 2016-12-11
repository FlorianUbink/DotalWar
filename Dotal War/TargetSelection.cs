using Dotal_War.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War
{
    public class TargetSelection
    {
        ButtonState leftPrevious;
        List<Vector2> targetList;
        bool reset = false;
        public TargetSelection()
        {
            targetList = new List<Vector2>();
        }
        
        public void Update(MouseState mouse)
        {
            if (mouse.LeftButton == ButtonState.Released && leftPrevious == ButtonState.Pressed)
            {
                GameObjectDir.ObjectList[420].targetList = targetList;
                reset = true;
            }

            else if (mouse.LeftButton == ButtonState.Pressed)
            {
                if (reset)
                {
                    targetList.Clear();
                    reset = false;
                }
                targetList.Add(new Vector2(mouse.X, mouse.Y));
            }

            leftPrevious = mouse.LeftButton;
        }

    }
}
