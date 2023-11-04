using _Project.Scripts.Core.Grid;
using _Project.Scripts.Core.Grid.RuntimeData;
using UnityEngine;

namespace _Project.Scripts.Engine.Grid
{
    public class GridCellView : MonoBehaviour
    {
        public GridCell GridCell { get; private set; }
        public void SetGridCell(GridCell cell)
        {
            GridCell = cell;
        }
        public void Init(Transform parentTransform,int x, int y)
        {
            name = $"[{x},{y}]";
            GridCell.SetCoordinate(x,y);
            GridData.SetCell(x,y,GridCell);
            transform.position = new Vector3(x, y, 0);
            transform.SetParent(parentTransform);
        }
    }
}
