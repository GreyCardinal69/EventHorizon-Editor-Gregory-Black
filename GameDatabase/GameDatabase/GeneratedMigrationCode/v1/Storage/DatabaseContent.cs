//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using DatabaseMigration.v1.Enums;
using DatabaseMigration.v1.Serializable;
using EditorDatabase.Model;
using EditorDatabase.Storage;
using System;
using System.Collections.Generic;
using System.IO;

namespace DatabaseMigration.v1.Storage
{
    public class DatabaseContent : IContentLoader
    {
        public DatabaseContent(IJsonSerializer jsonSerializer, IDataStorage storage)
        {
            _serializer = jsonSerializer;
            storage?.LoadContent(this);
        }

        public int VersionMajor
        {
            get => DatabaseSettings != null ? DatabaseSettings.DatabaseVersion : 1;
            set => CreateDatabaseSettings().DatabaseVersion = value;
        }

        public int VersionMinor
        {
            get => DatabaseSettings != null ? DatabaseSettings.DatabaseVersionMinor : 0;
            set => CreateDatabaseSettings().DatabaseVersionMinor = value;
        }

        public void LoadJson(string name, string content)
        {
            SerializableItem item = _serializer.FromJson<SerializableItem>(content);
            ItemType type = item.ItemType;

            // if exception like "unknown item type, check if an else is missing.
            if (type == ItemType.AmmunitionObsolete)
            {
                AmmunitionObsoleteSerializable data = _serializer.FromJson<AmmunitionObsoleteSerializable>(content);
                data.FileName = name;
                AmmunitionObsoleteList.Add(data);
            }
            else if (type == ItemType.ComponentStatUpgrade)
            {
                ComponentStatUpgradeSerializable data = _serializer.FromJson<ComponentStatUpgradeSerializable>(content);
                data.FileName = name;
                ComponentStatUpgradeList.Add(data);
            }
            else if (type == ItemType.StatUpgradeTemplate)
            {

                StatUpgradeTemplateSerializable data = _serializer.FromJson<StatUpgradeTemplateSerializable>(content);
                data.FileName = name;
                StatUpgradeTemplateList.Add(data);

            }
            else if (type == ItemType.WeaponSlots)
            {

                WeaponSlotsSerializable data = _serializer.FromJson<WeaponSlotsSerializable>(content);
                data.FileName = name;
                WeaponSlotsList.Add(data);

            }
            else if (type == ItemType.LocalizationSettings)
            {
                LocalizationSettingsSerializable data = _serializer.FromJson<LocalizationSettingsSerializable>(content);
                data.FileName = name;
                LocalizationSettings = data;
            }
            else if (type == ItemType.MusicPlaylist)
            {
                MusicPlaylistSerializable data = _serializer.FromJson<MusicPlaylistSerializable>(content);
                data.FileName = name;
                MusicPlaylist = data;
            }
            else if (item.ItemType == ItemType.Component)
            {
                ComponentSerializable data = _serializer.FromJson<ComponentSerializable>(content);
                data.FileName = name;
                ComponentList.Add(data);
            }
            else if (type == ItemType.ComponentMod)
            {
                ComponentModSerializable data = _serializer.FromJson<ComponentModSerializable>(content);
                data.FileName = name;
                ComponentModList.Add(data);
            }
            else if (type == ItemType.ComponentStats)
            {
                ComponentStatsSerializable data = _serializer.FromJson<ComponentStatsSerializable>(content);
                data.FileName = name;
                ComponentStatsList.Add(data);
            }
            else if (type == ItemType.Device)
            {
                DeviceSerializable data = _serializer.FromJson<DeviceSerializable>(content);
                data.FileName = name;
                DeviceList.Add(data);
            }
            else if (type == ItemType.GameObjectPrefab)
            {
                GameObjectPrefabSerializable data = _serializer.FromJson<GameObjectPrefabSerializable>(content);
                data.FileName = name;
                GameObjectPrefabList.Add(data);
            }
            if (type == ItemType.ComponentGroupTag)
            {
                ComponentGroupTagSerializable data = _serializer.FromJson<ComponentGroupTagSerializable>(content);
                data.FileName = name;
                ComponentGroupTagList.Add(data);
            }
            else if (type == ItemType.CombatRules)
            {
                CombatRulesSerializable data = _serializer.FromJson<CombatRulesSerializable>(content);
                data.FileName = name;
                CombatRulesList.Add(data);
            }
            else if (type == ItemType.UiSettings)
            {
                UiSettingsSerializable data = _serializer.FromJson<UiSettingsSerializable>(content);
                data.FileName = name;
                UiSettings = data;
            }
            else if (type == ItemType.BehaviorTree)
            {
                BehaviorTreeSerializable data = _serializer.FromJson<BehaviorTreeSerializable>(content);
                data.FileName = name;
                BehaviorTreeList.Add(data);
            }
            else if (type == ItemType.CombatSettings)
            {
                CombatSettingsSerializable data = _serializer.FromJson<CombatSettingsSerializable>(content);
                data.FileName = name;
                CombatSettings = data;
            }
            else if (type == ItemType.DroneBay)
            {
                DroneBaySerializable data = _serializer.FromJson<DroneBaySerializable>(content);
                data.FileName = name;
                DroneBayList.Add(data);
            }
            else if (type == ItemType.Faction)
            {
                FactionSerializable data = _serializer.FromJson<FactionSerializable>(content);
                data.FileName = name;
                FactionList.Add(data);
            }
            else if (type == ItemType.Satellite)
            {
                SatelliteSerializable data = _serializer.FromJson<SatelliteSerializable>(content);
                data.FileName = name;
                SatelliteList.Add(data);
            }
            else if (type == ItemType.SatelliteBuild)
            {
                SatelliteBuildSerializable data = _serializer.FromJson<SatelliteBuildSerializable>(content);
                data.FileName = name;
                SatelliteBuildList.Add(data);
            }
            else if (type == ItemType.Ship)
            {
                ShipSerializable data = _serializer.FromJson<ShipSerializable>(content);
                data.FileName = name;
                ShipList.Add(data);
            }
            else if (type == ItemType.ShipBuild)
            {
                ShipBuildSerializable data = _serializer.FromJson<ShipBuildSerializable>(content);
                data.FileName = name;
                ShipBuildList.Add(data);
            }
            else if (type == ItemType.Technology)
            {
                TechnologySerializable data = _serializer.FromJson<TechnologySerializable>(content);
                data.FileName = name;
                TechnologyList.Add(data);
            }
            else if (type == ItemType.Character)
            {
                CharacterSerializable data = _serializer.FromJson<CharacterSerializable>(content);
                data.FileName = name;
                CharacterList.Add(data);
            }
            else if (type == ItemType.Fleet)
            {
                FleetSerializable data = _serializer.FromJson<FleetSerializable>(content);
                data.FileName = name;
                FleetList.Add(data);
            }
            else if (type == ItemType.Loot)
            {
                LootSerializable data = _serializer.FromJson<LootSerializable>(content);
                data.FileName = name;
                LootList.Add(data);
            }
            else if (type == ItemType.Quest)
            {
                QuestSerializable data = _serializer.FromJson<QuestSerializable>(content);
                data.FileName = name;
                QuestList.Add(data);
            }
            else if (type == ItemType.QuestItem)
            {
                QuestItemSerializable data = _serializer.FromJson<QuestItemSerializable>(content);
                data.FileName = name;
                QuestItemList.Add(data);
            }
            else if (type == ItemType.Ammunition)
            {
                AmmunitionSerializable data = _serializer.FromJson<AmmunitionSerializable>(content);
                data.FileName = name;
                AmmunitionList.Add(data);
            }
            else if (type == ItemType.BulletPrefab)
            {
                BulletPrefabSerializable data = _serializer.FromJson<BulletPrefabSerializable>(content);
                data.FileName = name;
                BulletPrefabList.Add(data);
            }
            else if (type == ItemType.FactionsSettings)
            {
                FactionsSettingsSerializable data = _serializer.FromJson<FactionsSettingsSerializable>(content);
                data.FileName = name;
                FactionsSettings = data;
            }
            else if (type == ItemType.VisualEffect)
            {
                VisualEffectSerializable data = _serializer.FromJson<VisualEffectSerializable>(content);
                data.FileName = name;
                VisualEffectList.Add(data);
            }
            else if (type == ItemType.Weapon)
            {
                WeaponSerializable data = _serializer.FromJson<WeaponSerializable>(content);
                data.FileName = name;
                WeaponList.Add(data);
            }
            else if (type == ItemType.DatabaseSettings)
            {
                DatabaseSettingsSerializable data = _serializer.FromJson<DatabaseSettingsSerializable>(content);
                data.FileName = name;
                DatabaseSettings = data;
            }
            else if (type == ItemType.DebugSettings)
            {
                DebugSettingsSerializable data = _serializer.FromJson<DebugSettingsSerializable>(content);
                data.FileName = name;
                DebugSettings = data;
            }
            else if (type == ItemType.ExplorationSettings)
            {
                ExplorationSettingsSerializable data = _serializer.FromJson<ExplorationSettingsSerializable>(content);
                data.FileName = name;
                ExplorationSettings = data;
            }
            else if (type == ItemType.FrontierSettings)
            {
                FrontierSettingsSerializable data = _serializer.FromJson<FrontierSettingsSerializable>(content);
                data.FileName = name;
                FrontierSettings = data;
            }
            else if (type == ItemType.GalaxySettings)
            {
                GalaxySettingsSerializable data = _serializer.FromJson<GalaxySettingsSerializable>(content);
                data.FileName = name;
                GalaxySettings = data;
            }
            else if (type == ItemType.ShipModSettings)
            {
                ShipModSettingsSerializable data = _serializer.FromJson<ShipModSettingsSerializable>(content);
                data.FileName = name;
                ShipModSettings = data;
            }
            else if (type == ItemType.ShipSettings)
            {
                ShipSettingsSerializable data = _serializer.FromJson<ShipSettingsSerializable>(content);
                data.FileName = name;
                ShipSettings = data;
            }
            else if (type == ItemType.SkillSettings)
            {
                SkillSettingsSerializable data = _serializer.FromJson<SkillSettingsSerializable>(content);
                data.FileName = name;
                SkillSettings = data;
            }
            else if (type == ItemType.SpecialEventSettings)
            {
                SpecialEventSettingsSerializable data = _serializer.FromJson<SpecialEventSettingsSerializable>(content);
                data.FileName = name;
                SpecialEventSettings = data;
            }
        }

        public void Export(IContentLoader contentLoader)
        {
            foreach (ComponentGroupTagSerializable item in this.ComponentGroupTagList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (ComponentStatUpgradeSerializable item in ComponentStatUpgradeList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (CombatRulesSerializable item in CombatRulesList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (GameObjectPrefabSerializable item in GameObjectPrefabList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (AmmunitionObsoleteSerializable item in AmmunitionObsoleteList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (ComponentSerializable item in ComponentList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (ComponentModSerializable item in ComponentModList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (ComponentStatsSerializable item in ComponentStatsList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (DeviceSerializable item in DeviceList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (DroneBaySerializable item in DroneBayList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (FactionSerializable item in FactionList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (SatelliteSerializable item in SatelliteList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (SatelliteBuildSerializable item in SatelliteBuildList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (ShipSerializable item in ShipList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (ShipBuildSerializable item in ShipBuildList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (WeaponSlotsSerializable item in WeaponSlotsList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (StatUpgradeTemplateSerializable item in StatUpgradeTemplateList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (BehaviorTreeSerializable item in BehaviorTreeList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (TechnologySerializable item in TechnologyList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (CharacterSerializable item in CharacterList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (FleetSerializable item in FleetList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (LootSerializable item in LootList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (QuestSerializable item in QuestList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (QuestItemSerializable item in QuestItemList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (AmmunitionSerializable item in AmmunitionList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (BulletPrefabSerializable item in BulletPrefabList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (VisualEffectSerializable item in VisualEffectList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (WeaponSerializable item in WeaponList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            foreach (WeaponSlotsSerializable item in WeaponSlotsList)
                contentLoader.LoadJson(item.FileName, _serializer.ToJson(item));
            if (LocalizationSettings != null)
                contentLoader.LoadJson(LocalizationSettings.FileName, _serializer.ToJson(LocalizationSettings));
            if (MusicPlaylist != null)
                contentLoader.LoadJson(MusicPlaylist.FileName, _serializer.ToJson(MusicPlaylist));
            if (DatabaseSettings != null)
                contentLoader.LoadJson(DatabaseSettings.FileName, _serializer.ToJson(DatabaseSettings));
            if (DebugSettings != null)
                contentLoader.LoadJson(DebugSettings.FileName, _serializer.ToJson(DebugSettings));
            if (ExplorationSettings != null)
                contentLoader.LoadJson(ExplorationSettings.FileName, _serializer.ToJson(ExplorationSettings));
            if (FrontierSettings != null)
                contentLoader.LoadJson(FrontierSettings.FileName, _serializer.ToJson(FrontierSettings));
            if (GalaxySettings != null)
                contentLoader.LoadJson(GalaxySettings.FileName, _serializer.ToJson(GalaxySettings));
            if (ShipModSettings != null)
                contentLoader.LoadJson(ShipModSettings.FileName, _serializer.ToJson(ShipModSettings));
            if (ShipSettings != null)
                contentLoader.LoadJson(ShipSettings.FileName, _serializer.ToJson(ShipSettings));
            if (SkillSettings != null)
                contentLoader.LoadJson(SkillSettings.FileName, _serializer.ToJson(SkillSettings));
            if (SpecialEventSettings != null)
                contentLoader.LoadJson(SpecialEventSettings.FileName, _serializer.ToJson(SpecialEventSettings));
            if (CombatSettings != null)
                contentLoader.LoadJson(CombatSettings.FileName, _serializer.ToJson(CombatSettings));
            if (UiSettings != null)
                contentLoader.LoadJson(UiSettings.FileName, _serializer.ToJson(UiSettings));
            if (FactionsSettings != null)
                contentLoader.LoadJson(FactionsSettings.FileName, _serializer.ToJson(FactionsSettings));
            foreach (KeyValuePair<string, IImageData> item in _images)
                contentLoader.LoadImage(item.Key, item.Value);
            foreach (KeyValuePair<string, IAudioClipData> item in _audioClips)
                contentLoader.LoadAudioClip(item.Key, item.Value);
            foreach (KeyValuePair<string, string> item in _localizations)
                contentLoader.LoadLocalization(item.Key, item.Value);
        }

        public void LoadLocalization(string name, string data)
        {
            _localizations.Add(name, data);
        }

        public void LoadImage(string name, IImageData image)
        {
            _images.Add(Path.GetFileName(name), image);
        }

        public void LoadAudioClip(string name, IAudioClipData audioClip)
        {
            _audioClips.Add(name, audioClip);
        }

        public LocalizationSettingsSerializable LocalizationSettings { get; private set; }
        public MusicPlaylistSerializable MusicPlaylist { get; private set; }
        public FactionsSettingsSerializable FactionsSettings { get; private set; }
        public UiSettingsSerializable UiSettings { get; private set; }
        public CombatSettingsSerializable CombatSettings { get; private set; }
        public DatabaseSettingsSerializable DatabaseSettings { get; private set; }
        public DebugSettingsSerializable DebugSettings { get; private set; }
        public ExplorationSettingsSerializable ExplorationSettings { get; private set; }
        public FrontierSettingsSerializable FrontierSettings { get; private set; }
        public GalaxySettingsSerializable GalaxySettings { get; private set; }
        public ShipModSettingsSerializable ShipModSettings { get; private set; }
        public ShipSettingsSerializable ShipSettings { get; private set; }
        public SkillSettingsSerializable SkillSettings { get; private set; }
        public SpecialEventSettingsSerializable SpecialEventSettings { get; private set; }

        public LocalizationSettingsSerializable CreateLocalizationSettings() => LocalizationSettings ?? (LocalizationSettings = new LocalizationSettingsSerializable());
        public MusicPlaylistSerializable CreateMusicPlaylist() => MusicPlaylist ?? (MusicPlaylist = new MusicPlaylistSerializable());
        public FactionsSettingsSerializable CreateFactionsSettings() => FactionsSettings ?? (FactionsSettings = new FactionsSettingsSerializable());
        public UiSettingsSerializable CreateUiSettings() => UiSettings ?? (UiSettings = new UiSettingsSerializable());
        public CombatSettingsSerializable CreateCombatSettings() => CombatSettings ?? (CombatSettings = new CombatSettingsSerializable());
        public DatabaseSettingsSerializable CreateDatabaseSettings() => DatabaseSettings ?? (DatabaseSettings = new DatabaseSettingsSerializable());
        public DebugSettingsSerializable CreateDebugSettings() => DebugSettings ?? (DebugSettings = new DebugSettingsSerializable());
        public ExplorationSettingsSerializable CreateExplorationSettings() => ExplorationSettings ?? (ExplorationSettings = new ExplorationSettingsSerializable());
        public FrontierSettingsSerializable CreateFrontierSettings() => FrontierSettings ?? (FrontierSettings = new FrontierSettingsSerializable());
        public GalaxySettingsSerializable CreateGalaxySettings() => GalaxySettings ?? (GalaxySettings = new GalaxySettingsSerializable());
        public ShipModSettingsSerializable CreateShipModSettings() => ShipModSettings ?? (ShipModSettings = new ShipModSettingsSerializable());
        public ShipSettingsSerializable CreateShipSettings() => ShipSettings ?? (ShipSettings = new ShipSettingsSerializable());
        public SkillSettingsSerializable CreateSkillSettings() => SkillSettings ?? (SkillSettings = new SkillSettingsSerializable());
        public SpecialEventSettingsSerializable CreateSpecialEventSettings() => SpecialEventSettings ?? (SpecialEventSettings = new SpecialEventSettingsSerializable());
        public List<BehaviorTreeSerializable> BehaviorTreeList { get; } = new List<BehaviorTreeSerializable>();
        public List<AmmunitionObsoleteSerializable> AmmunitionObsoleteList { get; } = new List<AmmunitionObsoleteSerializable>();
        public List<WeaponSlotsSerializable> WeaponSlotsList { get; } = new List<WeaponSlotsSerializable>();
        public List<ComponentSerializable> ComponentList { get; } = new List<ComponentSerializable>();
        public List<GameObjectPrefabSerializable> GameObjectPrefabList { get; } = new List<GameObjectPrefabSerializable>();
        public List<CombatRulesSerializable> CombatRulesList { get; } = new List<CombatRulesSerializable>();
        public List<ComponentModSerializable> ComponentModList { get; } = new List<ComponentModSerializable>();
        public List<ComponentStatsSerializable> ComponentStatsList { get; } = new List<ComponentStatsSerializable>();
        public List<DeviceSerializable> DeviceList { get; } = new List<DeviceSerializable>();
        public List<DroneBaySerializable> DroneBayList { get; } = new List<DroneBaySerializable>();
        public List<FactionSerializable> FactionList { get; } = new List<FactionSerializable>();
        public List<SatelliteSerializable> SatelliteList { get; } = new List<SatelliteSerializable>();
        public List<SatelliteBuildSerializable> SatelliteBuildList { get; } = new List<SatelliteBuildSerializable>();
        public List<ShipSerializable> ShipList { get; } = new List<ShipSerializable>();
        public List<ShipBuildSerializable> ShipBuildList { get; } = new List<ShipBuildSerializable>();
        public List<ComponentStatUpgradeSerializable> ComponentStatUpgradeList { get; } = new List<ComponentStatUpgradeSerializable>();
        public List<StatUpgradeTemplateSerializable> StatUpgradeTemplateList { get; } = new List<StatUpgradeTemplateSerializable>();
        public List<TechnologySerializable> TechnologyList { get; } = new List<TechnologySerializable>();
        public List<CharacterSerializable> CharacterList { get; } = new List<CharacterSerializable>();
        public List<FleetSerializable> FleetList { get; } = new List<FleetSerializable>();
        public List<LootSerializable> LootList { get; } = new List<LootSerializable>();
        public List<QuestSerializable> QuestList { get; } = new List<QuestSerializable>();
        public List<QuestItemSerializable> QuestItemList { get; } = new List<QuestItemSerializable>();
        public List<AmmunitionSerializable> AmmunitionList { get; } = new List<AmmunitionSerializable>();
        public List<BulletPrefabSerializable> BulletPrefabList { get; } = new List<BulletPrefabSerializable>();
        public List<VisualEffectSerializable> VisualEffectList { get; } = new List<VisualEffectSerializable>();
        public List<WeaponSerializable> WeaponList { get; } = new List<WeaponSerializable>();
        public List<ComponentGroupTagSerializable> ComponentGroupTagList { get; } = new List<ComponentGroupTagSerializable>();
        public IEnumerable<KeyValuePair<string, IImageData>> Images => _images;
        public IEnumerable<KeyValuePair<string, IAudioClipData>> AudioClips => _audioClips;
        public IEnumerable<KeyValuePair<string, string>> Localizations => _localizations;

        private readonly IJsonSerializer _serializer;

        private readonly Dictionary<string, IImageData> _images = new Dictionary<string, IImageData>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, IAudioClipData> _audioClips = new Dictionary<string, IAudioClipData>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, string> _localizations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
}
