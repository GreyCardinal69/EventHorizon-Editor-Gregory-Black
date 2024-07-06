using EditorDatabase;
using EditorDatabase.DataModel;
using EditorDatabase.Model;
using GameDatabase.GameDatabase.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static GameDatabase.Reusables;

namespace GameDatabase.Controls
{
    public partial class CollectionEditor : UserControl
    {
        [Description( "Database" ), Category( "Data" )]
        public Database Database
        {
            get { return _database; }
            set { _database = value; }
        }

        [Description( "ContentAutoScroll" ), Category( "Layout" )]
        public bool ContentAutoScroll
        {
            get { return tableLayoutPanel.AutoScroll; }
            set { tableLayoutPanel.AutoScroll = value; }
        }

        [Description( "Collection" ), Category( "Data" )]
        public Array Data
        {
            get { return _collection; }
            set
            {
                _collection = value;
                BuildLayout();
            }
        }

        [Description( "ShowItemsNumbers" ), Category( "Layout" )]
        public bool ShowItemsNumbers
        {
            get { return _showNumbers; }
            set
            {
                if ( _showNumbers != value )
                {
                    _showNumbers = value;
                    BuildLayout();
                }
            }
        }

        [Description( "Collapseable" ), Category( "Layout" )]
        public bool Collapseable
        {
            get { return _collapseable; }
            set
            {
                if ( _collapseable != value )
                {
                    _collapseable = value;
                    BuildLayout();
                }
            }
        }

        public event EventHandler CollectionChanged;

        public event EventHandler DataChanged;

        public CollectionEditor()
        {
            InitializeComponent();
            rowsPerPage = MainWindow.MainInstance.DBESettings.ElementsPerPage;
        }

        protected void Cleanup()
        {
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.RowCount = 0;
            _radioButtons.Clear();
            _controls.Clear();
            _collapseButtons.Clear();
            _selectedRowId = -1;
            updateMultipageStatus();
            cloneButton.Visible = false;
        }

        protected void BuildLayout()
        {
            Cleanup();

            if ( _collection == null )
                return;


            if ( _collection.Length == 0 )
            {
                tableLayoutPanel.Controls.Clear();
                tableLayoutPanel.RowStyles.Clear();
                tableLayoutPanel.RowCount = 0;
                return;
            }

            cloneButton.Visible = canClone( _collection.GetValue( 0 ).GetType() );

            tableLayoutPanel.SuspendLayout();

            var rowCount = Math.Min( _collection.Length - curPage * rowsPerPage, rowsPerPage );
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowCount = rowCount;
            updateMultipageStatus();

            while ( _collapsed.Count < _collection.Length )
            {
                _collapsed.Add( false );
            }

            for ( var i = 0; i < rowCount; ++i )
                tableLayoutPanel.RowStyles.Add( new RowStyle( SizeType.AutoSize ) );
            for ( var i = 0; i < rowCount; ++i )
                AddRow( i, _collection.GetValue( i + curPage * rowsPerPage ) );


            tableLayoutPanel.ResumeLayout();
        }

        protected void AddRow( int rowId, object data )
        {
            int itemId = rowId + curPage * rowsPerPage;

            tableLayoutPanel.SuspendLayout();

            var text = _showNumbers ? ( itemId + 1 ).ToString() : string.Empty;

            var radioButton = new RadioButton { Text = text, AutoSize = true };
            _radioButtons.Add( radioButton );
            radioButton.CheckedChanged += OnRadioButtonSelected;

            tableLayoutPanel.Controls.Add( radioButton, 0, rowId );

            var button = new Button() { Text = _collapsed[itemId] ? "v" : "^", Width = 30, Visible = _collapseable };
            _collapseButtons.Add( button );
            button.Click += OnCollapseButtonPressed;

            tableLayoutPanel.Controls.Add( button, 1, rowId );

            var editor = new StructDataEditor
            {
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                AutoSize = true,
                Database = _database,
                Data = data as IDataAdapter ?? new DataAdapter( data ),
                ContentAutoScroll = false,
                Visible = !_collapsed[itemId],
                BackColor = DarkPrimary45,
                ForeColor = Color2550109
            };

            _controls.Add( editor );
            editor.DataChanged += OnDataChanged;

            tableLayoutPanel.Controls.Add( editor, 2, rowId );

            tableLayoutPanel.ResumeLayout();
        }

        protected void OnDataChanged( object sender, EventArgs args )
        {
            DataChanged?.Invoke( this, EventArgs.Empty );
        }

        private void OnRadioButtonSelected( object sender, EventArgs args )
        {
            _selectedRowId = _radioButtons.IndexOf( ( Control ) sender );
        }

        private void OnCollapseButtonPressed( object sender, EventArgs args )
        {
            int row = _collapseButtons.IndexOf( ( Control ) sender );
            int id = row + curPage * rowsPerPage;
            _collapsed[id] = !_collapsed[id];
            _controls[row].Visible = !_collapsed[id];
            ( ( Control ) sender ).Text = _collapsed[id] ? "v" : "^";
        }

        protected void moveUpButton_Click( object sender, EventArgs e )
        {
            if ( _collection == null || _collection.Length < 2 )
                return;

            if ( _selectedItemId < 0 || ( _selectedItemId == 0 && curPage == 0 ) || _selectedItemId >= _collection.Length )
                return;

            SwapElements( _selectedItemId, _selectedItemId - 1 );

            if ( _selectedRowId - 1 < 0 )
            {
                SwapPage( curPage - 1 );
                _selectedRowId = rowsPerPage - 1;
                CheckRadioButton();
            }
            else
            {
                SwapControls( _selectedRowId, _selectedRowId - 1 );
                _selectedRowId--;
                CheckRadioButton();
            }
        }

        protected void moveDownButton_Click( object sender, EventArgs e )
        {
            if ( _collection == null || _collection.Length < 2 )
                return;

            if ( _selectedItemId < 0 || _selectedItemId + 1 >= _collection.Length )
                return;

            SwapElements( _selectedItemId, _selectedItemId + 1 );

            if ( _selectedRowId + 1 >= rowsPerPage )
            {
                SwapPage( curPage + 1 );
                _selectedRowId = 0;
                CheckRadioButton();
            }
            else
            {
                SwapControls( _selectedRowId, _selectedRowId + 1 );
                _selectedRowId++;
                CheckRadioButton();
            }
        }

        private object addElement( object value = null )
        {

            //var collection = (Array)Activator.CreateInstance(_collection.GetType(), new [] {_collection.Length + 1});
            //Array.Copy(_collection, collection, _collection.Length);
            //collection.SetValue(_collection.Length, Activator.CreateInstance(_collection.GetType().));
            //_collection = collection;

            var type = _collection.GetType().GetElementType();
            var method = typeof( Array ).GetMethod( "Resize" );
            var generic = method.MakeGenericMethod( type );
            var arguments = new object[] { _collection, _collection.Length + 1 };
            generic.Invoke( null, arguments );
            _collection = ( Array ) arguments[0];
            if ( value == null )
                value = Activator.CreateInstance( type );
            _collection.SetValue( value, _collection.Length - 1 );

            updateMultipageStatus();

            _collapsed.Add( false );

            return value;
        }

        private void addButton_Click( object sender, EventArgs args )
        {
            AddObject();
        }


        protected void cloneButton_Click( object sender, EventArgs e )
        {
            if ( _collection == null )
                return;

            var value = addElement( Clone( _collection.GetValue( _selectedItemId ) ) );

            for ( int i = _collection.Length - 1; i > _selectedItemId + 1; i-- )
            {
                SwapElements( i, i - 1 );
            }

            if ( _selectedRowId + 1 >= rowsPerPage )
            {
                SwapPage( curPage + 1 );
                _selectedRowId = 0;
                CheckRadioButton();
            }
            else if ( _collection.Length <= ( curPage + 1 ) * rowsPerPage )
            {
                var rowId = tableLayoutPanel.RowCount;
                tableLayoutPanel.RowCount++;
                tableLayoutPanel.RowStyles.Add( new RowStyle( SizeType.AutoSize ) );
                AddRow( rowId, value );

                for ( int i = Math.Min( _collection.Length - curPage * rowsPerPage, rowsPerPage ) - 1; i > _selectedRowId + 1; i-- )
                {
                    SwapControls( i, i - 1 );
                }
                RebuildLayout();
                _selectedRowId++;
                CheckRadioButton();
            }
            else
            {
                RebuildLayout();
                _selectedRowId++;
                CheckRadioButton();
            }

            CollectionChanged?.Invoke( this, EventArgs.Empty );
        }

        private void deleteButton_Click( object sender, EventArgs e )
        {
            if ( _collection == null || _selectedItemId < 0 || _selectedItemId >= _collection.Length )
                return;

            var radioButton = _radioButtons[_selectedRowId];
            var control = _controls[_selectedRowId];


            var collection = Array.CreateInstance( _collection.GetType().GetElementType(), _collection.Length - 1 );
            if ( _selectedItemId > 0 )
                Array.Copy( _collection, collection, _selectedItemId );
            if ( _selectedItemId + 1 < _collection.Length )
                Array.Copy( _collection, _selectedItemId + 1, collection, _selectedItemId, _collection.Length - _selectedItemId - 1 );

            _collection = collection;

            _collapsed.RemoveAt( +_selectedItemId );


            if ( _collection.Length > 0 && _collection.Length <= curPage * rowsPerPage )
            {
                SwapPage( curPage - 1 );
                updateMultipageStatus();
                _selectedRowId = rowsPerPage - 1;
                CheckRadioButton();
            }
            else
            {
                if ( _collection.Length < ( curPage + 1 ) * rowsPerPage )
                {
                    _radioButtons.RemoveAt( _selectedRowId );
                    _controls.RemoveAt( _selectedRowId );
                    _collapseButtons.RemoveAt( _selectedRowId );
                }
                updateMultipageStatus();
                RebuildLayout();
                if ( _collection.Length > 0 )
                {
                    if ( _selectedItemId == _collection.Length )
                    {
                        _selectedRowId--;
                    }
                    CheckRadioButton();
                }
                else
                {
                    _selectedRowId = -1;
                }
            }


            CollectionChanged?.Invoke( this, EventArgs.Empty );
        }

        private void prevPageButton_Click( object sender, EventArgs e )
        {
            if ( curPage <= 0 ) return;
            SwapPage( curPage - 1 );
        }

        private void nextPageButton_Click( object sender, EventArgs e )
        {
            if ( ( curPage + 1 ) * rowsPerPage > _collection.Length ) return;
            SwapPage( curPage + 1 );
        }

        private void collapseButton_Click( object sender, EventArgs e )
        {
            _collapsed.Clear();
            while ( _collapsed.Count < _collection.Length )
            {
                _collapsed.Add( true );
            }
            RebuildLayout();
        }

        private void expandBtton_Click( object sender, EventArgs e )
        {
            _collapsed.Clear();
            while ( _collapsed.Count < _collection.Length )
            {
                _collapsed.Add( false );
            }
            RebuildLayout();
        }

        protected void SwapPage( int id )
        {
            curPage = id;
            updateMultipageStatus();
            BuildLayout();
        }

        protected void SwapElements( int index1, int index2 )
        {
            var first = _collection.GetValue( index1 );
            var second = _collection.GetValue( index2 );
            _collection.SetValue( second, index1 );
            _collection.SetValue( first, index2 );
            OnDataChanged( this, EventArgs.Empty );
        }

        protected void SwapControls( int index1, int index2 )
        {
            var control1 = _controls[index1];
            var control2 = _controls[index2];
            _controls[index1] = control2;
            _controls[index2] = control1;

            var collapsed1 = _collapsed[index1];
            var collapsed2 = _collapsed[index2];
            _collapsed[index1] = collapsed2;
            _collapsed[index2] = collapsed1;

            RebuildLayout();
        }

        protected void CheckRadioButton()
        {
            RadioButton radio = _radioButtons[_selectedRowId] as RadioButton;
            if ( radio != null )
            {
                ( _radioButtons[_selectedRowId] as RadioButton ).Checked = true;
            }
        }

        protected void RebuildLayout()
        {
            var count = Math.Min( _collection.Length - curPage * rowsPerPage, rowsPerPage );

            if ( _radioButtons.Count != count || _controls.Count != count || _collapseButtons.Count != count )
                throw new InvalidOperationException();

            tableLayoutPanel.SuspendLayout();
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowCount = count;
            while ( tableLayoutPanel.RowStyles.Count < count )
                tableLayoutPanel.RowStyles.Add( new RowStyle( SizeType.AutoSize ) );
            while ( tableLayoutPanel.RowStyles.Count > count )
                tableLayoutPanel.RowStyles.RemoveAt( tableLayoutPanel.RowStyles.Count - 1 );

            if ( _collection.Length > 0 )
            {
                cloneButton.Visible = canClone( _collection.GetValue( 0 ).GetType() );
            }

            for ( var i = 0; i < count; ++i )
            {
                tableLayoutPanel.Controls.Add( _radioButtons[i], 0, i );
                tableLayoutPanel.Controls.Add( _collapseButtons[i], 1, i );
                tableLayoutPanel.Controls.Add( _controls[i], 2, i );

                var id = i + curPage * rowsPerPage;

                _collapseButtons[i].Text = _collapsed[id] ? "v" : "^";

                _controls[i].Visible = !_collapsed[id];
                _controls[i].BackColor = DarkPrimary45;
                _controls[i].ForeColor = Color2550109;
            }

            tableLayoutPanel.ResumeLayout();
        }

        private void updateMultipageStatus()
        {
            if ( _collection == null ) return;
            if ( _collection.Length > rowsPerPage )
            {
                prevPageButton.Visible = true;
                nextPageButton.Visible = true;
                JumpTo.Visible = true;
                pageNumberButton.Visible = true;
                pageNumberButton.Text = ( curPage + 1 ) + "/" + ( ( _collection.Length - 1 ) / rowsPerPage + 1 );
            }
            else
            {
                prevPageButton.Visible = false;
                nextPageButton.Visible = false;
                JumpTo.Visible = false;
                pageNumberButton.Visible = false;
                curPage = 0;
            }
        }

        private bool canClone( Type type )
        {
            return type.IsPrimitive ||
                type == typeof( Decimal ) ||
                type == typeof( String ) ||
                typeof( Barrel ).IsAssignableFrom( type ) ||
                typeof( InstalledComponent ).IsAssignableFrom( type ) ||
                typeof( Engine ).IsAssignableFrom( type ) ||
                typeof( LootContent ).IsAssignableFrom( type ) ||
                typeof( VisualEffectElement ).IsAssignableFrom( type ) ||
                typeof( Node ).IsAssignableFrom( type );
        }

        private object Clone( object value )
        {
            var type = value.GetType();
            if ( type.IsPrimitive || type == typeof( Decimal ) || type == typeof( String ) )
                return value;
            if ( value is Barrel barrel )
            {
                var serializable = barrel.Serialize();
                return new Barrel( serializable, _database );
            }
            if ( value is InstalledComponent component )
            {
                var serializable = component.Serialize();
                return new InstalledComponent( serializable, _database );
            }
            if ( value is Engine engine )
            {
                var ret = new Engine
                {
                    Position = new Vector2( engine.Position.x, engine.Position.y ),
                    Size = { Value = engine.Size.Value },
                };
                return ret;
            }
            if ( value is LootContent loot )
            {
                var serializable = loot.Serialize();
                return new LootContent( serializable, _database );
            }
            if ( value is Node node )
            {
                var serializable = node.Serialize();
                return new Node( serializable, _database );
            }
            if ( value is VisualEffectElement effect )
            {
                var serializable = effect.Serialize();
                return new VisualEffectElement( serializable, _database );
            }
            return null;
        }

        public void AddObject( object obj = null )
        {
            if ( _collection == null )
                return;

            var value = addElement( obj );

            if ( _collection.Length > ( ( curPage + 1 ) * rowsPerPage )
                || curPage != ( _collection.Length - 1 ) / rowsPerPage )
            {
                SwapPage( ( _collection.Length - 1 ) / rowsPerPage );
                _selectedRowId = ( _collection.Length - 1 ) % rowsPerPage;
                CheckRadioButton();
            }
            else
            {
                var rowId = tableLayoutPanel.RowCount;
                tableLayoutPanel.RowCount++;
                tableLayoutPanel.RowStyles.Add( new RowStyle( SizeType.AutoSize ) );
                AddRow( rowId, value );
                RebuildLayout();
                _selectedRowId++;
                CheckRadioButton();
            }

            CollectionChanged?.Invoke( this, EventArgs.Empty );
        }

        protected int _selectedItemId
        {
            set
            {
                if ( curPage != value / rowsPerPage )
                {
                    SwapPage( value / rowsPerPage );
                }
                _selectedRowId = value % rowsPerPage;
            }
            get
            {
                return _selectedRowId == -1 ? -1 : _selectedRowId + curPage * rowsPerPage;
            }
        }

        public void UpdateControls()
        {
            foreach ( Control c in _controls )
            {
                ( c as StructDataEditor )?.UpdateControls();
            }
        }

        protected int rowsPerPage = 9;

        private bool _collapseable = true;
        private bool _showNumbers = false;

        protected int _selectedRowId = -1;
        protected int curPage = 0;
        protected Array _collection;
        protected Database _database;
        private readonly List<Control> _radioButtons = new List<Control>();
        private readonly List<Control> _collapseButtons = new List<Control>();
        private readonly List<Control> _controls = new List<Control>();
        protected readonly List<bool> _collapsed = new List<bool>();

        private void JumpTo_MouseClick( object sender, MouseEventArgs e )
        {
            var result = Prompt.ShowDialog( "Enter Page Number", "", "" );
            int id = 0;

            try
            {
                id = Convert.ToInt32( result );
            }
            catch ( Exception )
            {
                MessageBox.Show( "Incorrect page id, perhaps it does not exist, or the number is incorrect." );
                return;
            }

            if ( ( id - 1 ) * rowsPerPage > _collection.Length ) return;
            SwapPage( id - 1 );
        }
    }
}