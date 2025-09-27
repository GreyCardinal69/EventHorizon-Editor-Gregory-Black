using EditorDatabase.Serializable;
using EditorDatabase.Storage;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EditorDatabase
{
    public class DatabaseReformat
    {
        private readonly Dictionary<string, string> _localization;
        private DatabaseContent _content;
        private string _path;
        private DatabaseStorage _storage;

        public DatabaseReformat()
        {
            _localization = new Dictionary<string, string>();
        }

        public void Run()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() != CommonFileDialogResult.Ok) return;
            _path = dialog.FileName;
            _storage = new DatabaseStorage(_path);
            _content = new DatabaseContent(new JsonSerializer(), _storage);

            foreach (KeyValuePair<string, string> keyValuePair in _content.Localizations)
                if (keyValuePair.Key.ToLower().EndsWith("english"))
                    LoadLocal(keyValuePair.Value);
            LoadLocal(GetVanillaLocal());

            ProcessShips();
            ProcessFactions();
            ProcessComponents();
            ProcessTech();
            ProcessSatelites();

            MessageBox.Show("Processing database finished, select output directory.");
            if (dialog.ShowDialog() != CommonFileDialogResult.Ok) return;
            DuplicateSaveStorage writeStorage = new DuplicateSaveStorage(dialog.FileName);
            _content.Save(writeStorage, new JsonSerializer());
        }

        private void ProcessShips()
        {
            foreach (ShipSerializable ship in _content.ShipList)
                ship.FileName = Path.Combine("Ships", FactionName(ship.Faction), NameFor(ship, false) + ".json");

            foreach (ShipBuildSerializable shipBuild in _content.ShipBuildList)
            {
                FactionSerializable fac = _content.GetFaction(shipBuild.BuildFaction);
                string facName;
                if (fac != null)
                    facName = FactionName(fac.Id);
                else
                    facName = FactionName(_content.GetShip(shipBuild.ShipId).Faction);
                shipBuild.FileName = Path.Combine("Ships", facName, "builds", NameFor(shipBuild, false) + ".json");
            }
        }

        private void ProcessFactions()
        {
            foreach (FactionSerializable faction in _content.FactionList)
                faction.FileName = Path.Combine("Factions", NameFor(faction, false) + ".json");
        }

        private void ProcessComponents()
        {
            Dictionary<int, ComponentSerializable> statsMappings = new Dictionary<int, ComponentSerializable>();
            Dictionary<int, ComponentSerializable> devicesMappings = new Dictionary<int, ComponentSerializable>();
            Dictionary<int, ComponentSerializable> weaponsMappings = new Dictionary<int, ComponentSerializable>();
            Dictionary<int, ComponentSerializable> ammoMappings = new Dictionary<int, ComponentSerializable>();
            Dictionary<int, ComponentSerializable> droneBaysMappings = new Dictionary<int, ComponentSerializable>();
            //var dronesMappings = new Dictionary<int, ComponentSerializable>();
            Dictionary<int, string> ogAmmoNames = new Dictionary<int, string>();

            foreach (ComponentSerializable component in _content.ComponentList)
            {
                ProcessDictionary(component.ComponentStatsId, statsMappings, component);
                ProcessDictionary(component.DeviceId, devicesMappings, component);
                ProcessDictionary(component.WeaponId, weaponsMappings, component);
                ProcessDictionary(component.AmmunitionId, ammoMappings, component);
                ProcessDictionary(component.DroneBayId, droneBaysMappings, component);
                //ProcessDictionary(component.DroneId,dronesMappings,component);

                component.FileName = componentfolder(component, "component") + ".json";
            }
            processComponentRelated(statsMappings, _content.ComponentStatsList, "stats");
            processComponentRelated(devicesMappings, _content.DeviceList, "device");
            processComponentRelated(weaponsMappings, _content.WeaponList, "weapon");
            processComponentRelated(droneBaysMappings, _content.DroneBayList, "droneBay");

            HashSet<AmmunitionObsoleteSerializable> processed = new HashSet<AmmunitionObsoleteSerializable>();

            foreach (int id in ammoMappings.Keys)
            {
                ComponentSerializable comp = ammoMappings[id];
                AmmunitionObsoleteSerializable ammo = _content.GetAmmunitionObsolete(id);
                if (ammo == null) continue;
                string secondarybase = "";
                if (comp != null)
                {
                    secondarybase = componentfolder(comp, "ammoObsolete");
                }
                else
                {
                    secondarybase = Path.Combine("Ammunition", "Obsolete", NameFor(ammo, false));
                }
                ammo.FileName = secondarybase + ".json";
                AmmunitionObsoleteSerializable cur = ammo;
                int i = 0;
                do
                {
                    if (processed.Contains(cur))
                    {
                        cur.FileName = Path.Combine("Ammunition", "Obsolete", ogAmmoNames[cur.Id]);
                        break;
                    }
                    else
                    {
                        processed.Add(cur);
                        ogAmmoNames[cur.Id] = NameFor(cur, false);
                        if (i++ > 0) cur.FileName = secondarybase + "_" + i + ".json";
                    }
                    cur = _content.GetAmmunitionObsolete(cur.CoupledAmmunitionId);
                } while (cur != null);
            }
            foreach (AmmunitionObsoleteSerializable ammo in _content.AmmunitionObsoleteList)
            {
                if (processed.Contains(ammo)) continue;
                ammo.FileName = Path.Combine("Ammunition", "Obsolete", "unused", NameFor(ammo, false) + ".json");
            }

            foreach (ComponentModSerializable mod in _content.ComponentModList)
            {
                mod.FileName = Path.Combine("Components", "Modifications", NameFor(mod, false) + ".json");
            }

            ProcessAmmunition(ammoMappings);
        }

        private void ProcessAmmunition(Dictionary<int, ComponentSerializable> mappings)
        {
            HashSet<AmmunitionSerializable> processed = new HashSet<AmmunitionSerializable>();
            Dictionary<int, string> ogNames = new Dictionary<int, string>();

            foreach (int id in mappings.Keys)
            {
                AmmunitionSerializable ammo = _content.GetAmmunition(id);
                if (ammo == null) continue;
                ComponentSerializable comp = mappings[ammo.Id];
                string secondarybase = "";
                if (comp != null)
                {
                    secondarybase = componentfolder(comp, "ammo");
                }
                else
                {
                    secondarybase = Path.Combine("Ammunition", NameFor(ammo, false));
                }
                Queue<AmmunitionSerializable> queue = new Queue<AmmunitionSerializable>();
                HashSet<AmmunitionSerializable> loop = new HashSet<AmmunitionSerializable>();
                ammo.FileName = secondarybase + ".json";
                int i = 0;
                queue.Enqueue(ammo);
                loop.Add(ammo);

                while (queue.Count > 0)
                {
                    AmmunitionSerializable cur = queue.Dequeue();
                    if (cur.Triggers != null)
                    {
                        foreach (BulletTriggerSerializable trigger in cur.Triggers)
                        {
                            AmmunitionSerializable _ammo = _content.GetAmmunition(trigger.Ammunition);
                            if (_ammo != null && !loop.Contains(_ammo))
                            {
                                queue.Enqueue(_ammo);
                                loop.Add(_ammo);
                            }
                        }
                    }
                    if (processed.Contains(cur))
                    {
                        cur.FileName = Path.Combine("Ammunition", ogNames[cur.Id]);
                    }
                    else
                    {
                        processed.Add(cur);
                        ogNames[cur.Id] = NameFor(cur, false);
                        if (i++ > 0) cur.FileName = secondarybase + "_" + i + ".json";
                    }
                }
            }

            foreach (AmmunitionSerializable ammo in _content.AmmunitionList)
            {
                if (processed.Contains(ammo)) continue;
                ammo.FileName = Path.Combine("Ammunition", "unused", NameFor(ammo, false) + ".json");
            }
        }

        private void ProcessTech()
        {
            foreach (TechnologySerializable tech in _content.TechnologyList)
            {
                int fac = tech.Faction;
                string type = tech.Type.ToString();
                string relatedItemName = "";

                switch (tech.Type)
                {
                    case Enums.TechType.Component:
                        ComponentSerializable comp = _content.GetComponent(tech.ItemId);
                        relatedItemName = NameFor(comp, comp.DisplayCategory != Enums.ComponentCategory.Weapon);
                        break;
                    case Enums.TechType.Ship:
                        ShipSerializable ship = _content.GetShip(tech.ItemId);
                        relatedItemName = NameFor(ship, false);
                        fac = ship.Faction;
                        break;
                    case Enums.TechType.Satellite:
                        relatedItemName = NameFor(_content.GetSatellite(tech.ItemId), false);
                        break;
                }

                tech.FileName = Path.Combine("Technology", FactionName(fac), relatedItemName + ".json");
            }
        }
        private void ProcessSatelites()
        {
            foreach (SatelliteSerializable satelite in _content.SatelliteList)
                satelite.FileName = Path.Combine("Satelites", NameFor(satelite, false) + ".json");

            foreach (SatelliteBuildSerializable sateliteBuild in _content.SatelliteBuildList)
            {
                sateliteBuild.FileName = Path.Combine("Satelites", "builds", NameFor(sateliteBuild, false) + ".json");
            }
        }

        private void processComponentRelated(Dictionary<int, ComponentSerializable> mappings, IEnumerable<SerializableItem> list, string type)
        {

            foreach (SerializableItem item in list)
            {
                if (mappings.ContainsKey(item.Id))
                {
                    ComponentSerializable comp = mappings[item.Id];
                    if (comp != null)
                    {
                        item.FileName = componentfolder(comp, type) + ".json";
                    }
                    else
                    {
                        item.FileName = Path.Combine("Components", "SharedData", type, NameFor(item, false) + ".json");
                    }
                }
                else
                {
                    item.FileName = Path.Combine("Components", "SharedData", type, "unused", NameFor(item, false) + ".json");
                }
            }
        }

        private string componentfolder(ComponentSerializable component, string fileEnding)
        {
            if (component.DisplayCategory == Enums.ComponentCategory.Weapon)
            {
                string type = "";
                char ct = (component.WeaponSlotType + "_")[0];
                switch (ct)
                {
                    case 'C':
                        type = "Cannon";
                        break;
                    case 'L':
                        type = "Laser";
                        break;
                    case 'M':
                        type = "Missile";
                        break;
                    case 'S':
                        type = "Special";
                        break;
                    case 'T':
                        type = "Torpedo";
                        break;
                    case '_':
                        type = "Misc";
                        break;
                    default:
                        type = "Slot type " + ct;
                        break;
                }
                return Path.Combine("Components", component.DisplayCategory.ToString(), type, NameFor(component, false), NameFor(component, false) + "_" + fileEnding);
            }
            else
            {
                return Path.Combine("Components", component.DisplayCategory.ToString(), NameFor(component, true), NameFor(component, true) + "_" + fileEnding);
            }
        }

        private void ProcessDictionary(int value, Dictionary<int, ComponentSerializable> dictionary, ComponentSerializable component)
        {
            if (dictionary.ContainsKey(value))
            {
                dictionary[value] = null;
            }
            else
            {
                dictionary[value] = component;
            }
        }

        private string FactionName(int id)
        {
            string facName = NameFor(_content.GetFaction(id), false);
            if (string.IsNullOrEmpty(facName)) facName = "Neutral";
            return facName.Trim();
        }

        private static readonly Regex smallRegex = new Regex("^small\\s*", RegexOptions.IgnoreCase);
        private static readonly Regex largeRegex = new Regex("^(?:large|heavy)\\s*", RegexOptions.IgnoreCase);
        private static readonly Regex mediumRegex = new Regex("^medium\\s*", RegexOptions.IgnoreCase);
        private string NameFor(SerializableItem item, bool replaceSizeMod)
        {
            string name = Regex.Replace(NameForRaw(item), "['\"/\\+?]", "");
            if (replaceSizeMod)
            {
                if (smallRegex.IsMatch(name))
                {
                    name = smallRegex.Replace(name, "");
                    name += " S";
                }
                if (mediumRegex.IsMatch(name))
                {
                    name = mediumRegex.Replace(name, "");
                    name += " M";
                }
                if (largeRegex.IsMatch(name))
                {
                    name = largeRegex.Replace(name, "");
                    name += " L";
                }
            }
            return name.Trim();
        }
        private string NameForRaw(SerializableItem item)
        {
            if (item == null) return string.Empty;

            switch (item)
            {
                case ComponentSerializable comp:
                    return LocalizationOrName(comp.Name);
                case ShipSerializable ship:
                    return LocalizationOrName(ship.Name);
                case FactionSerializable faction:
                    return LocalizationOrName(faction.Name);
                case CharacterSerializable character:
                    return LocalizationOrName(character.Name);
                case QuestSerializable quest:
                    return LocalizationOrName(quest.Name);
                case SatelliteSerializable satellite:
                    return LocalizationOrName(satellite.Name);
                case QuestItemSerializable questItem:
                    return LocalizationOrName(questItem.Name);
                case ComponentModSerializable componentMod:
                    return componentMod.Description.ToString();
                case ShipBuildSerializable shipBuild:
                    string name = NameFor(_content.GetShip(shipBuild.ShipId), false);
                    if (shipBuild.DifficultyClass > 0) name += "_" + new string('x', (int)shipBuild.DifficultyClass);
                    return name;
                case SatelliteBuildSerializable satelliteBuild:
                    name = NameFor(_content.GetSatellite(satelliteBuild.SatelliteId), false);
                    if (satelliteBuild.DifficultyClass > 0) name += "_" + new string('x', (int)satelliteBuild.DifficultyClass);
                    return name;
                default:
                    return Path.GetFileNameWithoutExtension(item.FileName);
            }
        }

        private string LocalizationOrName(string name)
        {
            if (name == null) return "null";
            if (_localization.ContainsKey(name)) return _localization[name];

            return name;
        }

        private void LoadLocal(string data)
        {
            XElement xml = XElement.Parse(data);
            foreach (XElement entry in xml.Elements())
            {
                if (entry.Name != "string") return;
                XAttribute name = entry.Attribute("name");
                if (name == null) return;
                _localization["$" + name.Value] = entry.Value;
            }
        }

        public string GetVanillaLocal()
        {
            string result = string.Empty;
            using (Stream stream = GetType().Assembly
                .GetManifestResourceStream("GameDatabase.GameDatabase.Utilites.VanillaLocal.xml"))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }
    }
}