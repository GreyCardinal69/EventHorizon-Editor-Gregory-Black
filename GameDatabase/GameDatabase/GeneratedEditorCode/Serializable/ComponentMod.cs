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
    public class ComponentModSerializable : SerializableItem
    {
        [DefaultValue( "" )]
        public string Description;
        public StatModificationSerializable[] Modifications;
    }
}
