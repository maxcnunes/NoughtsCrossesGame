using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace NoughtsCrossesGame.Test
{
    [TestClass]
    public class GridTest
    {
        [TestMethod]
        public void Should_Start_Empty()
        {
            Grid grid = new Grid();
            bool hasLessOneMarked = false;


            for (int rowIndex = 0; rowIndex < grid.RowsLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < grid.ColumnsLength; columnIndex++)
                {
                    if (grid.IsCellMarkedByPosition(rowIndex, columnIndex))
                    {
                        hasLessOneMarked = true;
                        break;
                    }
                }
            }

            Assert.IsFalse(hasLessOneMarked);
        }

        [TestMethod]
        public void Can_Mark_The_First_Cell()
        {
            Grid grid = new Grid();

            grid.MarkCellByPosition(0, 0, Cell.TypeShape.Circle);

            var isMarked = grid.IsCellMarkedByPosition(0, 0);

            Assert.IsTrue(isMarked);
        }

        [TestMethod]
        public void Can_Mark_All_Cells()
        {
            Grid grid = new Grid();
            bool allCellsWereMarked = true;

            //Mark All
            for (int rowIndex = 0; rowIndex < grid.RowsLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < grid.ColumnsLength; columnIndex++)
                {
                    grid.MarkCellByPosition(rowIndex, columnIndex, Cell.TypeShape.Circle);
                }
            }

            //Check All
            for (int rowIndex = 0; rowIndex < grid.RowsLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < grid.ColumnsLength; columnIndex++)
                {
                    if (!grid.IsCellMarkedByPosition(rowIndex, columnIndex))
                    {
                        allCellsWereMarked = false;
                        break;
                    }
                }
            }

            Assert.IsTrue(allCellsWereMarked);
        }

        [TestMethod, ExpectedException(typeof(System.Exception))]
        public void Should_Not_Mark_Any_Marked_Cell()
        {
            Grid grid = new Grid();

            //Marke first cell
            grid.MarkCellByPosition(0, 0, Cell.TypeShape.Circle);

            //Try mark the first cell again
            grid.MarkCellByPosition(0, 0, Cell.TypeShape.Circle);
        }
    }
}
