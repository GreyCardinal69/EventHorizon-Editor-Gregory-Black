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
    public class RequirementSerializable
    {
        public RequirementType Type;
        public int ItemId;
        public int MinValue;
        public int MaxValue;
        public bool BoolValue;
        public int Character;
        public int Faction;
        public LootContentSerializable Loot;
        public RequirementSerializable[] Requirements;
    }
}
