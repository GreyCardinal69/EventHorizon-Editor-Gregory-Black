using System.Drawing;
using System.Windows.Forms;

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
            this.BackColor = System.Drawing.Color.FromArgb( 45, 45, 45 );
            this.Font = new System.Drawing.Font( "Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0 );
            this.ForeColor = System.Drawing.Color.FromArgb( 242, 188, 87 );
            this.ResumeLayout( false );
        }
    }
}