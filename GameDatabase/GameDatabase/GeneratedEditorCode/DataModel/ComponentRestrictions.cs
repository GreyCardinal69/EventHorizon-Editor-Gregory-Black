//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using EditorDatabase.Enums;
using EditorDatabase.Model;
using EditorDatabase.Serializable;
using System.Linq;

namespace EditorDatabase.DataModel
{
    public partial class ComponentRestrictions
	{
		partial void OnDataDeserialized(ComponentRestrictionsSerializable serializable, Database database);
		partial void OnDataSerialized(ref ComponentRestrictionsSerializable serializable);

		public ComponentRestrictions() {}

		public ComponentRestrictions(ComponentRestrictionsSerializable serializable, Database database)
		{
            MaxComponentAmount = new NumericValue<int>( serializable.MaxComponentAmount, 0, 2147483647 );
            ShipSizes = serializable.ShipSizes?.Select(item => new ValueWrapper<SizeClass> { Value = item }).ToArray();
			NotForOrganicShips = serializable.NotForOrganicShips;
			NotForMechanicShips = serializable.NotForMechanicShips;
			UniqueComponentTag = serializable.UniqueComponentTag;
			OnDataDeserialized(serializable, database);
		}

		public ComponentRestrictionsSerializable Serialize()
		{
			var serializable = new ComponentRestrictionsSerializable();
            serializable.MaxComponentAmount = MaxComponentAmount.Value;
            if (ShipSizes == null || ShipSizes.Length == 0)
			    serializable.ShipSizes = null;
			else
			    serializable.ShipSizes = ShipSizes.Select(item => item.Value).ToArray();
			serializable.NotForOrganicShips = NotForOrganicShips;
			serializable.NotForMechanicShips = NotForMechanicShips;
			serializable.UniqueComponentTag = UniqueComponentTag;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public ValueWrapper<SizeClass>[] ShipSizes;
		public bool NotForOrganicShips;
		public bool NotForMechanicShips;
		public string UniqueComponentTag;
        public NumericValue<int> MaxComponentAmount = new NumericValue<int>( 0, 0, 2147483647 );
        public static ComponentRestrictions DefaultValue { get; private set; }
	}
}
