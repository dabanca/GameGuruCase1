using _Project.Scripts.Core.Grid;
using _Project.Scripts.Core.Grid.RuntimeData;
using UnityEngine;

namespace _Project.Scripts.Engine.Grid
{
    public class GridCellView : MonoBehaviour
    {
        private GridCell _gridCell;
        public void SetGridCell(GridCell cell)
        {
            _gridCell = cell;
        }
        public void Init(Transform parentTransform,int x, int y)
        {
            name = $"[{x},{y}]";
            _gridCell.SetCoordinate(x,y);
            GridData.SetCell(x,y,_gridCell);
            transform.position = new Vector3(x, y, 0);
            transform.SetParent(parentTransform);
        }
    }
}
