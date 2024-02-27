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
            SurvivalCombatRules = database.GetCombatRulesId( serializable.SurvivalCombatRules );
            StarbaseCombatRules = database.GetCombatRulesId( serializable.StarbaseCombatRules );
            FlagshipCombatRules = database.GetCombatRulesId( serializable.FlagshipCombatRules );
            ArenaCombatRules = database.GetCombatRulesId( serializable.ArenaCombatRules );
            ChallengeCombatRules = database.GetCombatRulesId( serializable.ChallengeCombatRules );
            QuickCombatRules = database.GetCombatRulesId( serializable.QuickCombatRules );
            AbandonedStarbaseFaction = database.GetFactionId(serializable.AbandonedStarbaseFaction);
			StartingShipBuilds = serializable.StartingShipBuilds?.Select(id => new Wrapper<ShipBuild> { Item = database.GetShipBuildId(id) }).ToArray();
            StartingInventory = database.GetLootId( serializable.StartingInventory );
            SupporterPackShip = database.GetShipBuildId(serializable.SupporterPackShip);
			DefaultStarbaseBuild = database.GetShipBuildId(serializable.DefaultStarbaseBuild);
            MaxEnemyShipsLevel = new NumericValue<int>( serializable.MaxEnemyShipsLevel, 0, 500 );
            EnemyLevel = serializable.EnemyLevel;
            ShipMinSpawnDistance = serializable.ShipMinSpawnDistance;
            OnDataDeserialized(serializable, database);
		}

		public void Save(GalaxySettingsSerializable serializable)
        {
            serializable.SurvivalCombatRules = SurvivalCombatRules.Value;
            serializable.StarbaseCombatRules = StarbaseCombatRules.Value;
            serializable.FlagshipCombatRules = FlagshipCombatRules.Value;
            serializable.ArenaCombatRules = ArenaCombatRules.Value;
            serializable.ChallengeCombatRules = ChallengeCombatRules.Value;
            serializable.QuickCombatRules = QuickCombatRules.Value;
            serializable.AbandonedStarbaseFaction = AbandonedStarbaseFaction.Value;
			if (StartingShipBuilds == null || StartingShipBuilds.Length == 0)
			    serializable.StartingShipBuilds = null;
			else
			    serializable.StartingShipBuilds = StartingShipBuilds.Select(wrapper => wrapper.Item.Value).ToArray();
            serializable.StartingInventory = StartingInventory.Value;
            serializable.SupporterPackShip = SupporterPackShip.Value;
			serializable.DefaultStarbaseBuild = DefaultStarbaseBuild.Value;
			serializable.MaxEnemyShipsLevel = MaxEnemyShipsLevel.Value;
            serializable.ShipMinSpawnDistance = ShipMinSpawnDistance;
            serializable.EnemyLevel = EnemyLevel;
			OnDataSerialized(ref serializable);
		}
        public ItemId<CombatRules> SurvivalCombatRules = ItemId<CombatRules>.Empty;
        public ItemId<CombatRules> StarbaseCombatRules = ItemId<CombatRules>.Empty;
        public ItemId<CombatRules> FlagshipCombatRules = ItemId<CombatRules>.Empty;
        public ItemId<CombatRules> ArenaCombatRules = ItemId<CombatRules>.Empty;
        public ItemId<CombatRules> ChallengeCombatRules = ItemId<CombatRules>.Empty;
        public ItemId<CombatRules> QuickCombatRules = ItemId<CombatRules>.Empty;
        public ItemId<Faction> AbandonedStarbaseFaction = ItemId<Faction>.Empty;
		public Wrapper<ShipBuild>[] StartingShipBuilds;
        public ItemId<LootModel> StartingInventory = ItemId<LootModel>.Empty;
		public ItemId<ShipBuild> SupporterPackShip = ItemId<ShipBuild>.Empty;
		public ItemId<ShipBuild> DefaultStarbaseBuild = ItemId<ShipBuild>.Empty;
        public NumericValue<int> MaxEnemyShipsLevel = new NumericValue<int>( 0, 0, 500 );
        public string EnemyLevel;
        public string ShipMinSpawnDistance;

        public static GalaxySettings DefaultValue { get; private set; }
	}
}
