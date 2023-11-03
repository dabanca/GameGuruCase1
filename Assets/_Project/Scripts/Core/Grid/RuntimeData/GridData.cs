using _Project.Scripts.Core.Level;
using UnityEngine;

namespace _Project.Scripts.Core.Grid.RuntimeData
{
    public class GridData
    {
        public Vector2Int Size { get; private set; }
        public GridCell[,] Cells { get; private set; }
        
        public void Init(LevelDataSo levelData)
        {
            Size = new Vector2Int(levelData.xSize, levelData.ySize);
            Cells = new GridCell[Size.x, Size.y];
        }

        public GridCell GetCell(int x, int y)
        {
            if (x < 0 || x >= Size.x || y < 0 || y >= Size.y) return null;

            return Cells[x, y];
        }
    }
}

