//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections.Generic;
using EditorDatabase.DataModel;
using EditorDatabase.Storage;
using EditorDatabase.Model;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;
using System.IO;
using System.Security.Cryptography;
using System.Drawing;
using System.Windows.Forms;
using GameDatabase;

namespace EditorDatabase
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText( this RichTextBox box, string text, Color color, bool addNewLine = false )
        {
            box.SuspendLayout();
            box.SelectionColor = color;
            box.AppendText( addNewLine
                ? $"{text}{Environment.NewLine}"
                : text );
            box.ScrollToCaret();
            box.ResumeLayout();
        }
    }
    public partial class Database
    {
        public const int VersionMajor = 1;
        public const int VersionMinor = 5;
        public DatabaseContent Content => _content;

        public Database( IDataStorage storage )
        {
            _serializer = new JsonSerializer();
            _content = new DatabaseContent( _serializer, storage );
        }

        public IImageData GetImage( string name ) { return _content.GetImage( name ); }

        public void ClearOutside()
        {
            Clear();
        }

        public void Save( IDataStorage storage )
        {
            var secondaryDb = MainWindow.MainInstance._secondaryDatabse;

            foreach ( var item in _ammunitionObsoleteMap )
            {
                var value = _content.GetAmmunitionObsolete( item.Key );
                if ( value != secondaryDb.Content.GetAmmunitionObsolete( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _behaviorTreeMap )
            {
                var value = _content.GetBehaviorTree( item.Key );
                if ( value != secondaryDb.Content.GetBehaviorTree( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _gameObjectPrefabMap )
            {
                var value = _content.GetGameObjectPrefab( item.Key );
                if ( value != secondaryDb.Content.GetGameObjectPrefab( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _combatRulesMap )
            {
                var value = _content.GetCombatRules( item.Key );
                if ( value != secondaryDb.Content.GetCombatRules( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _componentMap )
            {
                var value = _content.GetComponent( item.Key );
                if ( value != secondaryDb.Content.GetComponent( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _componentModMap )
            {
                var value = _content.GetComponentMod( item.Key );
                if ( value != secondaryDb.Content.GetComponentMod( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _componentStatsMap )
            {
                var value = _content.GetComponentStats( item.Key );
                if ( value != secondaryDb.Content.GetComponentStats( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _deviceMap )
            {
                var value = _content.GetDevice( item.Key );
                if ( value != secondaryDb.Content.GetDevice( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _droneBayMap )
            {
                var value = _content.GetDroneBay( item.Key );
                if ( value != secondaryDb.Content.GetDroneBay( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _factionMap )
            {
                var value = _content.GetFaction( item.Key );
                if ( value != secondaryDb.Content.GetFaction( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _satelliteMap )
            {
                var value = _content.GetSatellite( item.Key );
                if ( value != secondaryDb.Content.GetSatellite( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _satelliteBuildMap )
            {
                var value = _content.GetSatelliteBuild( item.Key );
                if ( value != secondaryDb.Content.GetSatelliteBuild( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _shipMap )
            {
                var value = _content.GetShip( item.Key );
                if ( value != secondaryDb.Content.GetShip( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _shipBuildMap )
            {
                var value = _content.GetShipBuild( item.Key );
                if ( value != secondaryDb.Content.GetShipBuild( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _skillMap )
            {
                var value = _content.GetSkill( item.Key );
                if ( value != secondaryDb.Content.GetSkill( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _technologyMap )
            {
                var value = _content.GetTechnology( item.Key );
                if ( value != secondaryDb.Content.GetTechnology( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _characterMap )
            {
                var value = _content.GetCharacter( item.Key );
                if ( value != secondaryDb.Content.GetCharacter( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _fleetMap )
            {
                var value = _content.GetFleet( item.Key );
                if ( value != secondaryDb.Content.GetFleet( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _lootMap )
            {
                var value = _content.GetLoot( item.Key );
                if ( value != secondaryDb.Content.GetLoot( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _questMap )
            {
                var value = _content.GetQuest( item.Key );
                if ( value != secondaryDb.Content.GetQuest( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _questItemMap )
            {
                var value = _content.GetQuestItem( item.Key );
                if ( value != secondaryDb.Content.GetQuestItem( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _ammunitionMap )
            {
                var value = _content.GetAmmunition( item.Key );
                if ( value != secondaryDb.Content.GetAmmunition( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _bulletPrefabMap )
            {
                var value = _content.GetBulletPrefab( item.Key );
                if ( value != secondaryDb.Content.GetBulletPrefab( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _visualEffectMap )
            {
                var value = _content.GetVisualEffect( item.Key );
                if ( value != secondaryDb.Content.GetVisualEffect( item.Key ) )
                    item.Value.Save( value );
            }

            foreach ( var item in _weaponMap )
            {
                var value = _content.GetWeapon( item.Key );
                if ( value != secondaryDb.Content.GetWeapon( item.Key ) )
                    item.Value.Save( value );
            }

            _uiSettings?.Save( _content.UiSettings );
            _debugSettings?.Save( _content.DebugSettings );
            _skillSettings?.Save( _content.SkillSettings );
            _databaseSettings?.Save( _content.DatabaseSettings );
            _explorationSettings?.Save( _content.ExplorationSettings );
            _frontierSettings?.Save( _content.FrontierSettings );
            _galaxySettings?.Save( _content.GalaxySettings );
            _shipModSettings?.Save( _content.ShipModSettings );
            _shipSettings?.Save( _content.ShipSettings );
            _specialEventSettings?.Save( _content.SpecialEventSettings );
            _combatSettings?.Save( _content.CombatSettings );
            _content.Save( storage, _serializer );
        }

        public IEnumerable<IItemId> GetItemList( Type type )
        {
            if ( type == typeof( CombatRules ) ) return _content.CombatRulesList.Select( item => new ItemId<CombatRules>( item ) );
            if ( type == typeof( GameObjectPrefab ) ) return _content.GameObjectPrefabList.Select( item => new ItemId<GameObjectPrefab>( item ) );
            if ( type == typeof( AmmunitionObsolete ) ) return _content.AmmunitionObsoleteList.Select( item => new ItemId<AmmunitionObsolete>( item ) );
            if ( type == typeof( Component ) ) return _content.ComponentList.Select( item => new ItemId<Component>( item ) );
            if ( type == typeof( ComponentMod ) ) return _content.ComponentModList.Select( item => new ItemId<ComponentMod>( item ) );
            if ( type == typeof( ComponentStats ) ) return _content.ComponentStatsList.Select( item => new ItemId<ComponentStats>( item ) );
            if ( type == typeof( Device ) ) return _content.DeviceList.Select( item => new ItemId<Device>( item ) );
            if ( type == typeof( DroneBay ) ) return _content.DroneBayList.Select( item => new ItemId<DroneBay>( item ) );
            if ( type == typeof( Faction ) ) return _content.FactionList.Select( item => new ItemId<Faction>( item ) );
            if ( type == typeof( Satellite ) ) return _content.SatelliteList.Select( item => new ItemId<Satellite>( item ) );
            if ( type == typeof( SatelliteBuild ) ) return _content.SatelliteBuildList.Select( item => new ItemId<SatelliteBuild>( item ) );
            if ( type == typeof( Ship ) ) return _content.ShipList.Select( item => new ItemId<Ship>( item ) );
            if ( type == typeof( ShipBuild ) ) return _content.ShipBuildList.Select( item => new ItemId<ShipBuild>( item ) );
            if ( type == typeof( Skill ) ) return _content.SkillList.Select( item => new ItemId<Skill>( item ) );
            if ( type == typeof( Technology ) ) return _content.TechnologyList.Select( item => new ItemId<Technology>( item ) );
            if ( type == typeof( Character ) ) return _content.CharacterList.Select( item => new ItemId<Character>( item ) );
            if ( type == typeof( Fleet ) ) return _content.FleetList.Select( item => new ItemId<Fleet>( item ) );
            if ( type == typeof( LootModel ) ) return _content.LootList.Select( item => new ItemId<LootModel>( item ) );
            if ( type == typeof( QuestModel ) ) return _content.QuestList.Select( item => new ItemId<QuestModel>( item ) );
            if ( type == typeof( QuestItem ) ) return _content.QuestItemList.Select( item => new ItemId<QuestItem>( item ) );
            if ( type == typeof( Ammunition ) ) return _content.AmmunitionList.Select( item => new ItemId<Ammunition>( item ) );
            if ( type == typeof( BulletPrefab ) ) return _content.BulletPrefabList.Select( item => new ItemId<BulletPrefab>( item ) );
            if ( type == typeof( VisualEffect ) ) return _content.VisualEffectList.Select( item => new ItemId<VisualEffect>( item ) );
            if ( type == typeof( Weapon ) ) return _content.WeaponList.Select( item => new ItemId<Weapon>( item ) );
            if ( type == typeof( BehaviorTreeModel ) ) return _content.BehaviorTreeList.Select( item => new ItemId<BehaviorTreeModel>( item ) );
            return Enumerable.Empty<IItemId>();
        }

        public object GetItem( ItemType type, int id )
        {
            switch ( type )
            {
                case ItemType.ShipModSettings: return ShipModSettings;
                case ItemType.FrontierSettings: return FrontierSettings;
                case ItemType.AmmunitionObsolete: return GetAmmunitionObsolete( id );
                case ItemType.Component: return GetComponent( id );
                case ItemType.ComponentMod: return GetComponentMod( id );
                case ItemType.ComponentStats: return GetComponentStats( id );
                case ItemType.Device: return GetDevice( id );
                case ItemType.DroneBay: return GetDroneBay( id );
                case ItemType.Faction: return GetFaction( id );
                case ItemType.Satellite: return GetSatellite( id );
                case ItemType.SatelliteBuild: return GetSatelliteBuild( id );
                case ItemType.Ship: return GetShip( id );
                case ItemType.ShipBuild: return GetShipBuild( id );
                case ItemType.Skill: return GetSkill( id );
                case ItemType.Technology: return GetTechnology( id );
                case ItemType.Character: return GetCharacter( id );
                case ItemType.Fleet: return GetFleet( id );
                case ItemType.Loot: return GetLoot( id );
                case ItemType.Quest: return GetQuest( id );
                case ItemType.QuestItem: return GetQuestItem( id );
                case ItemType.Ammunition: return GetAmmunition( id );
                case ItemType.BulletPrefab: return GetBulletPrefab( id );
                case ItemType.VisualEffect: return GetVisualEffect( id );
                case ItemType.Weapon: return GetWeapon( id );
                case ItemType.GameObjectPrefab: return GetGameObjectPrefab( id );
                case ItemType.CombatRules: return GetCombatRules( id );
                case ItemType.UiSettings: return UiSettings;
                case ItemType.DatabaseSettings: return DatabaseSettings;
                case ItemType.ExplorationSettings: return ExplorationSettings;
                case ItemType.GalaxySettings: return GalaxySettings;
                case ItemType.ShipSettings: return ShipSettings;
                case ItemType.SkillSettings: return SkillSettings;
                case ItemType.SpecialEventSettings: return SpecialEventSettings;
                case ItemType.DebugSettings: return DebugSettings;
                case ItemType.CombatSettings: return CombatSettings;
                case ItemType.BehaviorTree: return GetBehaviorTree( id );
                default: return null;
            }
        }

        public void SetItem( ItemType type, int id, int old )
        {
            switch ( type )
            {
                case ItemType.AmmunitionObsolete: SetAmmunitionObsolete( id, old ); break;
                case ItemType.Component: SetComponent( id, old ); break;
                case ItemType.ComponentMod: SetComponentMod( id, old ); break;
                case ItemType.ComponentStats: SetComponentStats( id, old ); break;
                case ItemType.Device: SetDevice( id, old ); break;
                case ItemType.DroneBay: SetDroneBay( id, old ); break;
                case ItemType.Faction: SetFaction( id, old ); break;
                case ItemType.Satellite: SetSatellite( id, old ); break;
                case ItemType.SatelliteBuild: SetSatelliteBuild( id, old ); break;
                case ItemType.Ship: SetShip( id, old ); break;
                case ItemType.ShipBuild: SetShipBuild( id, old ); break;
                case ItemType.Skill: SetSkill( id, old ); break;
                case ItemType.Technology: SetTechnology( id, old ); break;
                case ItemType.Character: SetCharacter( id, old ); break;
                case ItemType.Fleet: SetFleet( id, old ); break;
                case ItemType.Loot: SetLoot( id, old ); break;
                case ItemType.Quest: SetQuest( id, old ); break;
                case ItemType.GameObjectPrefab: SetGameObjectPrefab( id, old ); break;
                case ItemType.CombatRules: SetCombatRules( id, old ); break;
                case ItemType.QuestItem: SetQuestItem( id, old ); break;
                case ItemType.Ammunition: SetAmmunition( id, old ); break;
                case ItemType.BulletPrefab: SetBulletPrefab( id, old ); break;
                case ItemType.VisualEffect: SetVisualEffect( id, old ); break;
                case ItemType.Weapon: SetWeapon( id, old ); break;
                case ItemType.BehaviorTree: SetBehaviorTree( id, old ); break;
            }
        }

        public UiSettings UiSettings => _uiSettings ?? ( _uiSettings = UiSettings.Create( _content.UiSettings, this ) );
        public CombatSettings CombatSettings => _combatSettings ?? ( _combatSettings = CombatSettings.Create( _content.CombatSettings, this ) );
        public DebugSettings DebugSettings => _debugSettings ?? ( _debugSettings = new DebugSettings( _content.DebugSettings, this ) );
        public DatabaseSettings DatabaseSettings => _databaseSettings ?? ( _databaseSettings = new DatabaseSettings( _content.DatabaseSettings, this ) );
        public ExplorationSettings ExplorationSettings => _explorationSettings ?? ( _explorationSettings = new ExplorationSettings( _content.ExplorationSettings, this ) );
        public GalaxySettings GalaxySettings => _galaxySettings ?? ( _galaxySettings = new GalaxySettings( _content.GalaxySettings, this ) );
        public ShipModSettings ShipModSettings => _shipModSettings ?? ( _shipModSettings = new ShipModSettings( _content.ShipModSettings, this ) );
        public ShipSettings ShipSettings => _shipSettings ?? ( _shipSettings = new ShipSettings( _content.ShipSettings, this ) );
        public SpecialEventSettings SpecialEventSettings => _specialEventSettings ?? ( _specialEventSettings = new SpecialEventSettings( _content.SpecialEventSettings, this ) );
        public SkillSettings SkillSettings => _skillSettings ?? ( _skillSettings = new SkillSettings( _content.SkillSettings, this ) );
        public ItemId<AmmunitionObsolete> GetAmmunitionObsoleteId( int id ) { return new ItemId<AmmunitionObsolete>( _content.GetAmmunitionObsolete( id ) ); }

        public AmmunitionObsolete GetAmmunitionObsolete( int id )
        {
            if ( !_ammunitionObsoleteMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetAmmunitionObsolete( id );
                item = new AmmunitionObsolete( serializable, this );
                _ammunitionObsoleteMap.Add( id, item );
            }
            return item;
        }

        public ItemId<BehaviorTreeModel> GetBehaviorTreeId( int id ) { return new ItemId<BehaviorTreeModel>( _content.GetBehaviorTree( id ) ); }
        public BehaviorTreeModel GetBehaviorTree( int id )
        {
            if ( !_behaviorTreeMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetBehaviorTree( id );
                item = BehaviorTreeModel.Create( serializable, this );
                _behaviorTreeMap.Add( id, item );
            }
            return item;
        }

        public ItemId<CombatRules> GetCombatRulesId( int id ) { return new ItemId<CombatRules>( _content.GetCombatRules( id ) ); }
        public CombatRules GetCombatRules( int id )
        {
            if ( !_combatRulesMap.TryGetValue( id, out var item ) )
            {
                CombatRulesSerializable serializable = _content.GetCombatRules( id );
                item = CombatRules.Create( serializable, this );
                _combatRulesMap.Add( id, item );
            }
            return item;
        }

        public ItemId<GameObjectPrefab> GetGameObjectPrefabId( int id ) { return new ItemId<GameObjectPrefab>( _content.GetGameObjectPrefab( id ) ); }
        public GameObjectPrefab GetGameObjectPrefab( int id )
        {
            if ( !_gameObjectPrefabMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetGameObjectPrefab( id );
                item = GameObjectPrefab.Create( serializable, this );
                _gameObjectPrefabMap.Add( id, item );
            }
            return item;
        }

        public ItemId<Component> GetComponentId( int id ) { return new ItemId<Component>( _content.GetComponent( id ) ); }
        public Component GetComponent( int id )
        {
            if ( !_componentMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetComponent( id );
                item = new Component( serializable, this );
                _componentMap.Add( id, item );
            }
            return item;
        }

        public ItemId<ComponentMod> GetComponentModId( int id ) { return new ItemId<ComponentMod>( _content.GetComponentMod( id ) ); }
        public ComponentMod GetComponentMod( int id )
        {
            if ( !_componentModMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetComponentMod( id );
                item = new ComponentMod( serializable, this );
                _componentModMap.Add( id, item );
            }
            return item;
        }

        public ItemId<ComponentStats> GetComponentStatsId( int id ) { return new ItemId<ComponentStats>( _content.GetComponentStats( id ) ); }
        public ComponentStats GetComponentStats( int id )
        {
            if ( !_componentStatsMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetComponentStats( id );
                item = new ComponentStats( serializable, this );
                _componentStatsMap.Add( id, item );
            }
            return item;
        }

        public ItemId<Device> GetDeviceId( int id ) { return new ItemId<Device>( _content.GetDevice( id ) ); }
        public Device GetDevice( int id )
        {
            if ( !_deviceMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetDevice( id );
                item = new Device( serializable, this );
                _deviceMap.Add( id, item );
            }
            return item;
        }

        public ItemId<DroneBay> GetDroneBayId( int id ) { return new ItemId<DroneBay>( _content.GetDroneBay( id ) ); }
        public DroneBay GetDroneBay( int id )
        {
            if ( !_droneBayMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetDroneBay( id );
                item = new DroneBay( serializable, this );
                _droneBayMap.Add( id, item );
            }
            return item;
        }

        public ItemId<Faction> GetFactionId( int id ) { return new ItemId<Faction>( _content.GetFaction( id ) ); }
        public Faction GetFaction( int id )
        {
            if ( !_factionMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetFaction( id );
                item = new Faction( serializable, this );
                _factionMap.Add( id, item );
            }
            return item;
        }

        public ItemId<Satellite> GetSatelliteId( int id ) { return new ItemId<Satellite>( _content.GetSatellite( id ) ); }
        public Satellite GetSatellite( int id )
        {
            if ( !_satelliteMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetSatellite( id );
                item = new Satellite( serializable, this );
                _satelliteMap.Add( id, item );
            }
            return item;
        }

        public ItemId<SatelliteBuild> GetSatelliteBuildId( int id ) { return new ItemId<SatelliteBuild>( _content.GetSatelliteBuild( id ) ); }
        public SatelliteBuild GetSatelliteBuild( int id )
        {
            if ( !_satelliteBuildMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetSatelliteBuild( id );
                item = new SatelliteBuild( serializable, this );
                _satelliteBuildMap.Add( id, item );
            }
            return item;
        }

        public ItemId<Ship> GetShipId( int id ) { return new ItemId<Ship>( _content.GetShip( id ) ); }
        public Ship GetShip( int id )
        {
            if ( !_shipMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetShip( id );
                item = new Ship( serializable, this );
                _shipMap.Add( id, item );
            }
            return item;
        }

        public ItemId<ShipBuild> GetShipBuildId( int id ) { return new ItemId<ShipBuild>( _content.GetShipBuild( id ) ); }
        public ShipBuild GetShipBuild( int id )
        {
            if ( !_shipBuildMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetShipBuild( id );
                item = new ShipBuild( serializable, this );
                _shipBuildMap.Add( id, item );
            }
            return item;
        }

        public ItemId<Skill> GetSkillId( int id ) { return new ItemId<Skill>( _content.GetSkill( id ) ); }
        public Skill GetSkill( int id )
        {
            if ( !_skillMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetSkill( id );
                item = new Skill( serializable, this );
                _skillMap.Add( id, item );
            }
            return item;
        }

        public ItemId<Technology> GetTechnologyId( int id ) { return new ItemId<Technology>( _content.GetTechnology( id ) ); }
        public Technology GetTechnology( int id )
        {
            if ( !_technologyMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetTechnology( id );
                item = new Technology( serializable, this );
                _technologyMap.Add( id, item );
            }
            return item;
        }

        public ItemId<Character> GetCharacterId( int id ) { return new ItemId<Character>( _content.GetCharacter( id ) ); }
        public Character GetCharacter( int id )
        {
            if ( !_characterMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetCharacter( id );
                item = new Character( serializable, this );
                _characterMap.Add( id, item );
            }
            return item;
        }

        public ItemId<Fleet> GetFleetId( int id ) { return new ItemId<Fleet>( _content.GetFleet( id ) ); }
        public Fleet GetFleet( int id )
        {
            if ( !_fleetMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetFleet( id );
                item = new Fleet( serializable, this );
                _fleetMap.Add( id, item );
            }
            return item;
        }

        public ItemId<LootModel> GetLootId( int id ) { return new ItemId<LootModel>( _content.GetLoot( id ) ); }
        public LootModel GetLoot( int id )
        {
            if ( !_lootMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetLoot( id );
                item = new LootModel( serializable, this );
                _lootMap.Add( id, item );
            }
            return item;
        }

        public ItemId<QuestModel> GetQuestId( int id ) { return new ItemId<QuestModel>( _content.GetQuest( id ) ); }
        public QuestModel GetQuest( int id )
        {
            if ( !_questMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetQuest( id );
                item = new QuestModel( serializable, this );
                _questMap.Add( id, item );
            }
            return item;
        }

        public ItemId<QuestItem> GetQuestItemId( int id ) { return new ItemId<QuestItem>( _content.GetQuestItem( id ) ); }
        public QuestItem GetQuestItem( int id )
        {
            if ( !_questItemMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetQuestItem( id );
                item = new QuestItem( serializable, this );
                _questItemMap.Add( id, item );
            }
            return item;
        }

        public ItemId<Ammunition> GetAmmunitionId( int id ) { return new ItemId<Ammunition>( _content.GetAmmunition( id ) ); }
        public Ammunition GetAmmunition( int id )
        {
            if ( !_ammunitionMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetAmmunition( id );
                item = new Ammunition( serializable, this );
                _ammunitionMap.Add( id, item );
            }
            return item;
        }

        public ItemId<BulletPrefab> GetBulletPrefabId( int id ) { return new ItemId<BulletPrefab>( _content.GetBulletPrefab( id ) ); }
        public BulletPrefab GetBulletPrefab( int id )
        {
            if ( !_bulletPrefabMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetBulletPrefab( id );
                item = new BulletPrefab( serializable, this );
                _bulletPrefabMap.Add( id, item );
            }
            return item;
        }

        public ItemId<VisualEffect> GetVisualEffectId( int id ) { return new ItemId<VisualEffect>( _content.GetVisualEffect( id ) ); }
        public VisualEffect GetVisualEffect( int id )
        {
            if ( !_visualEffectMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetVisualEffect( id );
                item = new VisualEffect( serializable, this );
                _visualEffectMap.Add( id, item );
            }
            return item;
        }

        public ItemId<Weapon> GetWeaponId( int id ) { return new ItemId<Weapon>( _content.GetWeapon( id ) ); }
        public Weapon GetWeapon( int id )
        {
            if ( !_weaponMap.TryGetValue( id, out var item ) )
            {
                var serializable = _content.GetWeapon( id );
                item = new Weapon( serializable, this );
                _weaponMap.Add( id, item );
            }
            return item;
        }

        // Setters

        public void SetAmmunitionObsolete( int id, int old )
        {
            AmmunitionObsoleteSerializable serializable = _content.GetAmmunitionObsolete( id );
            _content.AmmunitionObsoleteList[_content.AmmunitionObsoleteList.IndexOf( _content.GetAmmunitionObsolete( old ) )] = serializable;
            _ammunitionObsoleteMap[old] = new AmmunitionObsolete( serializable, this );
        }

        public void SetComponent( int id, int old )
        {
            var serializable = _content.GetComponent( id );
            _content.ComponentList[_content.ComponentList.IndexOf( _content.GetComponent( old ) )] = serializable;
            _componentMap[old] = new Component( serializable, this );
        }

        public void SetComponentMod( int id, int old )
        {
            var serializable = _content.GetComponentMod( id );
            _content.ComponentModList[_content.ComponentModList.IndexOf( _content.GetComponentMod( old ) )] = serializable;
            _componentModMap[old] = new ComponentMod( serializable, this );
        }

        public void SetComponentStats( int id, int old )
        {
            var serializable = _content.GetComponentStats( id );
            _content.ComponentStatsList[_content.ComponentStatsList.IndexOf( _content.GetComponentStats( old ) )] = serializable;
            _componentStatsMap[old] = new ComponentStats( serializable, this );
        }

        public void SetDevice( int id, int old )
        {
            var serializable = _content.GetDevice( id );
            _content.DeviceList[_content.DeviceList.IndexOf( _content.GetDevice( old ) )] = serializable;
            _deviceMap[old] = new Device( serializable, this );
        }

        public void SetDroneBay( int id, int old )
        {
            var serializable = _content.GetDroneBay( id );
            _content.DroneBayList[_content.DroneBayList.IndexOf( _content.GetDroneBay( old ) )] = serializable;
            _droneBayMap[old] = new DroneBay( serializable, this );
        }

        public void SetFaction( int id, int old )
        {
            var serializable = _content.GetFaction( id );
            _content.FactionList[_content.FactionList.IndexOf( _content.GetFaction( old ) )] = serializable;
            _factionMap[old] = new Faction( serializable, this );
        }

        public void SetSatellite( int id, int old )
        {
            var serializable = _content.GetSatellite( id );
            _content.SatelliteList[_content.SatelliteList.IndexOf( _content.GetSatellite( old ) )] = serializable;
            _satelliteMap[old] = new Satellite( serializable, this );
        }

        public void SetSatelliteBuild( int id, int old )
        {
            var serializable = _content.GetSatelliteBuild( id );
            _content.SatelliteBuildList[_content.SatelliteBuildList.IndexOf( _content.GetSatelliteBuild( old ) )] = serializable;
            _satelliteBuildMap[old] = new SatelliteBuild( serializable, this );
        }

        public void SetBehaviorTree( int id, int old )
        {
            BehaviorTreeSerializable serializable = _content.GetBehaviorTree( id );
            _content.BehaviorTreeList[_content.BehaviorTreeList.IndexOf( _content.GetBehaviorTree( old ) )] = serializable;
            _behaviorTreeMap[old] = new BehaviorTreeModel( serializable, this );
        }

        public void SetShip( int id, int old )
        {
            var serializable = _content.GetShip( id );
            _content.ShipList[_content.ShipList.IndexOf( _content.GetShip( old ) )] = serializable;
            _shipMap[old] = new Ship( serializable, this );
        }

        public void SetShipBuild( int id, int old )
        {
            var serializable = _content.GetShipBuild( id );
            _content.ShipBuildList[_content.ShipBuildList.IndexOf( _content.GetShipBuild( old ) )] = serializable;
            _shipBuildMap[old] = new ShipBuild( serializable, this );
        }

        public void SetSkill( int id, int old )
        {
            var serializable = _content.GetSkill( id );
            _content.SkillList[_content.SkillList.IndexOf( _content.GetSkill( old ) )] = serializable;
            _skillMap[old] = new Skill( serializable, this );
        }

        public void SetTechnology( int id, int old )
        {
            var serializable = _content.GetTechnology( id );
            _content.TechnologyList[_content.TechnologyList.IndexOf( _content.GetTechnology( old ) )] = serializable;
            _technologyMap[old] = new Technology( serializable, this );
        }

        public void SetCharacter( int id, int old )
        {
            var serializable = _content.GetCharacter( id );
            _content.CharacterList[_content.CharacterList.IndexOf( _content.GetCharacter( old ) )] = serializable;
            _characterMap[old] = new Character( serializable, this );
        }

        public void SetCombatRules( int id, int old )
        {
            var serializable = _content.GetCombatRules( id );
            _content.CombatRulesList[_content.CombatRulesList.IndexOf( _content.GetCombatRules( old ) )] = serializable;
            _combatRulesMap[old] = new CombatRules( serializable, this );
        }

        public void SetGameObjectPrefab( int id, int old )
        {
            var serializable = _content.GetGameObjectPrefab( id );
            _content.GameObjectPrefabList[_content.GameObjectPrefabList.IndexOf( _content.GetGameObjectPrefab( old ) )] = serializable;
            _gameObjectPrefabMap[old] = new GameObjectPrefab( serializable, this );
        }

        public void SetFleet( int id, int old )
        {
            var serializable = _content.GetFleet( id );
            _content.FleetList[_content.FleetList.IndexOf( _content.GetFleet( old ) )] = serializable;
            _fleetMap[old] = new Fleet( serializable, this );
        }

        public void SetLoot( int id, int old )
        {
            var serializable = _content.GetLoot( id );
            _content.LootList[_content.LootList.IndexOf( _content.GetLoot( old ) )] = serializable;
            _lootMap[old] = new LootModel( serializable, this );
        }

        public void SetQuest( int id, int old )
        {
            var serializable = _content.GetQuest( id );
            _content.QuestList[_content.QuestList.IndexOf( _content.GetQuest( old ) )] = serializable;
            _questMap[old] = new QuestModel( serializable, this );
        }

        public void SetQuestItem( int id, int old )
        {
            var serializable = _content.GetQuestItem( id );
            _content.QuestItemList[_content.QuestItemList.IndexOf( _content.GetQuestItem( old ) )] = serializable;
            _questItemMap[old] = new QuestItem( serializable, this );
        }

        public void SetAmmunition( int id, int old )
        {
            var serializable = _content.GetAmmunition( id );
            _content.AmmunitionList[_content.AmmunitionList.IndexOf( _content.GetAmmunition( old ) )] = serializable;
            _ammunitionMap[old] = new Ammunition( serializable, this );
        }

        public void SetBulletPrefab( int id, int old )
        {
            var serializable = _content.GetBulletPrefab( id );
            _content.BulletPrefabList[_content.BulletPrefabList.IndexOf( _content.GetBulletPrefab( old ) )] = serializable;
            _bulletPrefabMap[old] = new BulletPrefab( serializable, this );
        }

        public void SetVisualEffect( int id, int old )
        {
            var serializable = _content.GetVisualEffect( id );
            _content.VisualEffectList[_content.VisualEffectList.IndexOf( _content.GetVisualEffect( old ) )] = serializable;
            _visualEffectMap[old] = new VisualEffect( serializable, this );
        }

        public void SetWeapon( int id, int old )
        {
            var serializable = _content.GetWeapon( id );
            _content.WeaponList[_content.WeaponList.IndexOf( _content.GetWeapon( old ) )] = serializable;
            _weaponMap[old] = new Weapon( serializable, this );
        }

        public void LoadJson( string name, string content )
        {
            _content.LoadJson( name, content );
        }

        public void RemoveJson( string name, string content )
        {
            _content.RemoveJson( name, content );
        }

        private void Clear()
        {
            _ammunitionObsoleteMap.Clear();
            _componentMap.Clear();
            _componentModMap.Clear();
            _componentStatsMap.Clear();
            _deviceMap.Clear();
            _droneBayMap.Clear();
            _factionMap.Clear();
            _satelliteMap.Clear();
            _satelliteBuildMap.Clear();
            _shipMap.Clear();
            _shipBuildMap.Clear();
            _skillMap.Clear();
            _technologyMap.Clear();
            _characterMap.Clear();
            _fleetMap.Clear();
            _lootMap.Clear();
            _questMap.Clear();
            _questItemMap.Clear();
            _ammunitionMap.Clear();
            _bulletPrefabMap.Clear();
            _visualEffectMap.Clear();
            _weaponMap.Clear();
            _combatRulesMap.Clear();
            _gameObjectPrefabMap.Clear();
            _behaviorTreeMap.Clear();

            _uiSettings = null;
            _debugSettings = null;
            _skillSettings = null;
            _specialEventSettings = null;
            _databaseSettings = null;
            _explorationSettings = null;
            _galaxySettings = null;
            _shipSettings = null;
            _frontierSettings = null;
            _shipModSettings = null;
        }

        private readonly Dictionary<int, CombatRules> _combatRulesMap = new Dictionary<int, CombatRules>();
        private readonly Dictionary<int, GameObjectPrefab> _gameObjectPrefabMap = new Dictionary<int, GameObjectPrefab>();
        private readonly Dictionary<int, BehaviorTreeModel> _behaviorTreeMap = new Dictionary<int, BehaviorTreeModel>();
        private readonly Dictionary<int, AmmunitionObsolete> _ammunitionObsoleteMap = new Dictionary<int, AmmunitionObsolete>();
        private readonly Dictionary<int, Component> _componentMap = new Dictionary<int, Component>();
        private readonly Dictionary<int, ComponentMod> _componentModMap = new Dictionary<int, ComponentMod>();
        private readonly Dictionary<int, ComponentStats> _componentStatsMap = new Dictionary<int, ComponentStats>();
        private readonly Dictionary<int, Device> _deviceMap = new Dictionary<int, Device>();
        private readonly Dictionary<int, DroneBay> _droneBayMap = new Dictionary<int, DroneBay>();
        private readonly Dictionary<int, Faction> _factionMap = new Dictionary<int, Faction>();
        private readonly Dictionary<int, Satellite> _satelliteMap = new Dictionary<int, Satellite>();
        private readonly Dictionary<int, SatelliteBuild> _satelliteBuildMap = new Dictionary<int, SatelliteBuild>();
        private readonly Dictionary<int, Ship> _shipMap = new Dictionary<int, Ship>();
        private readonly Dictionary<int, ShipBuild> _shipBuildMap = new Dictionary<int, ShipBuild>();
        private readonly Dictionary<int, Skill> _skillMap = new Dictionary<int, Skill>();
        private readonly Dictionary<int, Technology> _technologyMap = new Dictionary<int, Technology>();
        private readonly Dictionary<int, Character> _characterMap = new Dictionary<int, Character>();
        private readonly Dictionary<int, Fleet> _fleetMap = new Dictionary<int, Fleet>();
        private readonly Dictionary<int, LootModel> _lootMap = new Dictionary<int, LootModel>();
        private readonly Dictionary<int, QuestModel> _questMap = new Dictionary<int, QuestModel>();
        private readonly Dictionary<int, QuestItem> _questItemMap = new Dictionary<int, QuestItem>();
        private readonly Dictionary<int, Ammunition> _ammunitionMap = new Dictionary<int, Ammunition>();
        private readonly Dictionary<int, BulletPrefab> _bulletPrefabMap = new Dictionary<int, BulletPrefab>();
        private readonly Dictionary<int, VisualEffect> _visualEffectMap = new Dictionary<int, VisualEffect>();
        private readonly Dictionary<int, Weapon> _weaponMap = new Dictionary<int, Weapon>();
        public FrontierSettings FrontierSettings => _frontierSettings ?? ( _frontierSettings = new FrontierSettings( _content.FrontierSettings, this ) );
        private DatabaseSettings _databaseSettings;
        private ExplorationSettings _explorationSettings;
        private GalaxySettings _galaxySettings;
        private ShipSettings _shipSettings;
        private DebugSettings _debugSettings;
        private UiSettings _uiSettings;
        private SkillSettings _skillSettings;
        private FrontierSettings _frontierSettings;
        private ShipModSettings _shipModSettings;
        private CombatSettings _combatSettings;
        private SpecialEventSettings _specialEventSettings;
        private readonly IJsonSerializer _serializer;
        private readonly DatabaseContent _content;
    }
}

