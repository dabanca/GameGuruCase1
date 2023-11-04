using _Project.Scripts.Core.Grid;
using _Project.Scripts.Engine.GridItem;
using UnityEngine;

namespace _Project.Scripts.Core.GridItem
{
    public class GridItemCreator
    {
        public void CreateGridItem(GridCellDataContainer gridCellData,Transform parentTransform)
        {
            var x = gridCellData.CoordX;
            var y = gridCellData.CoordY;

            var itemView = GridItemViewPool.Instance.GetGridItemView(gridCellData.GridItemType);
            itemView.SetGridItem(new BasicGridItem());
            itemView.Init(parentTransform,x,y);
        }
    }
}
