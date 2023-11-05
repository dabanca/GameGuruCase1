using _Project.Scripts.Core.Level;
using UnityEngine;

namespace _Project.Scripts.Core.Grid.RuntimeData
{
    public static class GridData
    {
        public static Vector2Int Size { get; private set; }
        
        private static GridCell[,] _cells;
        public static void Init(LevelDataSo levelData)
        {
            Size = new Vector2Int(levelData.xSize, levelData.ySize);
            _cells = new GridCell[Size.x, Size.y];
        }
        
        public static GridCell GetCell(int x, int y)
        {
            if (x < 0 || x >= Size.x || y < 0 || y >= Size.y) return null;

            return _cells[x, y];
        }
        
        public static void SetCell(int x, int y, GridCell gridCell)
        {
            _cells[x, y] = gridCell;
        }
    }
}

