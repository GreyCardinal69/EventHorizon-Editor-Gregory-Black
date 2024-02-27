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
	public class VisualEffectSerializable : SerializableItem
	{
		public VisualEffectSerializable()
		{
			ItemType = ItemType.VisualEffect;
			FileName = "VisualEffect.json";
		}

		public VisualEffectElementSerializable[] Elements;
	}
}
