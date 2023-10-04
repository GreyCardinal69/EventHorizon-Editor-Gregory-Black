using EditorDatabase;
using EditorDatabase.DataModel;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDatabase
{
    public partial class Analytics : Form
    {
        public Analytics()
        {
            InitializeComponent();
        }

        public void RunAnalytics( MainWindow main, Database database )
        {
            Data.Text = "";
            bool errorDetected = false;
            foreach ( QuestSerializable quest in database.Content.QuestList )
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
                                Data.AppendText( $"[Quest]: [{quest.FileName}]: [Node {node.Id}] leads to non-existant node with id: [{trans.TargetNode}]\n", Color.Red);
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
                                Data.AppendText( $"[Quest]: [{quest.FileName}]: [Node {node.Id}] leads to non-existant node with id: [{trans.TargetNode}]\n", Color.Red );
                            }
                        }
                    }
                    if ( node.DefaultTransition != 0 )
                    {
                        if ( !nodeIds.Contains( node.DefaultTransition ) )
                        {
                            errorDetected = true;
                            Data.AppendText( $"[Quest]: [{quest.FileName}]: [Node {node.Id}] [{(node.Type == NodeType.AttackFleet ? "Victory Transition" : "Default Transition")}] leads to non-existant node with id: [{node.DefaultTransition}]\n", Color.Red );
                        }
                    }
                    if ( node.FailureTransition != 0 )
                    {
                        if ( !nodeIds.Contains( node.FailureTransition ) )
                        {
                            errorDetected = true;
                            Data.AppendText( $"[Quest]: [{quest.FileName}]: [Node {node.Id}] [Failure Transition] leads to non-existant node with id: [{node.FailureTransition}]\n", Color.Red );
                        }
                    }
                }
                if ( errorDetected )
                {
                    errorDetected = false;
                    Data.AppendText( "\n" );
                }
                nodeIds.Clear();
            }
        }

        private void advancedButton1_Click( object sender, EventArgs e )
        {

        }
    }
}
