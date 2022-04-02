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
            hScrollBar1.Maximum = 65535;
            vScrollBar1.Maximum = 65535;
            //gridPanel.OnColumnHeaderText += GridPanel_OnColumnHeaderText;
            //gridPanel.OnRowHeaderText += GridPanel_OnRowHeaderText;
            //gridPanel.OnCellText += GridPanel_OnGetCellText;
            gridPanel.OnCell += GridPanel_OnGetCell;
            // вызываем принудительный пересчёт при старте
            ucGrid_Resize(this, EventArgs.Empty);
        }

        private void GridPanel_OnGetCell(object sender, CellEventArgs e)
        {
            e.Cell = new GridModel.Cells.Cell();
        }

        //private void GridPanel_OnRowHeaderText(object sender, CellTextEventArgs e)
        //{
        //    e.Text = $"R{e.Row}";
        //}

        //private void GridPanel_OnColumnHeaderText(object sender, CellTextEventArgs e)
        //{
        //    e.Text = $"C{e.Column}";
        //}

        //private void GridPanel_OnGetCellText(object sender, CellTextEventArgs e)
        //{
        //    //e.Text = $"{e.Row}.{e.Column}";
        //}

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
