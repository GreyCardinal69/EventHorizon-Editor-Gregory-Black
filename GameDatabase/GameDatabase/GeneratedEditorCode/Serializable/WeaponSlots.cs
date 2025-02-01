using EditorDatabase.Enums;
using System;
using System.ComponentModel;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class WeaponSlotsSerializable : SerializableItem
    {

        public WeaponSlotSerializable[] Slots;


        [DefaultValue("$GroupWeaponAny")]
        public string DefaultSlotName = "$GroupWeaponAny";


        [DefaultValue("icon_weapon_x")]
        public string DefaultSlotIcon = "icon_weapon_x";
    }
}
