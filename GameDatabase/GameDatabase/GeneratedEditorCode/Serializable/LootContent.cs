//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using EditorDatabase.Enums;
using EditorDatabase.Model;

namespace EditorDatabase.Serializable
{
	[Serializable]
	public class LootContentSerializable
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
