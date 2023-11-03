using _Project.Scripts.Core.Grid;
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
    }
}
