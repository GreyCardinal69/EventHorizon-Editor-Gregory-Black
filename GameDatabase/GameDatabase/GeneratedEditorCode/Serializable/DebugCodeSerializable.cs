using System;
using System.ComponentModel;
using EditorDatabase.Enums;
using EditorDatabase.Model;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public struct DebugCodeSerializable
    {
        public int Code;
        public LootContentSerializable Loot;
    }
}