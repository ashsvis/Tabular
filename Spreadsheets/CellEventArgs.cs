using GridModel.Cells;
using System;

namespace Spreadsheets
{
    public delegate void CellEventHandler(object sender, CellEventArgs e);

    public class CellEventArgs : EventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Cell Cell { get; set; }
    }
}