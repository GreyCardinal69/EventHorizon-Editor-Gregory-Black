//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using DatabaseMigration.v1.Enums;
using EditorDatabase.Model;
using System;
using System.ComponentModel;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
	public class DeviceSerializable : SerializableItem
	{
		public DeviceSerializable()
		{
			ItemType = ItemType.Device;
			FileName = "Device.json";
		}
        public int Prefab;
        public DeviceClass DeviceClass;
		public float EnergyConsumption;
		public float PassiveEnergyConsumption;
		public float Power;
		public float Range;
		public float Size;
		public float Cooldown;
		public float Lifetime;
		public Vector2 Offset;
		public ActivationType ActivationType;
		[DefaultValue("")]
		public string Color;
		[DefaultValue("")]
		public string Sound;
		[DefaultValue("")]
		public string EffectPrefab;
		[DefaultValue("")]
		public string ObjectPrefab;
		[DefaultValue("")]
		public string ControlButtonIcon;
	}
}
