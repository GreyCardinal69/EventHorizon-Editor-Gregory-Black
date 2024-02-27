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
	public struct LootContentSerializable
	{
		public LootItemType Type;
		public int ItemId;
		public int MinAmount;
		public int MaxAmount;
		public float ValueRatio;
		public FactionFilterSerializable Factions;
		public LootItemSerializable[] Items;
	}
}
