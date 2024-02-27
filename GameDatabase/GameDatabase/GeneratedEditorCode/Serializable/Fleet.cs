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
	public class FleetSerializable : SerializableItem
	{
		public FactionFilterSerializable Factions;
		public int LevelBonus;
		public bool NoRandomShips;
		public int CombatTimeLimit;
		public RewardCondition LootCondition;
		public RewardCondition ExpCondition;
		public int[] SpecificShips;
		public bool NoShipChanging;
		public bool PlayerHasOneShip;
        public int CombatRules;
    }
}
