using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spreadsheets
{
    public partial class UcGrid : UserControl
    {
        public UcGrid()
        {
            InitializeComponent();
            hScrollBar1.Maximum = 65535;
            vScrollBar1.Maximum = 65535;
            gridPanel.OnCell += GridPanel_OnGetCell;
            // вызываем принудительный пересчёт при старте
            ucGrid_Resize(this, EventArgs.Empty);
        }

        private void GridPanel_OnGetCell(object sender, CellEventArgs e)
        {
            if (e.Column > hScrollBar1.Maximum || e.Row > vScrollBar1.Maximum)
                return;
            var cell = new GridModel.Cells.Cell();
            if (e.Row == gridPanel.TopRow && e.Column == gridPanel.LeftColumn)
            {
                cell.Style.FillStyle.Color = SystemColors.Control;
            }
            else if (e.Row == gridPanel.TopRow && e.Column > gridPanel.LeftColumn)
            {
                cell.Text = $"{e.Column}";
                cell.Style.FillStyle.Color = SystemColors.Control;
                cell.Style.TextStyle.Alignment = StringAlignment.Center;
            }
            else if (e.Column == gridPanel.LeftColumn && e.Row > gridPanel.TopRow)
            {
                cell.Text = $"{e.Row}";
                cell.Style.FillStyle.Color = SystemColors.Control;
                cell.Style.TextStyle.Alignment = StringAlignment.Center;
            }
            e.Cell = cell;
        }

        /// <summary>
        /// При изменении размера корректируется значений больших приращений скроллеров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucGrid_Resize(object sender, EventArgs e)
        {
            hScrollBar1.LargeChange = Math.Max(gridPanel.ColumnVisibleCount - 2, 1);
            vScrollBar1.LargeChange = Math.Max(gridPanel.RowVisibleCount - 2, 1);
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
