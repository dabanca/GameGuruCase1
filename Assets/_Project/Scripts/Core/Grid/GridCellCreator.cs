using _Project.Scripts.Engine.Grid;
using UnityEngine;

namespace _Project.Scripts.Core.Grid
{
    public class GridCellCreator
    {
        private GridCellView _gridCellView;

        public void SetGridCellViewPrefab(GridCellView gridCellView)
        {
            _gridCellView = gridCellView;
        }
        public void CreateGridCell(GridCellDataContainer gridCellData,Transform parentTransform)
        {
            var x = gridCellData.CoordX;
            var y = gridCellData.CoordY;
            
            var cellView = Object.Instantiate(_gridCellView, parentTransform);
            
            cellView.name = $"[{x},{y}]";
            cellView.SetGridCell(new GridCell());
            cellView.GridCell.SetCoordinate(x, y);
            cellView.transform.position = new Vector3(x, y, 0);
        }
    }
}
