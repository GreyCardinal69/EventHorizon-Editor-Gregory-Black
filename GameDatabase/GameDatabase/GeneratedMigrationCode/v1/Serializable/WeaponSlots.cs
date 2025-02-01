using DatabaseMigration.v1.Enums;
using System;
using System.ComponentModel;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
    public class WeaponSlotsSerializable : SerializableItem
    {

        public WeaponSlotsSerializable()
        {
            this.ItemType = ItemType.WeaponSlots;
            base.FileName = "WeaponSlots.json";
        }


        public WeaponSlotSerializable[] Slots;


        [DefaultValue("$GroupWeaponAny")]
        public string DefaultSlotName = "$GroupWeaponAny";


        [DefaultValue("icon_weapon_x")]
        public string DefaultSlotIcon = "icon_weapon_x";
    }
}