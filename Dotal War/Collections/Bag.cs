
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
        public int AccessID { get; set; }
        public int EnemyID { get; set; }
        public float Rotation { get; set; }
        public float max_Speed { get; set; }
        public float max_Acceleration { get; set; }
        public float decay_Coefficient { get; set; }
        public float threshold { get; set; }
        public float attack_range { get; set; }
        public float attack_speed { get; set; }
        public float attack_dammage { get; set; }
        public float defense_health { get; set; }
        public float defense_armor { get; set; }
        public float remainingDelay { get; set; }
        #endregion

        #region  Boolians
        public bool Selected { get; set; }
        public bool canAttack { get; set; }
        public bool validAttack { get; set; }
        public bool AttackAble { get; set; }
        public bool Alive { get; set; }
        #endregion

        #region Vector
        public Vector2 Position { get; set; }
        public Vector2 Target { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 LiniarSteer { get; set; }
        public Vector2 Origin { get; set; }
        #endregion

        #region Enumerations
        public selectType SelectType { get; set; }
        #endregion

        #region Lists
        public List<Vector2> ThresholdObjects { get; set; }
        #endregion

        #region Misc
        public Texture2D Sprite { get; set; }
        public Color Color { get; set; }


        #endregion


    }
}
