using _Project.Scripts.Core.Collections;
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
        public void CreateGridCell(int x, int y,Transform parentTransform)
        {
            var cellView = Object.Instantiate(_gridCellView, parentTransform);
            cellView.name = $"[{x},{y}]";
            cellView.SetGridCell(new GridCell(GridType.Default));
            cellView.GridCell.SetCoordinate(x, y);
            cellView.transform.position = new Vector3(x, y, 0);
        }
    }
}
