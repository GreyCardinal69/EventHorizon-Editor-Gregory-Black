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
	public class SatelliteSerializable : SerializableItem
	{
		[DefaultValue("")]
		public string Name;
		[DefaultValue("")]
		public string ModelImage;
		public float ModelScale;
		public SizeClass SizeClass;
		[DefaultValue("")]
		public string Layout;
		public BarrelSerializable[] Barrels;
	}
}
