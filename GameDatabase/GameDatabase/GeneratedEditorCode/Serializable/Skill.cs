//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace EditorDatabase.Serializable
{
    [Serializable]
	public class SkillSerializable : SerializableItem
	{
		[DefaultValue("")]
		public string Name;
		[DefaultValue("")]
		public string Icon;
		[DefaultValue("")]
		public string Description;
		public float BaseRequirement;
		public float RequirementPerLevel;
		public float BasePrice;
		public float PricePerLevel;
		public int MaxLevel;
	}
}
