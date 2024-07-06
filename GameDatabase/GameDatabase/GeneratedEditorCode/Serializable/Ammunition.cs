//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using EditorDatabase.Enums;
using System;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class AmmunitionSerializable : SerializableItem
    {
        public BulletBodySerializable Body;
        public BulletControllerSerializable Controller;
        public BulletTriggerSerializable[] Triggers;
        public BulletImpactType ImpactType;
        public ImpactEffectSerializable[] Effects;
    }
}
