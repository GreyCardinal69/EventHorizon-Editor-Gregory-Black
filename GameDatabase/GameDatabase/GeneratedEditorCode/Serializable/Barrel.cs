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
	public struct BarrelSerializable
	{
		public Vector2 Position;
		public float Rotation;
		public float Offset;
		public int PlatformType;
		public float AutoAimingArc;
		public float RotationSpeed;
		[DefaultValue("")]
		public string WeaponClass;
		[DefaultValue("")]
		public string Image;
		public float Size;
	}
}
