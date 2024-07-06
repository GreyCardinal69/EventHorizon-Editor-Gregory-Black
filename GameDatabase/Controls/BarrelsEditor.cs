using EditorDatabase;
using System;
using System.Windows.Forms;

namespace GameDatabase.Controls
{
    public partial class BarrelsEditor : Form
    {
        public BarrelsEditor( BarrelsCollectionEditor barrels )
        {
            InitializeComponent();
            this._editor = barrels;
            structDataEditor1.DataChanged += _editor.OnDataChanged;
        }

        public void SetBarrel( object data )
        {
            structDataEditor1.Data = data as IDataAdapter ?? new DataAdapter( data );
        }

        public void UpdateBarrel()
        {
            structDataEditor1.UpdateControls();
        }
        private BarrelsCollectionEditor _editor;

        private void moveUpButton_Click( object sender, EventArgs e )
        {
            _editor.clickUp();
        }

        private void moveDownButton_Click( object sender, EventArgs e )
        {
            _editor.clickDown();
        }
    }
}
