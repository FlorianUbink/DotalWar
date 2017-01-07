
using Dotal_War.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dotal_War
{
    public class Bag
    {
        #region Int/Float
        public int Objectid { get; set; }
        public float Rotation { get; set; }
        public float MaxSpeed { get; set; }
        public float MaxAcceleration { get; set; }
        #endregion


        #region  Boolians
        public bool Selected { get; set; }

        #endregion

        #region Vector
        public Vector2 Position { get; set; }
        public Vector2 Target { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 LiniarSteer { get; set; }
        public Vector2 RenderOffset { get; set; }
        #endregion

        #region Enumerations
        public selectType SelectType { get; set; }
        #endregion

        #region Lists

        #endregion

        #region Misc
        public Texture2D Sprite { get; set; }
        public Color Color { get; set; }


        #endregion


    }
}
