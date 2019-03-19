﻿using System;
using System.ComponentModel;

namespace GameDatabase.Serializable
{
    [Serializable]
    public class SerializableArtifact : SerializableItem
    {
        [DefaultValue("")]
        public string Name;
        [DefaultValue("")]
        public string Description;
        [DefaultValue("")]
        public string Icon;
        [DefaultValue("")]
        public string Color;
        public int Price;
    }
}
