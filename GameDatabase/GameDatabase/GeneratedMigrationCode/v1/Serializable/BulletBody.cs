//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using DatabaseMigration.v1.Enums;
using System;
using System.ComponentModel;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
    public class BulletBodySerializable
    {
        public float Size;
        public float Length;
        public float Velocity;
        [DefaultValue( 1f )]
        public float ParentVelocityEffect = 1f;
        public bool AttachedToParent;
        [DefaultValue(true)]
        public bool DetonateWhenDestroyed = true;
        public float Range;
        public float Lifetime;
        public float Weight;
        public int HitPoints;
        [DefaultValue( "" )]
        public string Color;
        public int BulletPrefab;
        public float EnergyCost;
        public bool CanBeDisarmed;
        public bool FriendlyFire;
        public AiBulletBehavior AiBulletBehavior;
        public BulletTypeObsolete Type;
    }
}
