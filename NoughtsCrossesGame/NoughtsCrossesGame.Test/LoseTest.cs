using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoughtsCrossesGame.Test
{
    [TestClass]
    public class LoseTest
    {
        [TestMethod]
        public void Should_Lose_When_Not_Complete_Horizontal_Sequence_First_Row()
        {
            Grid grid = new Grid();

            //Mark all cell of the first row, less the last cell
            for (int columnIndex = 0; columnIndex < (grid.ColumnsLength - 1); columnIndex++)
                grid.MarkCellByPosition(0, columnIndex, Cell.TypeShape.Circle);

            Assert.IsFalse(grid.IsHorizontalSequenceCompletedOfSameShapeByRow(0, Cell.TypeShape.Circle));
        }

        [TestMethod]
        public void Should_Lose_When_Not_Complete_Horizontal_Sequence_Any_Row()
        {
            Grid grid = new Grid();

            //Mark all cell of each row, less the last cell
            for (int rowIndex = 0; rowIndex < grid.RowsLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < (grid.ColumnsLength - 1); columnIndex++)
                    grid.MarkCellByPosition(rowIndex, columnIndex, Cell.TypeShape.Circle);

                Assert.IsFalse(grid.IsHorizontalSequenceCompletedOfSameShapeByRow(rowIndex, Cell.TypeShape.Circle));
            }
        }

        [TestMethod]
        public void Should_Lose_When_Not_Complete_Vertical_Sequence_First_Column()
        {
            Grid grid = new Grid();

            // First Column
            var columnIndex = 0;

            //Mark all cell of the first column, less the last cell
            for (int rowIndex = 0; rowIndex < (grid.RowsLength -1); rowIndex++)
                grid.MarkCellByPosition(rowIndex, columnIndex, Cell.TypeShape.Circle);

            Assert.IsFalse(grid.IsVerticalSequenceCompletedOfSameShapeByColumn(columnIndex, Cell.TypeShape.Circle));
        }

        [TestMethod]
        public void Should_Lose_When_Not_Complete_Vertical_Sequence_Any_Column()
        {
            Grid grid = new Grid();

            //Mark all cell of each column, less the last cell
            for (int columnIndex = 0; columnIndex < grid.ColumnsLength; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < (grid.RowsLength - 1); rowIndex++)
                    grid.MarkCellByPosition(rowIndex, columnIndex, Cell.TypeShape.Circle);

                Assert.IsFalse(grid.IsVerticalSequenceCompletedOfSameShapeByColumn(columnIndex, Cell.TypeShape.Circle));
            }
        }

        [TestMethod]
        public void Should_Lose_When_Complete_Diagonal_Sequence_LeftTopToRightBottom()
        {
            Grid grid = new Grid();
            int rowIndex = 0;

            //Mark all cell in diagonal left top to right bottom, less the last cell
            for (int columnIndex = 0; columnIndex < (grid.ColumnsLength - 1); columnIndex++)
            {
                grid.MarkCellByPosition(rowIndex, columnIndex, Cell.TypeShape.Circle);
                rowIndex++;
            }

            Assert.IsFalse(grid.IsDiagonalSequenceCompletedOfSameShapeByDirection(Grid.DiagonalDirection.LeftTopToRightBottom, Cell.TypeShape.Circle));
        }

        [TestMethod]
        public void Should_Win_When_Complete_Diagonal_Sequence_RightTopToLeftBottom()
        {
            Grid grid = new Grid();
            int rowIndex = 0;

            //Mark all cell in diagonal left top to right bottom, less the last cell
            for (int columnIndex = (grid.ColumnsLength - 1); columnIndex > 0; columnIndex--)
            {
                grid.MarkCellByPosition(rowIndex, columnIndex, Cell.TypeShape.Circle);
                rowIndex++;
            }

            Assert.IsFalse(grid.IsDiagonalSequenceCompletedOfSameShapeByDirection(Grid.DiagonalDirection.RightTopToLeftBottom, Cell.TypeShape.Circle));
        }
    }
}
