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
	public class DebugSettingsSerializable : SerializableItem
	{
		public DebugSettingsSerializable()
		{
			ItemType = ItemType.DebugSettings;
			FileName = "DebugSettings.json";
		}
        public bool EnableDebugConsole;
        public DebugCodeSerializable[] Codes;
	}
}
