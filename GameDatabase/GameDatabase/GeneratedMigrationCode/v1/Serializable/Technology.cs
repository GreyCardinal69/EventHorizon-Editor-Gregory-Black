//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using DatabaseMigration.v1.Enums;
using System;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
    public class TechnologySerializable : SerializableItem
    {
        public TechnologySerializable()
        {
            ItemType = ItemType.Technology;
            FileName = "Technology.json";
        }

        public bool DoesnPreventUnlocking;
        public TechType Type;
        public int ItemId;
        public int Faction;
        public int Price;
        public bool Hidden;
        public bool Special;
        public int[] Dependencies;
        public int CustomCraftingLevel;
    }
}
