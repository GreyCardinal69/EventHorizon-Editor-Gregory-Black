//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using EditorDatabase.Model;
using EditorDatabase.Serializable;

namespace EditorDatabase.DataModel
{
    public partial class ExplorationSettings
	{
		partial void OnDataDeserialized(ExplorationSettingsSerializable serializable, Database database);
		partial void OnDataSerialized(ref ExplorationSettingsSerializable serializable);


		public ExplorationSettings(ExplorationSettingsSerializable serializable, Database database)
		{
			OutpostShip = database.GetShipId(serializable.OutpostShip);
			TurretShip = database.GetShipId(serializable.TurretShip);
			InfectedPlanetFaction = database.GetFactionId(serializable.InfectedPlanetFaction);
			HiveShipBuild = database.GetShipBuildId(serializable.HiveShipBuild);
			GasCloudDPS = serializable.GasCloudDPS;
			OnDataDeserialized(serializable, database);
		}

		public void Save(ExplorationSettingsSerializable serializable)
		{
			serializable.OutpostShip = OutpostShip.Value;
			serializable.TurretShip = TurretShip.Value;
			serializable.GasCloudDPS = GasCloudDPS;
			serializable.InfectedPlanetFaction = InfectedPlanetFaction.Value;
			serializable.HiveShipBuild = HiveShipBuild.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<Ship> OutpostShip = ItemId<Ship>.Empty;
		public ItemId<Ship> TurretShip = ItemId<Ship>.Empty;
		public ItemId<Faction> InfectedPlanetFaction = ItemId<Faction>.Empty;
		public ItemId<ShipBuild> HiveShipBuild = ItemId<ShipBuild>.Empty;
		public string GasCloudDPS;
		public static ExplorationSettings DefaultValue { get; private set; }
	}
}
