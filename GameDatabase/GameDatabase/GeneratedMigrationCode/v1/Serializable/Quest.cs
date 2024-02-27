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
	public class QuestSerializable : SerializableItem
	{
		public QuestSerializable()
		{
			ItemType = ItemType.Quest;
			FileName = "Quest.json";
		}
        public bool UseRandomSeed;
        [DefaultValue("")]
		public string Name;
		public QuestType QuestType;
		public StartCondition StartCondition;
		public float Weight;
		public QuestOriginSerializable Origin;
		public RequirementSerializable Requirement;
		public int Level;
		public NodeSerializable[] Nodes;
	}
}
