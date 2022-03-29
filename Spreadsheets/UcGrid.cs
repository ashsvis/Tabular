using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Spreadsheets
{
    public partial class UcGrid : UserControl
    {
        private object[,] grid = new object[1000, 1000];

        public UcGrid()
        {
            InitializeComponent();
            grid[4, 8] = "test";
        }

        private void ucGrid_Resize(object sender, EventArgs e)
        {
            
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            gridPanel.LeftColumn = hScrollBar1.Value;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            gridPanel.TopRow = vScrollBar1.Value;
        }
    }


}
