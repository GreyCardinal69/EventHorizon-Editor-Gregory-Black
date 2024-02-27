//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using DatabaseMigration.v1.Enums;
using EditorDatabase.Serializable;
using System;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
	public class AmmunitionSerializable : SerializableItem
	{
		public AmmunitionSerializable()
		{
			ItemType = ItemType.Ammunition;
			FileName = "Ammunition.json";
		}

        public BulletControllerSerializable Controller;
        public BulletBodySerializable Body;
		public BulletTriggerSerializable[] Triggers;
		public BulletImpactType ImpactType;
		public ImpactEffectSerializable[] Effects;
	}
}
