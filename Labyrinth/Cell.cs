using System.Drawing;

namespace LabyrinthNS
{
    enum CellState { Close, Open };
    class Cell
    {
        public Cell(Point currentPosition)
        {
            Visited = false;
            Position = currentPosition;
        }

        public CellState Left { get; set; }
        public CellState Right { get; set; }
        public CellState Bottom { get; set; }
        public CellState Top { get; set; }
        public bool Visited { get; set; }
        public Point Position { get; set; }
    }
}

