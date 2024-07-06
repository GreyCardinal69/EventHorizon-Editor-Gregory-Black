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
    public class ComponentModSerializable : SerializableItem
    {
        public ComponentModSerializable()
        {
            ItemType = ItemType.ComponentMod;
            FileName = "ComponentMod.json";
        }

        [DefaultValue( "" )]
        public string Description;
        public StatModificationSerializable[] Modifications;
    }
}
