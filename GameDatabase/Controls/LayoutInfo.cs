using EditorDatabase;
using EditorDatabase.DataModel;
using EditorDatabase.Enums;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Windows.Forms;

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
            for (var i = 0; i <= tableLayoutPanel.RowCount; ++i)
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var lastRow = 0;

            CreateLabel("Cells Number", 0, lastRow);
            CellsNum = CreateLabel("-", 1, lastRow++);

            Sizes = new Dictionary<CellType, Label>();

            foreach (var type in (CellType[])Enum.GetValues(typeof(CellType)))
            {
                var name = _nameOf(type);
                if (string.IsNullOrEmpty(name)) continue;
                CreateLabel($"{name} cells count", 0, lastRow);
                Sizes[type] = CreateLabel("-", 1, lastRow++);
            }

            CreateLabel("HP", 0, lastRow);
            BaseArmor = CreateLabel("-", 1, lastRow++);

            CreateLabel("Default Weight", 0, lastRow);
            BaseWeigth = CreateLabel("-", 1, lastRow++);

            CreateLabel("Minimal Weight", 0, lastRow);
            MinWeigth = CreateLabel("-", 1, lastRow++);

            CreateLabel("Energy Resistance", 0, lastRow);
            BaseEnergyResistance = CreateLabel("-", 1, lastRow++);

            CreateLabel("Kinetic Resistance", 0, lastRow);
            BaseKineticResistance = CreateLabel("-", 1, lastRow++);

            CreateLabel("Heat Resistance", 0, lastRow);
            BaseHeatResistance = CreateLabel("-", 1, lastRow++);

            CreateLabel("Crafting Credits Cost", 0, lastRow);
            CreditsCost = CreateLabel("-", 1, lastRow++);

            CreateLabel("Crafting Stars Cost", 0, lastRow);
            StarCost = CreateLabel("-", 1, lastRow++);

            CreateLabel("Minimal Wandering Ship Distance", 0, lastRow);
            MinSpawnDistance = CreateLabel("-", 1, lastRow++);

            tableLayoutPanel.ResumeLayout();
        }

        private string _nameOf(CellType type)
        {
            switch (type)
            {
                case CellType.Blue:
                    return "Blue";
                case CellType.Green:
                    return "Green";
                case CellType.Cyan:
                    return "Blue/Green";
                case CellType.Engine:
                    return "Engine";
                case CellType.Weapon:
                    return "Weapon";
                default:
                    return string.Empty;
            }
        }

        public long CraftingPrice( Ship ship)
        {
            int price = (int)ship.Layout.CellCount * ship.Layout.CellCount * 5;

            if (ship.SizeClass == SizeClass.Titan)
                return price * 3;
            else if (ship.ShipRarity == ShipRarity.Rare)
                return 3 * price / 2;
            else
                return price;
        }

        public long CraftingStars( Ship ship)
        {
            if (ship.SizeClass == SizeClass.Titan)
                return ship.Layout.CellCount / 10;
            else if (ship.ShipRarity == ShipRarity.Rare)
                return 1 + (ship.Layout.CellCount - 30) / 10;
            else
                return ship.Layout.CellCount / 70;
        }

        public void OnLayoutChanged()
        {
            bool featuresNull = false;
            if (_shipData.Features.Value != null || _shipData.Features != null || _shipData.Features.CurrentValue != null)
            {
                featuresNull = true;
            }

            tableLayoutPanel.SuspendLayout();

            string data = _layout.Layout;

            int size = data.Replace("0", "").Length;
            CellsNum.Text = (size.ToString() + (featuresNull ? "\n\n FOR ACCURATE STATS ADD A FEATURES FIELD\n\n" : ""));

            string layoutOnly = data.Replace("0", "");
            foreach (var type in (CellType[])Enum.GetValues(typeof(CellType)))
            {
                Label control;
                if (Sizes.TryGetValue(type, out control))
                {
                    control.Text = (layoutOnly.Length - layoutOnly.Replace(((char)type).ToString(), "").Length).ToString();
                }
            }

            CreditsCost.Text = CraftingPrice(_shipData).ToString();

            if (_shipData.Features.Value != null && _shipData.Features != null && _shipData.Features.CurrentValue != null)
            {
                var armor = (_database.ShipSettings.BaseArmorPoints.Value + _database.ShipSettings.ArmorPointsPerCell.Value * size) * (_shipData.Features.Value.ArmorBonus.Value == 0 ? 1 : 1 + _shipData.Features.Value.ArmorBonus.Value);
                BaseArmor.Text = armor.ToString("0.00");

                BaseWeigth.Text = (_database.ShipSettings.DefaultWeightPerCell.Value * size * (1 + _shipData.Features.Value.ShipWeightBonus.Value)).ToString("0.0");

                MinWeigth.Text = (_database.ShipSettings.MinimumWeightPerCell.Value * size * (1 + _shipData.Features.Value.ShipWeightBonus.Value)).ToString("0.0");
                BaseEnergyResistance.Text = CalculateResistances(_shipData.Features.Value.EnergyResistance.Value).ToString("0.00");
                BaseKineticResistance.Text = CalculateResistances(_shipData.Features.Value.KineticResistance.Value).ToString("0.00");
                BaseHeatResistance.Text = CalculateResistances(_shipData.Features.Value.HeatResistance.Value).ToString("0.00");
            }
            else
            {
                var armor = (_database.ShipSettings.BaseArmorPoints.Value + 0 * size) * (1 + 0);
                BaseArmor.Text = armor.ToString("0.00");

                BaseWeigth.Text = (_database.ShipSettings.DefaultWeightPerCell.Value * size * (1 + 0)).ToString("0.0");

                MinWeigth.Text = (_database.ShipSettings.MinimumWeightPerCell.Value * size * (1 + 0)).ToString("0.0");
                BaseEnergyResistance.Text = CalculateResistances(0).ToString("0.00");
                BaseKineticResistance.Text = CalculateResistances(0).ToString("0.00");
                BaseHeatResistance.Text = CalculateResistances(0).ToString("0.00");
            }

            long starcost;

            StarCost.Text = CraftingStars(_shipData).ToString();
            MinSpawnDistance.Text = Math.Max((size - 55) / 2, 0).ToString();

            tableLayoutPanel.ResumeLayout();
        }

        private float CalculateResistances(float number)
        {
            return 100 - 100 / (number + 1);
        }

        private Label CreateLabel(string text, int column, int row)
        {
            var label = new Label()
            {
                Text = text,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left,
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill,
                AutoSize = true,
            };

            tableLayoutPanel.Controls.Add(label, column, row);
            return label;
        }

    }
}