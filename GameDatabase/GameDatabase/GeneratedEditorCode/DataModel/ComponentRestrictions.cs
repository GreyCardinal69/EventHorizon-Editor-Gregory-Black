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
        partial void OnDataDeserialized( ComponentRestrictionsSerializable serializable, Database database );
        partial void OnDataSerialized( ref ComponentRestrictionsSerializable serializable );

        public static ComponentRestrictions Create( ComponentRestrictionsSerializable serializable, Database database )
        {
            if ( serializable == null ) return DefaultValue;
            return new ComponentRestrictions( serializable, database );
        }

        public ComponentRestrictions() { }

        public ComponentRestrictions( ComponentRestrictionsSerializable serializable, Database database )
        {
            ShipSizes = serializable.ShipSizes?.Select( item => new ValueWrapper<SizeClass> { Value = item } ).ToArray();
            NotForOrganicShips = serializable.NotForOrganicShips;
            NotForMechanicShips = serializable.NotForMechanicShips;
            this.ComponentGroupTag = database.GetComponentGroupTagId( serializable.ComponentGroupTag );
            MaxComponentAmount = new NumericValue<int>( serializable.MaxComponentAmount, 0, 2147483647 );
            OnDataDeserialized( serializable, database );
        }

        public ComponentRestrictionsSerializable Serialize()
        {
            var serializable = new ComponentRestrictionsSerializable();
            if ( ShipSizes == null || ShipSizes.Length == 0 )
                serializable.ShipSizes = null;
            else
                serializable.ShipSizes = ShipSizes.Select( item => item.Value ).ToArray();
            serializable.NotForOrganicShips = NotForOrganicShips;
            serializable.NotForMechanicShips = NotForMechanicShips;
            serializable.ComponentGroupTag = this.ComponentGroupTag.Value;
            serializable.MaxComponentAmount = MaxComponentAmount.Value;
            OnDataSerialized( ref serializable );
            return serializable;
        }

        public ValueWrapper<SizeClass>[] ShipSizes;
        public bool NotForOrganicShips;
        public bool NotForMechanicShips;
        public ItemId<ComponentGroupTag> ComponentGroupTag = ItemId<ComponentGroupTag>.Empty;
        public NumericValue<int> MaxComponentAmount = new NumericValue<int>( 0, 0, int.MaxValue );
        public static ComponentRestrictions DefaultValue { get; set; }
    }
}
