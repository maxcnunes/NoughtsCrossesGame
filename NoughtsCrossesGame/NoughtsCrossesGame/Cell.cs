using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoughtsCrossesGame
{
    public class Cell
    {
        public TypeShape? MarkedBy { get; set; }
        public enum TypeShape { Cross, Circle }

        public bool IsMarked()
        {
            return MarkedBy != null;
        }

        public void Mark(TypeShape typeShape)
        {
            if (IsMarked())
                throw new Exception("This cell is already marked.");

            MarkedBy = typeShape;
        }

        public bool IsValidMarked(Cell.TypeShape typeShape)
        {
            return IsMarked() && (MarkedBy == typeShape);
        }
    }
}
