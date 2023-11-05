using System.Collections.Generic;
using _Project.Scripts.Core.Collections;
using _Project.Scripts.Core.Grid.Helpers;

namespace _Project.Scripts.Core.Grid
{
    public class GridCellNeighbourManager
    {
        private readonly GridCell _cell;

        private readonly Dictionary<Directions, GridCell> _neighbors;
        public GridCellNeighbourManager(GridCell cell)
        {
            _cell = cell;

            _neighbors = new Dictionary<Directions, GridCell>
            {
                {Directions.Center, null},
                {Directions.Right, null},
                {Directions.Left, null},
                {Directions.Top, null},
                {Directions.Bottom, null},
            };
        }

        public void FindNeighbours()
        {
            for (var i = 0; i < _neighbors.Count; i++)
            {
                _neighbors[(Directions)i] = DirectionHelper.GetNeighborCellAt((Directions)i, _cell);
            }
        }

        public GridCell GetNeighbour(Directions direction)
        {
            return _neighbors[direction];
        }

        public bool IsMatched(Directions direction)
        {
            var neighbor = GetNeighbour(direction);
            return neighbor != null && _cell.IsMatchableWith(neighbor);
        }
    }
}
