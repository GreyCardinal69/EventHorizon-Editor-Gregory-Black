//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System.Linq;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;
using EditorDatabase.Model;

namespace EditorDatabase.DataModel
{
	public partial class GalaxySettings
	{
		partial void OnDataDeserialized(GalaxySettingsSerializable serializable, Database database);
		partial void OnDataSerialized(ref GalaxySettingsSerializable serializable);


		public GalaxySettings(GalaxySettingsSerializable serializable, Database database)
		{
			AbandonedStarbaseFaction = database.GetFactionId(serializable.AbandonedStarbaseFaction);
			StartingShipBuilds = serializable.StartingShipBuilds?.Select(id => new Wrapper<ShipBuild> { Item = database.GetShipBuildId(id) }).ToArray();
            DefaultStarbaseBuild = database.GetShipBuildId( serializable.DefaultStarbaseBuild );
            OnDataDeserialized(serializable, database);
		}

		public void Save(GalaxySettingsSerializable serializable)
		{
            serializable.MaxEnemyShipsLevel = MaxEnemyShipsLevel.Value;
            serializable.AbandonedStarbaseFaction = AbandonedStarbaseFaction.Value;
			if (StartingShipBuilds == null || StartingShipBuilds.Length == 0)
			    serializable.StartingShipBuilds = null;
			else
			    serializable.StartingShipBuilds = StartingShipBuilds.Select(wrapper => wrapper.Item.Value).ToArray();
            serializable.DefaultStarbaseBuild = DefaultStarbaseBuild.Value;
            OnDataSerialized(ref serializable);
		}

		public ItemId<Faction> AbandonedStarbaseFaction = ItemId<Faction>.Empty;
		public Wrapper<ShipBuild>[] StartingShipBuilds;
        public ItemId<ShipBuild> DefaultStarbaseBuild = ItemId<ShipBuild>.Empty;
        public NumericValue<int> MaxEnemyShipsLevel = new NumericValue<int>( 0, 100, 500 );
        public static GalaxySettings DefaultValue { get; private set; }
	}
}
