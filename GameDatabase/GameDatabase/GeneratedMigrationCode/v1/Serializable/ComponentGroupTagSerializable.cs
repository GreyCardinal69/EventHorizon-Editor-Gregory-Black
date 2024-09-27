using DatabaseMigration.v1.Enums;
using System;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
    public class ComponentGroupTagSerializable : SerializableItem
    {

        public ComponentGroupTagSerializable()
        {
            this.ItemType = ItemType.ComponentGroupTag;
            base.FileName = "ComponentGroupTag.json";
        }


        public int MaxInstallableComponents;
    }
}