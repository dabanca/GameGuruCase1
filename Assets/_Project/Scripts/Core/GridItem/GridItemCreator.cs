using _Project.Scripts.Core.Grid;
using _Project.Scripts.Core.Grid.RuntimeData;
using _Project.Scripts.Engine.GridItem;
using UnityEngine;

namespace _Project.Scripts.Core.GridItem
{
    public class GridItemCreator
    {
        private GridItemView _gridItemView;

        public void SetGridItemViewPrefab(GridItemView gridItemView)
        {
            _gridItemView = gridItemView;   
        }
        public void CreateGridItem(GridCellDataContainer gridCellData,GridData gridData,Transform parentTransform)
        {
            var x = gridCellData.CoordX;
            var y = gridCellData.CoordY;

            var itemView = Object.Instantiate(_gridItemView, parentTransform, true);
            
            itemView.name = $"[{x},{y}]";
            itemView.SetGridItem(new BasicGridItem());
            itemView.GridItem.GridCell = gridData.GetCell(x, y);
            itemView.transform.position = new Vector3(x, y, 0);
        }
    }
}
