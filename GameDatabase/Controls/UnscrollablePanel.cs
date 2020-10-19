
using System.Drawing;
using System.Windows.Forms;

namespace GameDatabase
{
    class UnscrollablePanel : Panel
    {
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }
    }
}
