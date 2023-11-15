﻿using System;
using System.ComponentModel;
using EditorDatabase.Enums;
using EditorDatabase.Model;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class SpecialEventSettingsSerializable : SerializableItem
    {
        public bool EnableXmasEvent = true;
        public int XmasDaysBefore = 24;
        public int XmasDaysAfter = 15;
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