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
	public class ShipBuildSerializable : SerializableItem
    {
        public int CustomAI;
        public int ShipId;
        [DefaultValue( true )]
        public bool AvailableForPlayer = true;
        [DefaultValue( true )]
        public bool AvailableForEnemy = true;
        public DifficultyClass DifficultyClass;
		public int BuildFaction;
		public InstalledComponentSerializable[] Components;
        public bool NotAvailableInGame;
    }
}
