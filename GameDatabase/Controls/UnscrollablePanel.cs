using System.Drawing;
using System.Windows.Forms;
using static GameDatabase.Reusables;

namespace GameDatabase
{
    class UnscrollablePanel : Panel
    {
        protected override Point ScrollToControl( Control activeControl )
        {
            return this.AutoScrollPosition;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UnscrollablePanel
            // 
            this.BackColor = MainWindow.BackgroundColor;
            this.Font = new System.Drawing.Font( "Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0 );
            this.ForeColor = MainWindow.FontColor;
            this.ResumeLayout( false );
        }
    }
}