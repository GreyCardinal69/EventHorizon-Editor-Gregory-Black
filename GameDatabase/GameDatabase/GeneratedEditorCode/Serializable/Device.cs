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
	public class DeviceSerializable : SerializableItem
	{
		public DeviceClass DeviceClass;
		public float EnergyConsumption;
		public float PassiveEnergyConsumption;
		public float Power;
		public float Range;
		public float Size;
		public float Cooldown;
		public float Lifetime;
		public Vector2 Offset;
        public int Prefab;
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
