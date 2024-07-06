using EditorDatabase;
using EditorDatabase.DataModel;
using System;
using System.Windows.Forms;

namespace GameDatabase
{
    public partial class ComponentEditorDialog : Form
    {
        public ComponentEditorDialog( Database database, Component component )
        {
            _component = component;
            _database = database;

            InitializeComponent();
        }

        private void ComponentEditorDialog_Load( object sender, EventArgs e )
        {
            Text = _component.Id.Name;
            structDataEditor1.Database = _database;
            structDataEditor1.Data = new DataAdapter( _component );
        }

        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
        {
            if ( keyData == ( Keys.Control | Keys.S ) )
            {
                MainWindow.SaveDataBase();
                MessageBox.Show( "The Database has been saved!" );
                return true;
            }
            return base.ProcessCmdKey( ref msg, keyData );
        }

        private readonly Component _component;
        private readonly Database _database;
    }
}