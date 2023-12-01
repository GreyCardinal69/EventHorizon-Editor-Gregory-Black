//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using EditorDatabase.Model;
using DatabaseMigration.v1.Enums;

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
