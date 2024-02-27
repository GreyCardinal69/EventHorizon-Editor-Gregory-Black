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
	public class VisualEffectElementSerializable
	{
		public VisualEffectType Type;
		[DefaultValue("")]
		public string Image;
		public ColorMode ColorMode;
		[DefaultValue("")]
		public string Color;
		public float GrowthRate;
		public float TurnRate;
		public float StartTime;
        [DefaultValue( 1f )]
        public float Lifetime = 1f;
        [DefaultValue( 1f )]
        public float ParticleSize = 1f;
        public bool Loop;
        [DefaultValue( 1 )]
        public int Quantity = 1;
        [DefaultValue( 1f )]
        public float Size = 1f;
    }
}
