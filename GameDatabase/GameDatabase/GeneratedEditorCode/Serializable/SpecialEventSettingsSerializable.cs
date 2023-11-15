using System;
using System.ComponentModel;
using EditorDatabase.Enums;
using EditorDatabase.Model;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class SpecialEventSettingsSerializable : SerializableItem
    {
        public bool EnableXmasEvent;
        public int XmasDaysBefore;
        public int XmasDaysAfter;
        public int XmasQuest;
        public bool EnableEasterEvent;
        public int EasterDaysBefore;
        public int EasterDaysAfter;
        public int EasterQuest;
        public bool EnableHalloweenEvent;
        public int HalloweenDaysBefore;
        public int HalloweenDaysAfter;
        public int HalloweenQuest;
    }
}