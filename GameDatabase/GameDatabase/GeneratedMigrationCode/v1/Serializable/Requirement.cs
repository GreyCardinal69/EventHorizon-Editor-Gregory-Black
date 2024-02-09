//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using EditorDatabase.Model;
using DatabaseMigration.v1.Enums;

namespace DatabaseMigration.v1.Serializable
{
	[Serializable]
	public struct RequirementSerializable
	{
		public bool BoolValue;
		public RequirementType Type;
		public int ItemId;
		public int MinValue;
		public int MaxValue;
		public int Character;
		public int Faction;
		public LootContentSerializable Loot;
		public RequirementSerializable[] Requirements;
	}
}
