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
        public UcGrid()
        {
            InitializeComponent();
            // вызываем принудительный пересчёт при старте
            ucGrid_Resize(this, EventArgs.Empty);
        }

        /// <summary>
        /// При изменении размера корректируется значений больших приращений скроллеров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucGrid_Resize(object sender, EventArgs e)
        {
            hScrollBar1.LargeChange = Math.Max(gridPanel.ColumnVisibleCount - 1, 1);
            vScrollBar1.LargeChange = Math.Max(gridPanel.RowVisibleCount - 1, 1);
        }

        /// <summary>
        /// Обработка событий от скроллеров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                gridPanel.LeftColumn = hScrollBar1.Value;
            else
                gridPanel.TopRow = vScrollBar1.Value;
        }
    }


}
