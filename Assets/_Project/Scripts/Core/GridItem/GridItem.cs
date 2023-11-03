using System;
using _Project.Scripts.Core.Collections;
using _Project.Scripts.Core.Grid;

namespace _Project.Scripts.Core.GridItem
{
    [Serializable]
    public class GridItem 
    {
        public bool CanInteract { get; set; }
        public GridItemType GridItemType { get; set; }
        public GridCell GridCell { get; set; }
       
    }
}
