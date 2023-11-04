using _Project.Scripts.Core.Level;
using UnityEngine;

namespace _Project.Scripts.Core.Grid.RuntimeData
{
    public static class GridData
    {
        public static Vector2Int Size { get; private set; }
        public static GridCell[,] Cells { get; private set; }
        
        public static void Init(LevelDataSo levelData)
        {
            Size = new Vector2Int(levelData.xSize, levelData.ySize);
            Cells = new GridCell[Size.x, Size.y];
        }

        public static GridCell GetCell(int x, int y)
        {
            if (x < 0 || x >= Size.x || y < 0 || y >= Size.y) return null;

            return Cells[x, y];
        }

        public static void SetCell(int x, int y, GridCell gridCell)
        {
            Cells[x, y] = gridCell;
        }
    }
}

