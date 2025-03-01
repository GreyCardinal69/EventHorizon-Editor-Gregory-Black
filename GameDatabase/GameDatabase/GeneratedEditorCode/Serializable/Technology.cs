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
    public class TechnologySerializable : SerializableItem
    {
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
