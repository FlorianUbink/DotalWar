
using Dotal_War.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dotal_War
{
    public class Bag
    {
        // Add Data properties here
        #region Components
        public KinematicComponent kinematicComponent { get; set; }
        public GraphicsComponent graphicsComponent { get; set; }

        #endregion

        #region Int/Float
        public int objectid { get; set; }
        public float rotation { get; set; }
        #endregion

        #region Vector
        public Vector2 Position { get; set; }
        public Vector2 RenderOffset { get; set; }
        #endregion

        #region Enumerations

        #endregion

        #region Lists
        public List<Vector2> targetList { get; set; }

        #endregion

        #region Misc
        public Texture2D Sprite { get; set; }
        public Color Color { get; set; }


        #endregion


    }
}
