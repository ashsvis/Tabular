using System;

namespace Spreadsheets
{
    public delegate void CellTextEventHandler(object sender, CellTextEventArgs e);
    public delegate void RowHeaderEventHandler(object sender, CellTextEventArgs e);
    public delegate void ColumnHeaderEventHandler(object sender, CellTextEventArgs e);

    public class CellTextEventArgs : EventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string Text { get; set; }
    }
}