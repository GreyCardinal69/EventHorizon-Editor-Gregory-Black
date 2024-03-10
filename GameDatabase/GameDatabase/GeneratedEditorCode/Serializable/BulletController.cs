using EditorDatabase.Enums;
using System;
using System.ComponentModel;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class BulletControllerSerializable
    {
        public BulletControllerType Type;
        [DefaultValue( 1 )]
        public float StartingVelocityModifier = 1;
        public bool IgnoreRotation;
        public bool SmartAim;
    }
}