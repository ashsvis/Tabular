using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ObjGrid
{
    public partial class UcGrid : UserControl
    {
        Hashtable grid;
        Hashtable columns;
        int rowIndex = -1;
        int colIndex = -1;
        private int _defaultColumnWidth = 90;
        private int _defaultRowHeight = 20;
        private int _rowCount = 3;
        private int _columnCount = 3;
        private int _fixedRowCount = 1;
        private int _fixedColumnCount = 1;

        [DefaultValue(1)]
        public int FixedRowCount
        {
            get => _fixedRowCount;
            set
            {
                _fixedRowCount = value;
                Invalidate();
            }
        }

        [DefaultValue(1)]
        public int FixedColumnCount
        {
            get => _fixedColumnCount;
            set
            {
                _fixedColumnCount = value;
                Invalidate();
            }
        }

        [DefaultValue(3)]
        public int RowCount
        {
            get => _rowCount;
            set
            {
                if (value < 1 || _rowCount == value) return;
                var oldGrid = grid;
                grid = new Hashtable();
                foreach (var key in oldGrid.Keys.Cast<CellIndex>().Where(x => x.Row < value).ToList())
                {
                    grid[key] = oldGrid[key];
                    oldGrid.Remove(key);
                }
                GC.Collect();
                _rowCount = value;
                Invalidate();
            }
        }

        [DefaultValue(3)]
        public int ColumnCount
        {
            get => _columnCount;
            set
            {
                if (value < 1 || _columnCount == value) return;
                var oldGrid = grid;
                var oldColumns = columns;
                grid = new Hashtable();
                columns = new Hashtable();
                foreach (var key in oldGrid.Keys.Cast<CellIndex>().Where(x => x.Column < value).ToList())
                {
                    grid[key] = oldGrid[key];
                    oldGrid.Remove(key);
                }
                GC.Collect();
                foreach (var key in oldColumns.Keys.Cast<ColumnIndex>().Where(x => x.Column < value).ToList())
                {
                    columns[key] = oldColumns[key];
                    oldColumns.Remove(key);
                }
                GC.Collect();
                // добавление настроек для новых столбцов
                for (var j = _columnCount; j < value; j++)
                {
                    columns[GetColumnIndex(j)] = new ColumnHeader
                    {
                        Width = _defaultColumnWidth,
                        CellIndex = GetCellIndex(0, j)
                    };
                }
                _columnCount = value;
                Invalidate();
            }
        }

        [DefaultValue(20)]
        public int DefaultRowHeight
        {
            get => _defaultRowHeight;
            set
            {
                if (value < 0) return;
                _defaultRowHeight = value;
                Invalidate();
            }
        }

        [DefaultValue(90)]
        public int DefaultColumnWidth
        {
            get => _defaultColumnWidth;
            set
            {
                if (value < 0) return;
                _defaultColumnWidth = value;
                Invalidate();
            }
        }

        public UcGrid()
        {
            InitializeComponent();
            DoubleBuffered = true;
            columns = new Hashtable();
            for (var j = 0; j < _columnCount; j++)
            {
                columns[GetColumnIndex(j)] = new ColumnHeader
                {
                    Text = null,
                    Width = _defaultColumnWidth,
                    CellIndex = GetCellIndex(0, j)
                };
            }
            grid = new Hashtable();
            for (var i = 0; i < _rowCount; i++)
            {
                var isFixedRow = i < _fixedRowCount;
                for (var j = 0; j < _columnCount; j++)
                {
                    if (i == 0 && j == 0) continue;
                    if (isFixedRow)
                    {
                        grid[GetCellIndex(i, j)] = $"{columns[GetColumnIndex(j)]}";
                    }
                    else
                    {
                        var isFixedColumn = j < _fixedColumnCount;
                        grid[GetCellIndex(i, j)] = null;
                    }
                }
            }
        }

        private CellIndex GetCellIndex(int i, int j)
        {
            return new CellIndex { Row = i, Column = j };
        }

        private ColumnIndex GetColumnIndex(int j)
        {
            return new ColumnIndex { Column = j };
        }

        private void ucGrid_Paint(object sender, PaintEventArgs e)
        {
            var area = ClientRectangle;
            area.Size = new Size(area.Width - 1, area.Height - 1);
            var gr = e.Graphics;
            // рабочая область
            gr.FillRectangle(SystemBrushes.AppWorkspace, area);
            // вывод сетки
            var rect = new Rectangle(area.Location, new Size(DefaultColumnWidth, DefaultRowHeight));
            try
            {
                var i = 0;
                while (i < _rowCount)
                {
                    var j = 0;
                    while (j < _columnCount)
                    {
                        if (ClientRectangle.IntersectsWith(rect))
                        {
                            var isSelectedCell = i == rowIndex && j == colIndex;
                            var isFixedCell = i < _fixedRowCount || j < _fixedColumnCount;
                            var fillCellColor = SystemBrushes.Window;
                            if (isFixedCell)
                                fillCellColor = SystemBrushes.Control;
                            if (isSelectedCell)
                            {
                                fillCellColor = SystemBrushes.Highlight;
                                if (isFixedCell)
                                    fillCellColor = SystemBrushes.ControlDark;
                            }
                            gr.FillRectangle(fillCellColor, rect);
                            gr.DrawRectangle(SystemPens.WindowFrame, rect);
                            using (var drawFormat = new StringFormat
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center
                            })
                            {
                                var index = GetCellIndex(i, j);
                                if (grid.ContainsKey(index))
                                    gr.DrawString($"{grid[index]}", SystemFonts.CaptionFont,
                                        isSelectedCell ? SystemBrushes.HighlightText : SystemBrushes.WindowText, 
                                        rect, drawFormat);
                            }
                        }
                        // сместить на один столбец вправо
                        rect.Offset(rect.Width, 0);
                        j++;
                    }
                    // сместить на одну строку вниз
                    rect.Offset(0, rect.Height);
                    // сместить влево в начало 
                    rect.X = area.Left;
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // внешняя рамка
            gr.DrawRectangle(SystemPens.WindowFrame, area);
        }

        private void ucGrid_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void ucGrid_MouseDown(object sender, MouseEventArgs e)
        {
            var area = ClientRectangle;
            var point = e.Location;
            rowIndex = point.Y / DefaultRowHeight;
            colIndex = point.X / DefaultColumnWidth;

            Invalidate();
        }

        private void UcGrid_MouseUp(object sender, MouseEventArgs e)
        {
            var area = ClientRectangle;
            var point = e.Location;
            rowIndex = point.Y / DefaultRowHeight;
            colIndex = point.X / DefaultColumnWidth;

            Invalidate();
        }
    }

    public struct CellIndex
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public override string ToString()
        {
            return $"R[{Row}]C[{Column}]"; ;
        }
    }

    public struct ColumnIndex
    {
        public int Column { get; set; }

        public override string ToString()
        {
            return $"C[{Column}]"; ;
        }
    }

    public class ColumnHeader
    {
        public CellIndex CellIndex { get; set; }
        public string Text { get; set; }
        public int Width { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

}
