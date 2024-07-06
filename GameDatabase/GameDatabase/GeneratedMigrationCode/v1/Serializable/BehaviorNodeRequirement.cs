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
    public class BehaviorNodeRequirementSerializable
    {
        public BehaviorRequirementType Type;
        public DeviceClass DeviceClass;
        public AiDifficultyLevel DifficultyLevel;
        public SizeClass SizeClass;
        [DefaultValue( 1f )]
        public float Value = 1f;
        public BehaviorNodeRequirementSerializable[] Requirements;
    }
}
