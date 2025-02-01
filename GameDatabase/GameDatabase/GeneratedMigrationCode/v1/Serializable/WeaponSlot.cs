using DatabaseMigration.v1.Enums;
using System;
using System.ComponentModel;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
    public class WeaponSlotSerializable
    {

        public string Letter;


        [DefaultValue("")]
        public string Name;


        [DefaultValue("")]
        public string Icon;
    }
}