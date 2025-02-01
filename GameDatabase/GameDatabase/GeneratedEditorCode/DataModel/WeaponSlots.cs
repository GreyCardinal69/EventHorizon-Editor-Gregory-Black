using EditorDatabase.Enums;
using EditorDatabase.Model;
using EditorDatabase.Serializable;
using System.Collections.Generic;
using System.Linq;
using static EditorDatabase.Property;

namespace EditorDatabase.DataModel
{
    public class WeaponSlots
    {

        public static WeaponSlots Create(WeaponSlotsSerializable serializable, Database database)
        {
            if (serializable == null)
            {
                return WeaponSlots.DefaultValue;
            }
            return new WeaponSlots(serializable, database);
        }


        public WeaponSlots(WeaponSlotsSerializable serializable, Database database)
        {
            WeaponSlotSerializable[] slots = serializable.Slots;
            this.Slots = ((slots != null) ? (from item in slots
                                             select WeaponSlot.Create(item, database)).ToArray<WeaponSlot>() : null);
            this.DefaultSlotName = serializable.DefaultSlotName;
            this.DefaultSlotIcon = serializable.DefaultSlotIcon;
        }


        public void Save(WeaponSlotsSerializable serializable)
        {
            if (this.Slots == null || this.Slots.Length == 0)
            {
                serializable.Slots = null;
            }
            else
            {
                serializable.Slots = (from item in this.Slots
                                      select item.Serialize()).ToArray<WeaponSlotSerializable>();
            }
            serializable.DefaultSlotName = this.DefaultSlotName;
            serializable.DefaultSlotIcon = this.DefaultSlotIcon;
        }




        public static WeaponSlots DefaultValue { get; private set; }


        public WeaponSlot[] Slots;


        public string DefaultSlotName;


        public string DefaultSlotIcon;
    }
}
