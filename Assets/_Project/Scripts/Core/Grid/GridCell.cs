using UnityEngine;

namespace _Project.Scripts.Core.Grid
{
    public class GridCell
    {
        public Vector2Int Coordinates { get; private set; }
        public void SetCoordinate(int x, int y) => Coordinates = new Vector2Int(x, y);
    }
}

