using System;
using _Project.Scripts.Core.Collections;
using _Project.Scripts.Core.Grid;
using _Project.Scripts.Engine.GridItem;

namespace _Project.Scripts.Core.GridItem
{
    [Serializable]
    public class GridItem 
    {
        public GridItemType GridItemType { get; set; }
        public GridCell GridCell { get; set; }
        public GridItemView GridItemView{ get; set; }
    }
}
