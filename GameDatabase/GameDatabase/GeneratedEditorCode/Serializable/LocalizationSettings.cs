//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class LocalizationSettingsSerializable : SerializableItem
    {
        [DefaultValue( "$WeaponDamage" )]
        public string CorrosiveDamageText = "$WeaponDamage";
        [DefaultValue( "$WeaponDPS" )]
        public string CorrosiveDpsText = "$WeaponDPS";
    }
}
