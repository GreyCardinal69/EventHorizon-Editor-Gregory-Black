//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using EditorDatabase.Enums;
using System;
using System.ComponentModel;

namespace EditorDatabase.Serializable
{
    [Serializable]
	public struct ComponentRestrictionsSerializable
	{
		public SizeClass[] ShipSizes;
		public bool NotForOrganicShips;
		public bool NotForMechanicShips;
		[DefaultValue("")]
		public string UniqueComponentTag;
        public int MaxComponentAmount;
    }
}
