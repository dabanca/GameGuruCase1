using System;
using _Project.Scripts.Core.Collections;
using _Project.Scripts.Core.Grid.RuntimeData;

namespace _Project.Scripts.Core.Grid.Helpers
{
    public static class DirectionHelper
    {
        public static GridCell GetNeighborCellAt(Directions direction, GridCell gridCell)
        {
            return direction switch
            {
                Directions.Center => gridCell,
                
                Directions.Right => gridCell.Coordinates.x == GridData.Size.x - 1 ? null
                    : GridData.GetCell(gridCell.Coordinates.x + 1, gridCell.Coordinates.y),
                
                Directions.Top => gridCell.Coordinates.y ==  GridData.Size.y - 1 ? null
                    : GridData.GetCell(gridCell.Coordinates.x, gridCell.Coordinates.y + 1),
                
                Directions.Left => gridCell.Coordinates.x == 0 ? null
                    : GridData.GetCell(gridCell.Coordinates.x - 1, gridCell.Coordinates.y),
                
                Directions.Bottom => gridCell.Coordinates.y == 0 ? null
                    : GridData.GetCell(gridCell.Coordinates.x, gridCell.Coordinates.y - 1),
                
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}