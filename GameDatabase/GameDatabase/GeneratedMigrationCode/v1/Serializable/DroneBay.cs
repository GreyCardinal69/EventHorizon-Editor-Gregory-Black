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
	public class DroneBaySerializable : SerializableItem
	{
		public DroneBaySerializable()
		{
			ItemType = ItemType.DroneBay;
			FileName = "DroneBay.json";
		}

		public float EnergyConsumption;
		public float PassiveEnergyConsumption;
		public float Range;
		public float DamageMultiplier;
		public float DefenseMultiplier;
		public float SpeedMultiplier;
		public int BuildExtraCycles;
		public bool ImprovedAi;
		public int Capacity;
		public ActivationType ActivationType;
		[DefaultValue("")]
		public string LaunchSound;
		[DefaultValue("")]
		public string LaunchEffectPrefab;
		[DefaultValue("")]
		public string ControlButtonIcon;
        public int DefensiveDroneAI;
        public int OffensiveDroneAI;
    }
}
