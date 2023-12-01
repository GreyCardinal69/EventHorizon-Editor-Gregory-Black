using System;
using System.ComponentModel;
using EditorDatabase.Enums;
using EditorDatabase.Model;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class DebugSettingsSerializable : SerializableItem
    {
        public DebugCodeSerializable[] Codes;
    }
}