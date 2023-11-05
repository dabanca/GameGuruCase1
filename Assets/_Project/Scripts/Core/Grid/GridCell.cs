using _Project.Scripts.Core.Collections;
using _Project.Scripts.Core.Match;
using UnityEngine;

namespace _Project.Scripts.Core.Grid
{
    public class GridCell
    {
        private GridType _gridType;
        private readonly GridCellNeighbourManager _gridCellNeighbourManager;
        private GridItem.GridItem _gridItem;
        public Vector2Int Coordinates { get; private set; }
        public void SetCoordinate(int x, int y) => Coordinates = new Vector2Int(x, y);
        public void SetGridItemToCell(GridItem.GridItem gridItem) => _gridItem = gridItem;
        public GridCell(GridType gridType)
        {
            _gridType = gridType;
            _gridCellNeighbourManager = new GridCellNeighbourManager(this);
        }
        public void FindNeighbours()=> _gridCellNeighbourManager.FindNeighbours();
        public GridCell GetNeighbour(Directions direction) => _gridCellNeighbourManager.GetNeighbour(direction);
        public bool IsMatched(Directions direction) => _gridCellNeighbourManager.IsMatched(direction);
        public bool IsMatchableWith(GridCell cell)
        {
            if (_gridItem.GridItemType == GridItemType.Basic) return false;
                return cell._gridItem.GridItemType == _gridItem.GridItemType;
        }
        public void Match()
        {
            if(_gridItem.GridItemView is IMatchable matchable) matchable.Match();
        }
    }
}

