﻿using System;
using System.ComponentModel;
using EditorDatabase.Model;
using DatabaseMigration.v1.Enums;

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