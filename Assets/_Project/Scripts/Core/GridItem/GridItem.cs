using System;
using _Project.Scripts.Core.Collections;
using _Project.Scripts.Core.Grid;

namespace _Project.Scripts.Core.GridItem
{
    [Serializable]
    public class GridItem 
    {
        public GridItemType GridItemType { get; }
        public GridCell GridCell { get; set; }
        public GridItem(GridItemType gridItemType)
        {
            GridItemType = gridItemType;
        }
    }
}
