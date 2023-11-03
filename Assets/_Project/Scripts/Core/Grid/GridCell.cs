using _Project.Scripts.Core.Collections;
using UnityEngine;

namespace _Project.Scripts.Core.Grid
{
    public class GridCell
    {
        public GridType GridType { get; set; }
        public Vector2Int Coordinates { get; private set; }
        public void SetCoordinate(int x, int y) => Coordinates = new Vector2Int(x, y);
        public GridCell(GridType gridType)
        {
            GridType = gridType;
        }
    }
}

