using DatabaseMigration.v1.Enums;
using System;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
    public class BehaviorTreeSerializable : SerializableItem
    {
        public BehaviorTreeSerializable()
        {
            ItemType = ItemType.BehaviorTree;
            FileName = "BehaviorTree.json";
        }

        public BehaviorTreeNodeSerializable RootNode;
    }
}