using EditorDatabase.Enums;
using System;
using System.ComponentModel;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class WeaponSlotSerializable
    {

        [DefaultValue("")]
        public string Letter;


        [DefaultValue("")]
        public string Name;


        [DefaultValue("")]
        public string Icon;
    }
}
