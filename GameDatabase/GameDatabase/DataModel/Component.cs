using System.Linq;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;

namespace EditorDatabase.DataModel
{
	public partial class Component
	{
        partial void OnDataDeserialized(ComponentSerializable serializable, Database database)
        {
            if (!string.IsNullOrEmpty(serializable.WeaponSlotType))
                WeaponSlotType = serializable.WeaponSlotType;
            if (!string.IsNullOrEmpty(serializable.CellType))
                CellType = (CellType)serializable.CellType.First();
        }

		partial void OnDataSerialized(ref ComponentSerializable serializable)
        {
            serializable.AmmunitionId = Ammunition.IsNull ? AmmunitionObsolete.Value : Ammunition.Value;
            serializable.WeaponSlotType = WeaponSlotType;
            serializable.CellType = CellType != CellType.Empty ? ( ( char ) CellType ).ToString() : null;
        }

        public string WeaponSlotType;
        public CellType CellType;
	}
}
