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
	public struct InstalledComponentSerializable
	{
		public int ComponentId;
        public int Modification;
        public ModificationQuality Quality;
		public int X;
		public int Y;
		public int BarrelId;
		public int Behaviour;
		public int KeyBinding;
	}
}
