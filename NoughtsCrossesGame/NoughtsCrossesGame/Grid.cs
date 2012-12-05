using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoughtsCrossesGame
{
    public class Grid
    {
        public readonly int RowsLength = 3;
        public readonly int ColumnsLength = 3;

        public Cell[,] Cells { get; set; }

        public Grid()
        {
            InitializeEachCell();
        }

        private void InitializeEachCell()
        {
            Cells = new Cell[RowsLength, ColumnsLength];

            for (int rowIndex = 0; rowIndex < RowsLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnsLength; columnIndex++)
                {
                    Cells[rowIndex, columnIndex] = new Cell();
                }
            }
        }

        public Cell GetCellByPosition(int rowIndex, int columnIndex)
        {
            return Cells[rowIndex, columnIndex];
        }

        public void MarkCellByPosition(int rowIndex, int columnIndex, Cell.TypeShape typeShape)
        {
            GetCellByPosition(rowIndex, columnIndex).Mark(typeShape);
        }

        public bool IsCellMarkedByPosition(int rowIndex, int columnIndex)
        {
            return GetCellByPosition(rowIndex, columnIndex).IsMarked();
        }

        public bool IsHorizontalSequenceCompletedOfSameShapeByRow(int rowIndex, Cell.TypeShape typeShape)
        {
            for (int columnIndex = 0; columnIndex < ColumnsLength; columnIndex++)
            {
                var cell = GetCellByPosition(rowIndex, columnIndex);

                if (!cell.IsValidMarked(typeShape))
                    return false;
            }

            return true;
        }

        public bool IsVerticalSequenceCompletedOfSameShapeByColumn(int columnIndex, Cell.TypeShape typeShape)
        {
            for (int rowIndex = 0; rowIndex < RowsLength; rowIndex++)
            {
                var cell = GetCellByPosition(rowIndex, columnIndex);

                if (!cell.IsValidMarked(typeShape))
                    return false;
            }

            return true;
        }

        public bool IsDiagonalSequenceCompletedOfSameShapeByDirection(DiagonalDirection diagonalDirection, Cell.TypeShape typeShape)
        {
            var columnIndex = (diagonalDirection == DiagonalDirection.LeftTopToRightBottom)
                                ? 0
                                : (ColumnsLength - 1);

            for (int rowIndex = 0; rowIndex < RowsLength; rowIndex++)
            {
                var cell = GetCellByPosition(rowIndex, columnIndex);

                if (!cell.IsValidMarked(typeShape))
                    return false;

                columnIndex = GetNextColumnDiagonalIndex(diagonalDirection, columnIndex);
            }

            return true;
        }

        private int GetNextColumnDiagonalIndex(DiagonalDirection diagonalDirection, int currentIndex)
        {
            if (diagonalDirection == DiagonalDirection.LeftTopToRightBottom)
                return currentIndex + 1;
            else
                return currentIndex - 1;
        }

        public enum DiagonalDirection { LeftTopToRightBottom, RightTopToLeftBottom }
    }
}
