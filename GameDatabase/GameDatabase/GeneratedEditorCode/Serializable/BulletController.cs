//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using EditorDatabase.Enums;
using System;
using System.ComponentModel;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class BulletControllerSerializable
    {
        public float Lifetime;
        public BulletControllerType Type;
        public float StartingVelocityModifier = 0.1f;
        public bool IgnoreRotation;
        public bool SmartAim;
        [DefaultValue( "0" )]
        public string X = "0";
        [DefaultValue( "0" )]
        public string Y = "0";
        [DefaultValue( "0" )]
        public string Rotation = "0";
        [DefaultValue( "1" )]
        public string Size = "1";
        [DefaultValue( "1" )]
        public string Length = "1";
    }
}
