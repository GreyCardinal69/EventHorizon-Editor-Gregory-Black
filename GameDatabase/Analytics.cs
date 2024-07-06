using EditorDatabase;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;
using NHunspell;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GameDatabase
{
    public partial class Analytics : Form
    {
        private string StripPunctuation( string s )
        {
            var sb = new StringBuilder();
            foreach ( char c in s )
            {
                if ( !char.IsPunctuation( c ) )
                    sb.Append( c );
            }
            return sb.ToString();
        }

        public Analytics( Database db )
        {
            _database = db;
            InitializeComponent();
        }

        private bool _initial;
        private bool _runningFullScan;
        private readonly Database _database;

        private void PrintFaultyName( string str, bool newl = true )
        {
            if ( !_initial )
            {
                _initial = true;
                Data.AppendText( str, Color.Cyan );
                if ( newl )
                {
                    Data.AppendText( "\n" );
                }
            }
        }

        private void RunTextAnalytics()
        {
            if ( !_runningFullScan ) Data.Text = "";
            bool errorDetected = false;

            using ( Hunspell hunspell = new Hunspell( "en_us.aff", "en_us.dic" ) )
            {
                foreach ( var quest in _database.Content.QuestList )
                {
                    if ( quest.Nodes != null )
                    {
                        foreach ( var node in quest.Nodes )
                        {
                            if ( node.Type == NodeType.ShowDialog && node.Message[0] != '$' )
                            {
                                if ( node.Message.ToLower().Contains( "discord" ) )
                                {
                                    continue;
                                }
                                foreach ( var word in node.Message.Split( ' ' ) )
                                {
                                    bool correct = hunspell.Spell( StripPunctuation( Regex.Replace( word, @"[^a-zA-Z\s\p{P}]", "" ) ) );
                                    if ( !correct )
                                    {
                                        errorDetected = true;
                                        PrintFaultyName( $"[Quest]: [{quest.FileName}]:" );
                                        Data.AppendText( $"     [Node]: [{node.Id}] has a typo; [\"{word}\"] in the sentence [\"{node.Message}\"].", Color.Red, true );
                                        Data.AppendText( $"     Possible fixes for the incorrect word: [\"{word}\"]", Color.HotPink );

                                        List<string> suggestions = hunspell.Suggest( word );
                                        Data.AppendText( "\n" );

                                        Data.AppendText( $"     There are {suggestions.Count} suggestions", Color.HotPink );
                                        Data.AppendText( "\n" );
                                        foreach ( string suggestion in suggestions )
                                        {
                                            Data.AppendText( $"     Suggestion is: \"{suggestion}\"", Color.HotPink );
                                            Data.AppendText( "\n" );
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if ( errorDetected )
                    {
                        errorDetected = false;
                        Data.AppendText( "\n" );
                    }
                    _initial = false;
                }
            }
        }
        public static double CalculateSimilarity( string source, string target )
        {
            if ( ( source == null ) || ( target == null ) ) return 0.0;
            if ( ( source.Length == 0 ) || ( target.Length == 0 ) ) return 0.0;
            if ( source == target ) return 1.0;

            int stepsToSame = LevenshteinDistance( source, target );
            return ( 1.0 - ( stepsToSame / ( double ) Math.Max( source.Length, target.Length ) ) );
        }

        private static int LevenshteinDistance( string source, string target )
        {
            if ( source == target ) return 0;
            if ( source.Length == 0 ) return target.Length;
            if ( target.Length == 0 ) return source.Length;

            int[] v0 = new int[target.Length + 1];
            int[] v1 = new int[target.Length + 1];

            for ( int i = 0; i < v0.Length; i++ )
                v0[i] = i;

            for ( int i = 0; i < source.Length; i++ )
            {
                v1[0] = i + 1;

                for ( int j = 0; j < target.Length; j++ )
                {
                    var cost = ( source[i] == target[j] ) ? 0 : 1;
                    v1[j + 1] = Math.Min( v1[j] + 1, Math.Min( v0[j + 1] + 1, v0[j] + cost ) );
                }

                for ( int j = 0; j < v0.Length; j++ )
                    v0[j] = v1[j];
            }

            return v1[target.Length];
        }

        private bool FormatValid( string format )
        {
            string allowableLetters = "12345";

            if ( format == "" )
            {
                return
                     false;
            }

            foreach ( char c in format )
            {
                // This is using String.Contains for .NET 2 compat.,
                //   hence the requirement for ToString()
                if ( !allowableLetters.Contains( c.ToString() ) )
                    return false;
            }

            return true;
        }

        private void RunComponentAnalytics()
        {
            if ( !_runningFullScan ) Data.Text = "";
            bool errorDetected = false;

            List<int> statIds = new List<int>();

            foreach ( var stat in _database.Content.ComponentStatsList )
            {
                statIds.Add( stat.Id );
            }

            List<string> vanillaImages = @"missile3 torpedo1 afterburner1 doom1 reactor21 reactor22 fueltank23 fueltank22 fueltank21 focus2 focus1 jammer armor63 armor62 armor61 detonator1 engine3 laser1 laser3 zygote3 zygote2 zygote1 rocket1 torpedo4 armor11 dronebay1 dronebay3 dronebay2 drone_power1 drone_power3 drone_power2 engine0 drone_replicator1 drone_replicator3 drone_replicator2 laser4 torpedo3 armor33 armor32 armor31 energybeam2 shield2 energybeam1 pointdefense shield1 fueltank13 fueltank12 fueltank11 engine4 engine2 reactor2 shock1 holy_gun armor23 armor22 armor21 intertial_damper1 inertial2 intertial_damper2 core ion_cannon1 ion_cannon2 laser2 shock2 gun4 gun7 missile1 missile2 missile0 lightweight1 gun6 gun3 engine5 engine1 reactor1 gun1 shotgun1 flamethrower1 torpedo2 gun5 gun2 shotgun2 range1 armor53 armor52 armor51 repairbot2 repairbot1 shield_capacitor3 shield_capacitor2 shield_capacitor1 shield_generator3 shield_generator2 shield_generator1 accelerator1 TargetingUnit teleporter teleporter1 armor43 armor42 armor41 armor13 armor12 reactor3 firework".Split( ' ' ).ToList();

            foreach ( var component in _database.Content.ComponentList )
            {
                if ( component.ComponentStatsId == 0 || !statIds.Contains( component.ComponentStatsId ) )
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Component]: [{component.FileName}]:" );
                    Data.AppendText( $"     Has no Stats file reference ( [EMPTY] or points to non-existant Stats file id ).", Color.Red ); Data.AppendText( "\n" );
                }

                if ( component.Icon != null )
                {
                    if ( !_database.Content.ImagesB.ContainsKey( component.Icon ) && !vanillaImages.Contains( component.Icon ) )
                    {
                        errorDetected = true;
                        PrintFaultyName( $"[Component]: [{component.FileName}]:" );
                        Data.AppendText( $"     Has incorrect Icon/Image id ( Typo or image does not exist at all ).", Color.Red );

                        foreach ( var name in _database.Content.ImagesB.Keys )
                        {
                            var distance = CalculateSimilarity( name.Replace( ".png", "" ), component.Icon.Replace( ".png", "" ) ) * 100;
                            if ( distance >= 75 )
                            {
                                Data.AppendText( $"\n          Current Icon ID: {component.Icon}, did you mean: {name}?", Color.HotPink );
                            }
                        }
                        foreach ( var name in vanillaImages )
                        {
                            var distance = CalculateSimilarity( name.Replace( ".png", "" ), component.Icon.Replace( ".png", "" ) ) * 100;
                            if ( distance >= 75 )
                            {
                                Data.AppendText( $"\n          Current Icon ID: {component.Icon}, did you mean: {name}?", Color.HotPink );
                            }
                        }
                    }
                }
                else
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Component]: [{component.FileName}]:" );
                    Data.AppendText( $"     Has a NULL Icon id ( not defined in the .json file or simple left empty ).", Color.Red );
                }

                if ( component.CellType != null )
                {
                    if ( !FormatValid( component.CellType ) )
                    {
                        Data.AppendText( "\n" );
                        errorDetected = true;
                        PrintFaultyName( $"[Component]: [{component.FileName}]:" );

                        var anomaly = component.CellType
                            .Replace( "1", "" )
                            .Replace( "2", "" )
                            .Replace( "3", "" )
                            .Replace( "4", "" )
                            .Replace( "5", "" )
                            .Replace( "0", "" );

                        Data.AppendText( $"     Has an anomalious Slot Type character: {anomaly}.",
                        Color.Red );
                    }
                }

                if ( errorDetected )
                {
                    errorDetected = false;
                    Data.AppendText( "\n" );
                }
                _initial = false;
            }
        }

        private void RunOtherAnalytics()
        {
            if ( !_runningFullScan ) Data.Text = "";
            bool errorDetected = false;

            foreach ( var ammo in _database.Content.AmmunitionList )
            {
                if ( ammo.Body.Range > 0 && ammo.Body.Velocity <= 0 )
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Advanced Ammunition]: [{ammo.FileName}]:" );
                    Data.AppendText( $"     Has Range but no Velocity, is this intended?", Color.Orange, true );
                }

                if ( errorDetected )
                {
                    errorDetected = false;
                    Data.AppendText( "\n" );
                }
                _initial = false;
            }

            List<int> shipIds = new List<int>();

            foreach ( var item in _database.Content.ShipList )
            {
                shipIds.Add( item.Id );
            }

            List<int> factionIds = new List<int>();

            foreach ( var item in _database.Content.FactionList )
            {
                factionIds.Add( item.Id );
            }

            List<int> buildIds = new List<int>();

            foreach ( var item in _database.Content.ShipBuildList )
            {
                buildIds.Add( item.Id );
            }

            if ( _database.Content.ExplorationSettings.OutpostShip == 0 || !shipIds.Contains( _database.Content.ExplorationSettings.OutpostShip ) )
            {
                errorDetected = true;
                PrintFaultyName( $"[Exploration Settings]: [{_database.Content.ExplorationSettings.FileName}]:" );
                Data.AppendText( $"     OutpostShip is empty or points to incorrect Ship ( [EMPTY] in editor ).", Color.Red, true );
            }
            errorDetected = false;
            if ( _database.Content.ExplorationSettings.TurretShip == 0 || !shipIds.Contains( _database.Content.ExplorationSettings.TurretShip ) )
            {
                errorDetected = true;
                PrintFaultyName( $"[Exploration Settings]: [{_database.Content.ExplorationSettings.FileName}]:" );
                Data.AppendText( $"     TurretShip is empty or points to incorrect Ship ( [EMPTY] in editor ).", Color.Red, true );
            }
            errorDetected = false;

            if ( _database.Content.ExplorationSettings.InfectedPlanetFaction == 0 || !factionIds.Contains( _database.Content.ExplorationSettings.InfectedPlanetFaction ) )
            {
                errorDetected = true;
                PrintFaultyName( $"[Exploration Settings]: [{_database.Content.ExplorationSettings.FileName}]:" );
                Data.AppendText( $"     InfectedPlanetFaction is empty or points to incorrect Faction ( [EMPTY] in editor ).", Color.Red, true );
            }
            errorDetected = false;

            if ( _database.Content.ExplorationSettings.HiveShipBuild == 0 || !buildIds.Contains( _database.Content.ExplorationSettings.HiveShipBuild ) )
            {
                errorDetected = true;
                PrintFaultyName( $"[Exploration Settings]: [{_database.Content.ExplorationSettings.FileName}]:" );
                Data.AppendText( $"     HiveShipBuild is empty or points to incorrect Ship Build ( [EMPTY] in editor ).", Color.Red, true );
            }
            errorDetected = false;

            foreach ( var build in _database.Content.GalaxySettings.StartingShipBuilds )
            {
                if ( !buildIds.Contains( build ) )
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Galaxy Settings]: [{_database.Content.GalaxySettings.FileName}]:" );
                    Data.AppendText( $"     Contains empty or incorrect starting ShipBuild ID: [{build}] ( [EMPTY] in editor ).", Color.Red, true );
                }
            }
            errorDetected = false;

            if ( !factionIds.Contains( _database.Content.GalaxySettings.AbandonedStarbaseFaction ) )
            {
                errorDetected = true;
                PrintFaultyName( $"[Galaxy Settings]: [{_database.Content.GalaxySettings.FileName}]:" );
                Data.AppendText( $"     Contains empty or incorrect AbandonedStationFaction ID: [{_database.Content.GalaxySettings.AbandonedStarbaseFaction}] ( [EMPTY] in editor ).", Color.Red, true );
            }
            errorDetected = false;
        }

        private void RunShipAnalytics()
        {
            if ( !_runningFullScan ) Data.Text = "";
            bool errorDetected = false;

            List<int> devices = new List<int>();

            foreach ( var item in _database.Content.DeviceList )
            {
                devices.Add( item.Id );
            }

            foreach ( var ship in _database.Content.ShipList )
            {
                if ( ship.ModelImage == "" || ship.ModelImage == null )
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Ship]: [{ship.FileName}]:" );
                    Data.AppendText( $"     Has no ModelImage file reference, the ship will appear as a white box.", Color.Red );
                    Data.AppendText( "\n" );
                }

                if ( ship.IconImage == "" || ship.IconImage == null )
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Ship]: [{ship.FileName}]:" );
                    Data.AppendText( $"     Has no IconImage file reference, the ship's icon will appear as the ModelImage if present, if not then a white box. You should make an icon....NOW!", Color.Orange );
                    Data.AppendText( "\n" );
                }

                if ( ship.Name == "" || ship.Name == null )
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Ship]: [{ship.FileName}]:" );
                    Data.AppendText( $"     Has an empty name.", Color.Red );
                    Data.AppendText( "\n" );
                }

                if ( ship.Layout != null )
                {
                    if ( ship.Layout.Length == 0 )
                    {
                        errorDetected = true;
                        PrintFaultyName( $"[Ship]: [{ship.FileName}]:" );
                        Data.AppendText( $"     Has an empty layout ( no slots ).", Color.Red );
                        Data.AppendText( "\n" );
                    }
                }
                else
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Ship]: [{ship.FileName}]:" );
                    Data.AppendText( $"     Has an empty layout ( no slots ).", Color.Red );
                    Data.AppendText( "\n" );
                }

                if ( ship.Barrels != null )
                {
                    if ( ship.Barrels.Length < 1 )
                    {
                        errorDetected = true;
                        PrintFaultyName( $"[Ship]: [{ship.FileName}]:" );
                        Data.AppendText( $"     Has an no barrels. Is this intended?", Color.Orange );
                        Data.AppendText( "\n" );
                    }
                }
                else
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Ship]: [{ship.FileName}]:" );
                    Data.AppendText( $"     Has no barrels. Is this intended?", Color.Orange );
                    Data.AppendText( "\n" );
                }

                if ( ship.BuiltinDevices != null )
                {
                    foreach ( var item in ship.BuiltinDevices )
                    {
                        if ( !devices.Contains( item ) )
                        {
                            errorDetected = true;
                            PrintFaultyName( $"[Ship]: [{ship.FileName}]:" );
                            Data.AppendText( $"     Has an empty or incorrect BuiltIn device ID: [{item}] ( [EMPTY] in editor ).", Color.Red );
                            Data.AppendText( "\n" );
                        }
                    }
                }

                if ( errorDetected )
                {
                    errorDetected = false;
                    Data.AppendText( "\n" );
                }
                _initial = false;
            }
        }

        private void RunShipBuildAnalytics()
        {
            if ( !_runningFullScan ) Data.Text = "";
            bool errorDetected = false;

            List<int> componentIds = new List<int>();

            foreach ( var comp in _database.Content.ComponentList )
            {
                componentIds.Add( comp.Id );
            }

            foreach ( var build in _database.Content.ShipBuildList )
            {
                if ( build.Components != null )
                {
                    foreach ( var item in build.Components )
                    {
                        if ( !componentIds.Contains( item.ComponentId ) || item.ComponentId == 0 )
                        {
                            errorDetected = true;
                            PrintFaultyName( $"[ShipBuild]: [{build.FileName}]:" );
                            Data.AppendText( $"     Ship build with id: {build.Id} Contains an empty or an incorrect component id: [{item.ComponentId}].", Color.Red, true );
                        }
                    }
                }
                if ( errorDetected )
                {
                    errorDetected = false;
                    Data.AppendText( "\n" );
                }
                _initial = false;
            }
        }


        // TO DO
        private void RunLootAnalytics()
        {

            if ( !_runningFullScan ) Data.Text = "";

            List<int> moduleIds = new List<int>();
            List<int> questItemIds = new List<int>();

            foreach ( var component in _database.Content.ComponentList )
            {
                moduleIds.Add( component.Id );
            }

            foreach ( var questItem in _database.Content.QuestItemList )
            {
                questItemIds.Add( questItem.Id );
            }
        }

        private void RunTechAnalytics()
        {
            if ( !_runningFullScan ) Data.Text = "";
            bool errorDetected = false;

            List<int> satelliteIds = new List<int>();
            List<int> shipIds = new List<int>();
            List<int> componentIds = new List<int>();
            List<int> factionIds = new List<int>();
            List<int> technologyIds = new List<int>();

            foreach ( var item in _database.Content.ComponentList )
            {
                componentIds.Add( item.Id );
            }
            foreach ( var item in _database.Content.SatelliteList )
            {
                satelliteIds.Add( item.Id );
            }
            foreach ( var item in _database.Content.ShipList )
            {
                shipIds.Add( item.Id );
            }
            foreach ( var item in _database.Content.FactionList )
            {
                factionIds.Add( item.Id );
            }
            foreach ( var item in _database.Content.TechnologyList )
            {
                technologyIds.Add( item.Id );
            }

            Data.AppendText( "--------------------------------\n" );
            foreach ( var item in _database.Content.TechnologyList )
            {
                foreach ( var item2 in _database.Content.TechnologyList )
                {
                    if ( item.Dependencies != null && item2.Dependencies != null )
                    {
                        if ( item.Dependencies.Contains( item2.Id ) && item2.Dependencies.Contains( item.Id ) )
                        {
                            errorDetected = true;
                            Data.AppendText( $"[Technology]: [{item.FileName}] And [Technology]: [{item2.FileName}] Are in a cyclic dependancy", Color.Cyan, true );
                            Data.AppendText( $"     [Technology]: [{item.FileName}] has [Technology]: [{item2.FileName}] as a dependancy and vise versa.", Color.Red, true );
                        }
                    }
                }
            }
            if ( !errorDetected )
            {
                Data.AppendText( "No cyclic dependencies found.\n" );
            }
            Data.AppendText( "--------------------------------\n" );

            foreach ( var tech in _database.Content.TechnologyList )
            {
                switch ( tech.Type )
                {
                    case TechType.Component:
                        if ( tech.ItemId == 0 || !componentIds.Contains( tech.ItemId ) )
                        {
                            errorDetected = true;
                            PrintFaultyName( $"[Technology]: [{tech.FileName}]:" );
                            Data.AppendText( $"     Has incorrect or empty Satellite/Ship/Component ID ( [EMPTY] In the editor ).", Color.Red, true );
                        }
                        break;
                    case TechType.Ship:
                        if ( tech.ItemId == 0 || !shipIds.Contains( tech.ItemId ) )
                        {
                            errorDetected = true;
                            PrintFaultyName( $"[Technology]: [{tech.FileName}]:" );
                            Data.AppendText( $"     Has incorrect or empty Satellite/Ship/Component ID ( [EMPTY] In the editor ).", Color.Red, true );
                        }
                        break;
                    case TechType.Satellite:
                        if ( tech.ItemId == 0 || !satelliteIds.Contains( tech.ItemId ) )
                        {
                            errorDetected = true;
                            PrintFaultyName( $"[Technology]: [{tech.FileName}]:" );
                            Data.AppendText( $"     Has incorrect or empty Satellite/Ship/Component ID ( [EMPTY] In the editor ).", Color.Red, true );
                        }
                        break;
                }

                if ( tech.Faction == 0 )
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Technology]: [{tech.FileName}]:" );
                    Data.AppendText( $"     Has Incorrect or Empty Faction ID ( [EMPTY] In the editor ). Is this intended?", Color.Orange, true );
                }

                if ( tech.Price == 0 )
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Technology]: [{tech.FileName}]:" );
                    Data.AppendText( $"     Has 0 research cost. Is this intended?", Color.Orange, true );
                }

                if ( tech.Dependencies != null )
                {
                    if ( tech.Dependencies.Length >= 1 )
                    {
                        foreach ( var dep in tech.Dependencies )
                        {
                            if ( dep == 0 || !technologyIds.Contains( dep ) )
                            {
                                errorDetected = true;
                                PrintFaultyName( $"[Technology]: [{tech.FileName}]:" );
                                Data.AppendText( $"     Has incorrect or Empty dependancy ID. ( [EMPTY] In the editor ).", Color.Red, true );
                            }
                        }
                    }
                }

                if ( errorDetected )
                {
                    errorDetected = false;
                    Data.AppendText( "\n" );
                }
                _initial = false;
            }
        }

        private void RunFleetAnalytics()
        {
            if ( !_runningFullScan ) Data.Text = "";
            bool errorDetected = false;

            List<int> builds = new List<int>();

            foreach ( FleetSerializable fleet in _database.Content.FleetList )
            {
                if ( fleet.SpecificShips == null )
                {
                    continue;
                }
                foreach ( var build in fleet.SpecificShips )
                {
                    builds.Add( build );
                }
            }

            foreach ( FleetSerializable fleet in _database.Content.FleetList )
            {
                if ( fleet.SpecificShips == null )
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Fleet]: [{fleet.FileName}]:" );
                    Data.AppendText( $"     Has no specific ship ids, is this intended?", Color.Orange );
                }
                else
                {
                    foreach ( var build in fleet.SpecificShips )
                    {
                        if ( !builds.Contains( build ) || ( build == 0 && fleet.SpecificShips.Length > 0 ) )
                        {
                            errorDetected = true;
                            PrintFaultyName( $"[Fleet]: [{fleet.FileName}]:" );
                            Data.AppendText( $"     Ship build with id: {build} ( the buid is marked as [EMPTY] in the editor ) does not exist.", Color.Red );
                        }
                    }
                }
                if ( errorDetected )
                {
                    errorDetected = false;
                    Data.AppendText( "\n" );
                }
                _initial = false;
            }
        }

        private void RunQuestAnalytics()
        {
            if ( !_runningFullScan ) Data.Text = "";
            bool errorDetected = false;
            foreach ( QuestSerializable quest in _database.Content.QuestList )
            {
                List<int> nodeIds = new List<int>();

                if ( quest.Nodes == null )
                {
                    Data.AppendText( $"[Quest]: [{quest.FileName}]: Contains no Nodes, fix it.\n", Color.Orange );
                    continue;
                }

                foreach ( var node in quest.Nodes )
                {
                    nodeIds.Add( node.Id );
                }

                foreach ( var node in quest.Nodes )
                {
                    if ( node.Actions != null )
                    {
                        foreach ( var trans in node.Actions )
                        {
                            if ( !nodeIds.Contains( trans.TargetNode ) )
                            {
                                errorDetected = true;
                                PrintFaultyName( $"[Quest]: [{quest.FileName}]:" );
                                Data.AppendText( $"     [Node {node.Id}] leads to non-existant node with id: [{trans.TargetNode}]\n", Color.Red );
                            }
                        }
                    }
                    if ( node.Transitions != null )
                    {
                        foreach ( var trans in node.Transitions )
                        {
                            if ( !nodeIds.Contains( trans.TargetNode ) )
                            {
                                errorDetected = true;
                                PrintFaultyName( $"[Quest]: [{quest.FileName}]:" );
                                Data.AppendText( $"     [Node {node.Id}] leads to non-existant node with id: [{trans.TargetNode}]\n", Color.Red );
                            }
                        }
                    }
                    if ( node.DefaultTransition != 0 )
                    {
                        if ( !nodeIds.Contains( node.DefaultTransition ) )
                        {
                            errorDetected = true;
                            PrintFaultyName( $"[Quest]: [{quest.FileName}]:" );
                            Data.AppendText( $"     [Node {node.Id}] [{( node.Type == NodeType.AttackFleet ? "Victory Transition" : "Default Transition" )}] leads to non-existant node with id: [{node.DefaultTransition}]\n", Color.Red );
                        }
                    }
                    if ( node.FailureTransition != 0 )
                    {
                        if ( !nodeIds.Contains( node.FailureTransition ) )
                        {
                            errorDetected = true;
                            PrintFaultyName( $"[Quest]: [{quest.FileName}]:" );
                            Data.AppendText( $"     [Node {node.Id}] [Failure Transition] leads to non-existant node with id: [{node.FailureTransition}]\n", Color.Red );
                        }
                    }
                }
                if ( errorDetected )
                {
                    errorDetected = false;
                    Data.AppendText( "\n" );
                }
                _initial = false;
                nodeIds.Clear();
            }
        }

        private void ShipAnalitics_Click( object sender, EventArgs e ) => RunShipAnalytics();
        private void ShipBuildAnalitics_Click( object sender, EventArgs e ) => RunShipBuildAnalytics();
        private void TechAnalitics_Click( object sender, EventArgs e ) => RunTechAnalytics();
        private void QuestAnalytics_Click( object sender, EventArgs e ) => RunQuestAnalytics(); ///////////////
        private void FleetAnalitics_Click( object sender, EventArgs e ) => RunFleetAnalytics();
        private void LootAnalitics_Click( object sender, EventArgs e ) => RunLootAnalytics(); ///////////////
        private void ComponentAnalitics_Click( object sender, EventArgs e ) => RunComponentAnalytics();
        private void TextAnalitics_Click( object sender, EventArgs e ) => RunTextAnalytics();
        private void OtherAnalitics_Click( object sender, EventArgs e ) => RunOtherAnalytics();

        private void AllAnalytics_Click( object sender, EventArgs e )
        {
            _runningFullScan = true;

            RunShipAnalytics();
            RunShipBuildAnalytics();
            RunTechAnalytics();
            RunQuestAnalytics();
            RunFleetAnalytics();
            RunLootAnalytics();
            RunComponentAnalytics();
            RunOtherAnalytics();

            _runningFullScan = false;
        }

        private void Statistics_Click( object sender, EventArgs e )
        {
            if ( !_runningFullScan ) Data.Text = "";

            Data.AppendText( $"[Fleets]: ", Color.Cyan );
            Data.AppendText( $"[{_database.Content.FleetList.Count}].\n", Color.Orange );

            Data.AppendText( $"[Components]: ", Color.Cyan );
            Data.AppendText( $"[{_database.Content.ComponentList.Count}].\n", Color.Orange );

            Data.AppendText( $"[Ships]: ", Color.Cyan );
            Data.AppendText( $"[{_database.Content.ShipList.Count}].\n", Color.Orange );

            Data.AppendText( $"[Builds]: ", Color.Cyan );
            Data.AppendText( $"[{_database.Content.ShipBuildList.Count}].\n", Color.Orange );

            Data.AppendText( $"[Quests]: ", Color.Cyan );
            Data.AppendText( $"[{_database.Content.QuestList.Count}].\n", Color.Orange );

            Data.AppendText( $"[Technologies]: ", Color.Cyan );
            Data.AppendText( $"[{_database.Content.TechnologyList.Count}].\n", Color.Orange );

            Data.AppendText( $"[Loots]: ", Color.Cyan );
            Data.AppendText( $"[{_database.Content.LootList.Count}].\n", Color.Orange );

            Data.AppendText( $"[Characters]: ", Color.Cyan );
            Data.AppendText( $"[{_database.Content.CharacterList.Count}].\n", Color.Orange );

            Data.AppendText( $"[Total Quest Nodes]: ", Color.Cyan );
            int nodes = 0;
            foreach ( var node in _database.Content.QuestList )
                if ( node.Nodes != null ) nodes += node.Nodes.Length;
            Data.AppendText( $"[{nodes}].\n", Color.Orange );

            Data.AppendText( $"[Total Quest Dialogue Words]: ", Color.Cyan );
            int words = 0;
            foreach ( QuestSerializable node in _database.Content.QuestList )
            {
                if ( node.Nodes != null )
                {
                    foreach ( var item in node.Nodes )
                    {
                        if ( item.Message != null )
                        {
                            words += item.Message.Split( ' ' ).Length;
                        }
                    }
                }
            }
            Data.AppendText( $"[{words}].\n", Color.Orange );
        }
    }
}