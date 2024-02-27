//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using EditorDatabase.Enums;
using System;

namespace EditorDatabase.Serializable
{
    [Serializable]
	public struct ImpactEffectSerializable
	{
		public ImpactEffectType Type;
		public DamageType DamageType;
		public float Power;
		public float Factor;
	}
}
