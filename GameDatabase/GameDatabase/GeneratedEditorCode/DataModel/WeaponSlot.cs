using EditorDatabase.Enums;
using EditorDatabase.Model;
using EditorDatabase.Serializable;
using System.Collections.Generic;
using System.Linq;
using static EditorDatabase.Property;

namespace EditorDatabase.DataModel
{
    public class WeaponSlot
    {

        public static WeaponSlot Create(WeaponSlotSerializable serializable, Database database)
        {
            if (serializable == null)
            {
                return WeaponSlot.DefaultValue;
            }
            return new WeaponSlot(serializable, database);
        }


        public WeaponSlot()
        {
        }


        private WeaponSlot(WeaponSlotSerializable serializable, Database database)
        {
            this.Letter = (string.IsNullOrEmpty(serializable.Letter) ? '\0' : serializable.Letter[0]);
            this.Name = serializable.Name;
            this.Icon = serializable.Icon;
        }


        public WeaponSlotSerializable Serialize()
        {
            return new WeaponSlotSerializable
            {
                Letter = ((this.Letter == '\0') ? string.Empty : this.Letter.ToString()),
                Name = this.Name,
                Icon = this.Icon
            };
        }




        public static WeaponSlot DefaultValue { get; private set; }


        public char Letter;


        public string Name;


        public string Icon;
    }
}
