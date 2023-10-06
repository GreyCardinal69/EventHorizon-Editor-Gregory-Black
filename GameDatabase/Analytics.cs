using EditorDatabase;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NHunspell;
using System.Collections;
using EditorDatabase.DataModel;
using System.Linq;

namespace GameDatabase
{
    public partial class Analytics : Form
    {
        public Analytics( Database db )
        {
            _database = db;
            InitializeComponent();
        }

        private bool _initial;
        private Database _database;

        private void PrintFaultyName( string str )
        {
            if ( !_initial )
            {
                _initial = true;
                Data.AppendText( str, Color.Cyan );
                Data.AppendText( "\n" );
            }
        }

        private void RunTextAnalytics()
        {


            using ( Hunspell hunspell = new Hunspell( "en_us.aff", "en_us.dic" ) )
            {
                bool correct = hunspell.Spell( "Recommendatiosdn" );
                Data.AppendText( $"[Quest]: [YOUR_MAMA.JSON]: Node: [1], has a typo: Recommendatiosdn\n", Color.Red );
                Data.AppendText( "\n" );
                Data.AppendText( "" );
                Data.AppendText( "Make suggestions for the word 'Recommendatio'" );
                Data.AppendText( "\n" );
                List<string> suggestions = hunspell.Suggest( "Recommendatio" );
                Data.AppendText( "\n" );
                Data.AppendText( "There are " +
                   suggestions.Count.ToString() + " suggestions" );
                Data.AppendText( "\n" );
                foreach ( string suggestion in suggestions )
                {
                    Data.AppendText( "Suggestion is: " + suggestion );
                    Data.AppendText( "\n" );
                }
            }

        }

        private static int LevenshteinDistance( string s, string t )
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];
            if ( n == 0 )
            {
                return m;
            }
            if ( m == 0 )
            {
                return n;
            }
            for ( int i = 1; i <= n; i++ )
            {
                for ( int j = 1; j <= m; j++ )
                {
                    int cost = ( t[j - 1] == s[i - 1] ) ? 0 : 1;
                    d[i, j] = Math.Min( Math.Min( d[i - 1, j] + 1, d[i, j - 1] + 1 ), d[i - 1, j - 1] + cost );
                }
            }
            return d[n, m];
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
            Data.Text = "";
            bool errorDetected = false;

            List<int> statIds = new List<int>();

            foreach ( var stat in _database.Content.ComponentStatsList )
            {
                statIds.Add( stat.Id );
            }

            List<string> vanillaImages = @"missile3 torpedo1 afterburner1 doom1 reactor21 reactor22 fueltank23 fueltank22 fueltank21 focus2 focus1 jammer armor63 armor62 armor61 detonator1 engine3 laser1 laser3 zygote3 zygote2 zygote1 rocket1 torpedo4 armor11 dronebay1 dronebay3 dronebay2 drone_power1 drone_power3 drone_power2 engine0 drone_replicator1 drone_replicator3 drone_replicator2 laser4 torpedo3 armor33 armor32 armor31 energybeam2 shield2 energybeam1 pointdefense shield1 fueltank13 fueltank12 fueltank11 engine4 engine2 reactor2 shock1 holy_gun armor23 armor22 armor21 intertial_damper1 inertial2 intertial_damper2 core ion_cannon1 ion_cannon2 laser2 shock2 gun4 gun7 missile1 missile2 missile0 lightweight1 gun6 gun3 engine5 engine1 reactor1 gun1 shotgun1 flamethrower1 torpedo2 gun5 gun2 shotgun2 range1 armor53 armor52 armor51 repairbot2 repairbot1 shield_capacitor3 shield_capacitor2 shield_capacitor1 shield_generator3 shield_generator2 shield_generator1 accelerator1 TargetingUnit teleporter teleporter1 armor43 armor42 armor41 armor13 armor12 reactor3 firework".Split(' ').ToList();

            foreach ( var component in _database.Content.ComponentList )
            {
                if ( component.ComponentStatsId == 0 || !statIds.Contains( component.ComponentStatsId) )
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Component]: [{component.FileName}]:" );
                    Data.AppendText( $"     Has no Stats file reference ( [EMPTY] or points to non-existant Stats file id ).", Color.Red ); Data.AppendText( "\n" );
                }

                if ( !_database.Content.ImagesB.ContainsKey(component.Icon) && !vanillaImages.Contains(component.Icon) )
                {
                    errorDetected = true;
                    PrintFaultyName( $"[Component]: [{component.FileName}]:" );
                    Data.AppendText( $"     Has incorrect Icon/Image id ( Typo or image does not exist at all ).", Color.Red );

                    foreach ( var name in _database.Content.ImagesB.Keys )
                    {
                        if ( LevenshteinDistance(component.Icon, name) < 3 )
                        {
                            Data.AppendText( $"\n          Current Icon ID: {component.Icon}, did you mean: {name}?", Color.HotPink );
                        }
                    }
                    foreach ( var name in vanillaImages )
                    {
                        if ( LevenshteinDistance( component.Icon, name ) < 3 )
                        {
                            Data.AppendText( $"\n          Current Icon ID: {component.Icon}, did you mean: {name}?", Color.HotPink );
                        }
                    }
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
                            .Replace( "5", "" );

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

        }

        private void RunShipAnalytics()
        {

        }

        private void RunShipBuildAnalytics()
        {

        }

        private void RunAdvAmmoAnalytics()
        {

        }

        private void RunLootAnalytics()
        {

            Data.Text = "";
            bool errorDetected = false;

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

        }

        private void RunFleetAnalytics()
        {
            Data.Text = "";
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
            Data.Text = "";
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

        private void AdvAmmoAnalitics_Click( object sender, EventArgs e ) => RunAdvAmmoAnalytics(); ///////////////
        private void ShipAnalitics_Click( object sender, EventArgs e ) => RunShipAnalytics();////////////
        private void ShipBuildAnalitics_Click( object sender, EventArgs e ) => RunShipBuildAnalytics(); ///////////////
        private void TechAnalitics_Click( object sender, EventArgs e ) => RunTechAnalytics(); ///////////////
        private void QuestAnalytics_Click( object sender, EventArgs e ) => RunQuestAnalytics(); ///////////////
        private void FleetAnalitics_Click( object sender, EventArgs e ) => RunFleetAnalytics();
        private void LootAnalitics_Click( object sender, EventArgs e ) => RunLootAnalytics(); ///////////////
        private void ComponentAnalitics_Click( object sender, EventArgs e ) => RunComponentAnalytics();
        private void TextAnalitics_Click( object sender, EventArgs e ) => RunTextAnalytics();///////////////
        private void OtherAnalitics_Click( object sender, EventArgs e ) => RunOtherAnalytics();///////////////

        private void AllAnalytics_Click( object sender, EventArgs e ) ///////////////
        {

        }
    }
}
