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
        List<GameObject> selected;
        List<Vector2> targets;

        public TargetManager()
        {
            selected = new List<GameObject>();
        }

        public void RunManager(ObjectManager objectManager, MouseState mouse)
        {
            if (mouse.RightButton == ButtonState.Released && rightPrevious == ButtonState.Pressed)
            {
                foreach (GameObject update in objectManager.objectDictionary.Values)
                {
                    if (update.Selected && update.SelectType == selectType.Movable)
                    {
                        selected.Add(update);
                    }
                }

                targets = Formation(selected.Count, new Vector2(mouse.X,mouse.Y));

                for (int i = 0; i < selected.Count; i++)
                {
                    selected[i].Target = targets[i];
                }
            }

            if (selected.Count != 0)
            {
                targets.Clear();
                selected.Clear();
            }

            rightPrevious = mouse.RightButton;
        }

        private List<Vector2> Formation(int elements, Vector2 anchor)
        {
            List<Vector2> formation = new List<Vector2>();
            int column = -1;

            if (elements % 2 != 0)
            {
                column = (elements + 1) / 2;
            }

            else
            {
                column = elements / 2;
            }
            int row = column;

            if (elements == 2)
            {
                column = 2;
                row = 1;
            }

            int elementDistance = 10;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    formation.Add(new Vector2((anchor.X + elementDistance * j), (anchor.Y + elementDistance * i)));
                }
            }

            return formation;

        }
    }
}
