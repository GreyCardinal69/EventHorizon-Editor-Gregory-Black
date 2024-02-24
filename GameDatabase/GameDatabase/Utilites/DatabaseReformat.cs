using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using EditorDatabase.Serializable;
using EditorDatabase.Storage;
using Microsoft.WindowsAPICodePack.Dialogs;

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
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() != CommonFileDialogResult.Ok) return;
            _path = dialog.FileName;
            _storage = new DatabaseStorage(_path);
            _content = new DatabaseContent( new JsonSerializer(),_storage );

            foreach (var keyValuePair in _content.Localizations)
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
            var writeStorage = new DuplicateSaveStorage(dialog.FileName);
            _content.Save(writeStorage, new JsonSerializer());
        }

        private void ProcessShips()
        {
            foreach (var ship in _content.ShipList)
                ship.FileName = Path.Combine("Ships", FactionName(ship.Faction), NameFor(ship,false) + ".json");

            foreach (var shipBuild in _content.ShipBuildList)
            {
                var fac = _content.GetFaction(shipBuild.BuildFaction);
                string facName;
                if (fac != null)
                    facName = FactionName(fac.Id);
                else
                    facName = FactionName(_content.GetShip(shipBuild.ShipId).Faction);
                shipBuild.FileName = Path.Combine("Ships", facName, "builds", NameFor(shipBuild,false)+".json");
            }
        }

        private void ProcessFactions()
        {
            foreach (var faction in _content.FactionList)
                faction.FileName = Path.Combine("Factions", NameFor(faction,false) + ".json");
        }

        private void ProcessComponents()
        {
            var statsMappings = new Dictionary<int, ComponentSerializable>();
            var devicesMappings = new Dictionary<int, ComponentSerializable>();
            var weaponsMappings = new Dictionary<int, ComponentSerializable>();
            var ammoMappings = new Dictionary<int, ComponentSerializable>();
            var droneBaysMappings = new Dictionary<int, ComponentSerializable>();
            //var dronesMappings = new Dictionary<int, ComponentSerializable>();
            var ogAmmoNames = new Dictionary<int, string>();

            foreach (var component in _content.ComponentList)
            {
                ProcessDictionary(component.ComponentStatsId,statsMappings,component);
                ProcessDictionary(component.DeviceId,devicesMappings,component);
                ProcessDictionary(component.WeaponId,weaponsMappings,component);
                ProcessDictionary(component.AmmunitionId,ammoMappings,component);
                ProcessDictionary(component.DroneBayId,droneBaysMappings,component);
                //ProcessDictionary(component.DroneId,dronesMappings,component);

                component.FileName = componentfolder(component, "component")+".json";
            }
            processComponentRelated(statsMappings, _content.ComponentStatsList, "stats");
            processComponentRelated(devicesMappings, _content.DeviceList, "device");
            processComponentRelated(weaponsMappings, _content.WeaponList, "weapon");
            processComponentRelated(droneBaysMappings, _content.DroneBayList, "droneBay");

            var processed = new HashSet<AmmunitionObsoleteSerializable>();

            foreach (var id in ammoMappings.Keys)
            {
                var comp = ammoMappings[id];
                var ammo = _content.GetAmmunitionObsolete(id);
                if (ammo == null) continue;
                var secondarybase = "";
                if (comp != null)
                {
                    secondarybase = componentfolder(comp, "ammoObsolete");
                } else
                {
                    secondarybase = Path.Combine("Ammunition", "Obsolete", NameFor(ammo,false));
                }
                ammo.FileName = secondarybase + ".json";
                var cur = ammo;
                var i = 0;
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
                        ogAmmoNames[cur.Id] = NameFor(cur,false);
                        if(i++>0)cur.FileName = secondarybase + "_" + i + ".json";
                    }
                    cur = _content.GetAmmunitionObsolete(cur.CoupledAmmunitionId);
                } while (cur != null);
            }
            foreach(var ammo in _content.AmmunitionObsoleteList)
            {
                if (processed.Contains(ammo)) continue;
                ammo.FileName = Path.Combine("Ammunition", "Obsolete", "unused", NameFor(ammo,false)+".json");
            }

            foreach(var mod in _content.ComponentModList)
            {
                mod.FileName = Path.Combine("Components", "Modifications", NameFor(mod,false)+".json");
            }

            ProcessAmmunition(ammoMappings);
        }

        private void ProcessAmmunition(Dictionary<int, ComponentSerializable> mappings)
        {
            var processed = new HashSet<AmmunitionSerializable>();
            var ogNames = new Dictionary<int, string>();

            foreach(var id in mappings.Keys)
            {
                var ammo = _content.GetAmmunition(id);
                if (ammo == null) continue;
                var comp = mappings[ammo.Id];
                var secondarybase = "";
                if (comp != null)
                {
                    secondarybase = componentfolder(comp, "ammo");
                }
                else
                {
                    secondarybase = Path.Combine("Ammunition", NameFor(ammo, false));
                }
                var queue = new Queue<AmmunitionSerializable>();
                var loop = new HashSet<AmmunitionSerializable>();
                ammo.FileName = secondarybase + ".json";
                var i = 0;
                queue.Enqueue(ammo);
                loop.Add(ammo);

                while (queue.Count > 0)
                {
                    var cur = queue.Dequeue();
                    if (cur.Triggers != null)
                    {
                        foreach (var trigger in cur.Triggers)
                        {
                            var _ammo = _content.GetAmmunition(trigger.Ammunition);
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
                    } else
                    {
                        processed.Add(cur);
                        ogNames[cur.Id] = NameFor(cur,false);
                        if (i++ > 0) cur.FileName = secondarybase + "_" + i + ".json";
                    }
                }
            }

            foreach (var ammo in _content.AmmunitionList)
            {
                if (processed.Contains(ammo)) continue;
                ammo.FileName = Path.Combine("Ammunition", "unused", NameFor(ammo, false) + ".json");
            }
        }

        private void ProcessTech()
        {
            foreach (var tech in _content.TechnologyList)
            {
                var fac = tech.Faction;
                var type = tech.Type.ToString();
                var relatedItemName = "";

                switch (tech.Type)
                {
                    case Enums.TechType.Component:
                        var comp = _content.GetComponent(tech.ItemId);
                        relatedItemName = NameFor(comp,comp.DisplayCategory!=Enums.ComponentCategory.Weapon);
                        break;
                    case Enums.TechType.Ship:
                        var ship = _content.GetShip(tech.ItemId);
                        relatedItemName = NameFor(ship,false);
                        fac = ship.Faction;
                        break;
                    case Enums.TechType.Satellite:
                        relatedItemName = NameFor(_content.GetSatellite(tech.ItemId),false);
                        break;
                }

                tech.FileName = Path.Combine("Technology", FactionName(fac), relatedItemName + ".json");
            }
        }
        private void ProcessSatelites()
        {
            foreach (var satelite in _content.SatelliteList)
                satelite.FileName = Path.Combine("Satelites", NameFor(satelite,false) + ".json");

            foreach (var sateliteBuild in _content.SatelliteBuildList)
            {
                sateliteBuild.FileName = Path.Combine("Satelites", "builds", NameFor(sateliteBuild,false) + ".json");
            }
        }

        private void processComponentRelated(Dictionary<int, ComponentSerializable> mappings, IEnumerable<SerializableItem> list, string type)
        {

            foreach (var item in list)
            {
                if (mappings.ContainsKey(item.Id))
                {
                    var comp = mappings[item.Id];
                    if (comp != null)
                    {
                        item.FileName = componentfolder(comp, type) + ".json";
                    }
                    else
                    {
                        item.FileName = Path.Combine("Components", "SharedData", type, NameFor(item,false) + ".json");
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
                var type = "";
                var ct = (component.WeaponSlotType+"_")[0];
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
                return Path.Combine("Components", component.DisplayCategory.ToString(), type, NameFor(component, false), NameFor(component,false) + "_" + fileEnding);
            }
            else
            {
                return Path.Combine("Components", component.DisplayCategory.ToString(), NameFor(component,true), NameFor(component,true) + "_" + fileEnding);
            }
        }

        private void ProcessDictionary(int value, Dictionary<int,ComponentSerializable> dictionary,ComponentSerializable component)
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
            var facName = NameFor(_content.GetFaction(id),false);
            if (string.IsNullOrEmpty(facName)) facName = "Neutral";
            return facName.Trim();
        }

        private static Regex smallRegex = new Regex("^small\\s*", RegexOptions.IgnoreCase);
        private static Regex largeRegex = new Regex("^(?:large|heavy)\\s*", RegexOptions.IgnoreCase);
        private static Regex mediumRegex = new Regex("^medium\\s*", RegexOptions.IgnoreCase);
        private string NameFor(SerializableItem item,bool replaceSizeMod)
        {
            var name = Regex.Replace(NameForRaw(item), "['\"/\\+?]", "");
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
                    var name = NameFor(_content.GetShip(shipBuild.ShipId),false);
                    if (shipBuild.DifficultyClass > 0) name += "_" + new string('x', (int)shipBuild.DifficultyClass);
                    return name;
                case SatelliteBuildSerializable satelliteBuild:
                    name = NameFor(_content.GetSatellite(satelliteBuild.SatelliteId),false);
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
            var xml = XElement.Parse(data);
            foreach (var entry in xml.Elements())
            {
                if (entry.Name != "string") return;
                var name = entry.Attribute("name");
                if (name == null) return;
                _localization["$" + name.Value] = entry.Value;
            }
        }

        public string GetVanillaLocal()
        {
            var result = string.Empty;
            using (var stream = GetType().Assembly
                .GetManifestResourceStream("GameDatabase.GameDatabase.Utilites.VanillaLocal.xml"))
            {
                using (var sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }
    }
}