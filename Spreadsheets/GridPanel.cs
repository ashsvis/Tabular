﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Spreadsheets
{
    public partial class GridPanel : Control
    {
        private int defaultColumnWidth = 90;
        private int defaultRowHeight = 20;
        private int topRow;
        private int leftColumn;

        public int TopRow 
        { 
            get => topRow;
            set
            {
                topRow = value;
                Invalidate();
            }
        }

        public int LeftColumn 
        { 
            get => leftColumn; 
            set 
            { 
                leftColumn = value; 
                Invalidate(); 
            }
        }

        public GridPanel()
        {
            InitializeComponent();
            SetControlStyle();
        }

        public GridPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            SetControlStyle();
        }

        private void SetControlStyle()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }

        public int RowVisibleCount
        {
            get { return ClientRectangle.Height / defaultRowHeight + 1; }
        }

        public int ColumnVisibleCount
        {
            get { return ClientRectangle.Width / defaultColumnWidth + 1; }
        }

        private void GridPanel_Paint(object sender, PaintEventArgs e)
        {
            var area = ClientRectangle;
            area.Size = new Size(area.Width - 1, area.Height - 1);
            var gr = e.Graphics;
            // рабочая область
            gr.FillRectangle(SystemBrushes.AppWorkspace, area);
            // вывод сетки
            var rect = new Rectangle(area.Location, new Size(defaultColumnWidth, defaultRowHeight));
            for (var row = topRow; row < RowVisibleCount + topRow; row++)
            {
                for (var col = leftColumn; col < ColumnVisibleCount + leftColumn; col++)
                {
                    if (ClientRectangle.IntersectsWith(rect))
                    {
                        gr.FillRectangle(SystemBrushes.Window, rect);
                        gr.DrawRectangle(SystemPens.WindowFrame, rect);
                        var arg = new CellTextEventArgs() { Row = row, Column = col };
                        if (row == topRow && col == leftColumn)
                        {

                        }
                        else if (col == leftColumn)
                            onRowHeaderText?.Invoke(this, arg);
                        else if (row == topRow)
                            onColumnHeaderText?.Invoke(this, arg);
                        else
                            onCellText?.Invoke(this, arg);
                        using (var drawFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                            gr.DrawString(arg.Text, SystemFonts.CaptionFont, SystemBrushes.WindowText, rect, drawFormat);
                    }
                    rect.Offset(rect.Width, 0);
                }
                rect.Offset(0, rect.Height);
                rect.X = area.Left;
            }
            // внешняя рамка
            gr.DrawRectangle(SystemPens.WindowFrame, area);
        }

        private event CellTextEventHandler onCellText;

        public event CellTextEventHandler OnCellText
        {
            add
            {
                onCellText += value;
            }
            remove
            {
                onCellText -= value;
            }
        }

        private event RowHeaderEventHandler onRowHeaderText;

        public event RowHeaderEventHandler OnRowHeaderText
        {
            add
            {
                onRowHeaderText += value;
            }
            remove
            {
                onRowHeaderText -= value;
            }
        }

        private event ColumnHeaderEventHandler onColumnHeaderText;

        public event ColumnHeaderEventHandler OnColumnHeaderText
        {
            add
            {
                onColumnHeaderText += value;
            }
            remove
            {
                onColumnHeaderText -= value;
            }
        }
    }
}
