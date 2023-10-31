using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EditorDatabase;
using EditorDatabase.DataModel;
using EditorDatabase.Enums;

namespace GameDatabase.Controls
{
    public partial class LayoutInfo : Form
    {
        public LayoutEditor _layout { get; set; }
        public Ship _shipData { get; set; }
        public Database _database { get; set; }

        private Label CellsNum;
        private Dictionary<CellType, Label> Sizes;
        private Label BaseArmor;
        private Label BaseWeigth;
        private Label MinWeigth;
        private Label BaseEnergyResistance;
        private Label BaseKineticResistance;
        private Label BaseHeatResistance;
        private Label CreditsCost;
        private Label StarCost;
        private Label MinSpawnDistance;

        public LayoutInfo()
        {
            InitializeComponent();
            tableLayoutPanel.RowCount = 11;

            tableLayoutPanel.SuspendLayout();
            for ( var i = 0; i <= tableLayoutPanel.RowCount; ++i )
                tableLayoutPanel.RowStyles.Add( new RowStyle( SizeType.AutoSize ) );

            var lastRow = 0;

            CreateLabel( "Cells Number", 0, lastRow );
            CellsNum = CreateLabel( "-", 1, lastRow++ );

            Sizes = new Dictionary<CellType, Label>();

            foreach ( var type in ( CellType[] ) Enum.GetValues( typeof( CellType ) ) )
            {
                var name = _nameOf( type );
                if ( string.IsNullOrEmpty( name ) ) continue;
                CreateLabel( $"{name} cells count", 0, lastRow );
                Sizes[type] = CreateLabel( "-", 1, lastRow++ );
            }

            CreateLabel( "HP", 0, lastRow );
            BaseArmor = CreateLabel( "-", 1, lastRow++ );

            CreateLabel( "Default Weight", 0, lastRow );
            BaseWeigth = CreateLabel( "-", 1, lastRow++ );

            CreateLabel( "Minimal Weight", 0, lastRow );
            MinWeigth = CreateLabel( "-", 1, lastRow++ );

            CreateLabel( "Energy Resistance", 0, lastRow );
            BaseEnergyResistance = CreateLabel( "-", 1, lastRow++ );

            CreateLabel( "Kinetic Resistance", 0, lastRow );
            BaseKineticResistance = CreateLabel( "-", 1, lastRow++ );

            CreateLabel( "Heat Resistance", 0, lastRow );
            BaseHeatResistance = CreateLabel( "-", 1, lastRow++ );

            CreateLabel( "Crafting Credits Cost", 0, lastRow );
            CreditsCost = CreateLabel( "-", 1, lastRow++ );

            CreateLabel( "Crafting Stars Cost", 0, lastRow );
            StarCost = CreateLabel( "-", 1, lastRow++ );

            CreateLabel( "Minimal Wandering Ship Distance", 0, lastRow );
            MinSpawnDistance = CreateLabel( "-", 1, lastRow++ );

            tableLayoutPanel.ResumeLayout();
        }

        private string _nameOf( CellType type )
        {
            switch ( type )
            {
                case CellType.Outer:
                    return "Blue";
                case CellType.Inner:
                    return "Green";
                case CellType.InnerOuter:
                    return "Blue/Green";
                case CellType.Engine:
                    return "Engine";
                case CellType.Weapon:
                    return "Weapon";
                default:
                    return string.Empty;
            }
        }

        public void OnLayoutChanged()
        {
            tableLayoutPanel.SuspendLayout();

            string data = _layout.Layout;

            int size = data.Replace( "0", "" ).Length;
            CellsNum.Text = size.ToString();


            string layoutOnly = data.Replace( "0", "" );
            foreach ( var type in ( CellType[] ) Enum.GetValues( typeof( CellType ) ) )
            {
                Label control;
                if ( Sizes.TryGetValue( type, out control ) )
                {
                    control.Text = ( layoutOnly.Length - layoutOnly.Replace( ( ( char ) type ).ToString(), "" ).Length ).ToString();
                }
            }

            var armor = ( _database.ShipSettings.BaseArmorPoints.Value + _database.ShipSettings.ArmorPointsPerCell.Value * size ) * ( _shipData.Features.ArmorBonus.Value == 0 ? 1 : 1 + _shipData.Features.ArmorBonus.Value ) ;
            BaseArmor.Text = armor.ToString( "0.00" );

            BaseWeigth.Text = ( _database.ShipSettings.DefaultWeightPerCell.Value * size * ( 1 + _shipData.Features.WeightBonus.Value ) ).ToString( "0.0" );

            MinWeigth.Text = ( _database.ShipSettings.MinimumWeightPerCell.Value * size * ( 1 + _shipData.Features.WeightBonus.Value ) ).ToString( "0.0" );

            BaseEnergyResistance.Text = CalculateResistances( _shipData.Features.EnergyResistance.Value ).ToString( "0.00" );
            BaseKineticResistance.Text = CalculateResistances( _shipData.Features.KineticResistance.Value ).ToString( "0.00" );
            BaseHeatResistance.Text = CalculateResistances( _shipData.Features.HeatResistance.Value ).ToString( "0.00" );


            // ShipCategory and ShipCategory.Flagship don't exist anymore. What to put here?

            //  long cost;
            //  if ( _shipData.ShipType == ShipCategory.Flagship ) cost = checked(15 * size * size);
            //  else cost = checked(5 * size * size);

            //   CreditsCost.Text = cost.ToString();
            CreditsCost.Text = "Need new formula since 1.10.0";

            long starcost;
            /*    switch ( _shipData.ShipCategory )
                {
                    case ShipCategory.Common:
                        starcost = cost / 48000;
                        break;
                    case ShipCategory.Rare:
                        starcost = cost / 6000;
                        break;
                    case ShipCategory.Flagship:
                        starcost = ( int ) Math.Floor( armor / 5 );
                        break;
                    default:
                        starcost = -1;
                        break;
                }
                if ( starcost >= 0 )
                {
                    StarCost.Text = starcost.ToString();
                }
                else
                {
                    StarCost.Text = "-";
                }
            */
            StarCost.Text = "Need new formula since 1.10.0";
            MinSpawnDistance.Text = Math.Max( ( size - 55 ) / 2, 0 ).ToString();

            tableLayoutPanel.ResumeLayout();
        }

        private float CalculateResistances( float number )
        {
            return 100 - 100 / ( number + 1 );
        }

        private Label CreateLabel( string text, int column, int row )
        {
            var label = new Label()
            {
                Text = text,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left,
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill,
                AutoSize = true,
            };

            tableLayoutPanel.Controls.Add( label, column, row );
            return label;
        }
    }
}