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
        public List<TMaping> target_maps;

        public TargetManager()
        {
            selected = new List<GameObject>();
            target_maps = new List<TMaping>();
        }

        public void RunManager(ObjectManager objectManager, MouseState mouse)
        {
            foreach (TMaping tmap in target_maps)
            {
                tmap.UpdateLoop();
            }


            if (mouse.RightButton == ButtonState.Released && rightPrevious == ButtonState.Pressed)
            {
                foreach (GameObject update in objectManager.objectDictionary.Values)
                {
                    if (update.Selected && update.SelectType == selectType.Movable)
                    {
                        selected.Add(update);
                    }
                }

                if (selected.Count != 0)
                {
                    target_maps.Add(new TMaping(new Vector2(mouse.X, mouse.Y), selected));
                }


                // targets = Formation(selected.Count, new Vector2(mouse.X,mouse.Y));

                //for (int i = 0; i < selected.Count; i++)
                //{
                //    selected[i].Target = targets[i];
                //}
            }


            selected.Clear();

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
