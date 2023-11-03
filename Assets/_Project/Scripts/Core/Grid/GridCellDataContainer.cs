using System;
using _Project.Scripts.Core.Collections;

namespace _Project.Scripts.Core.Grid
{
    [Serializable]
    public class GridCellDataContainer 
    {
        public int CoordX = -1;
        public int CoordY = -1;
        
        public GridItemType GridItemType;
    }
}