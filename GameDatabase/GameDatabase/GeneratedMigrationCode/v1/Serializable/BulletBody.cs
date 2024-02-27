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
	public struct BulletBodySerializable
	{
		public BulletType Type;
		public float Size;
		public float Velocity;
		public float Range;
		public float Lifetime;
		public float Weight;
		public int HitPoints;
		[DefaultValue("")]
		public string Color;
		public int BulletPrefab;
		public float EnergyCost;
		public bool CanBeDisarmed;
		public bool FriendlyFire;
	}
}
