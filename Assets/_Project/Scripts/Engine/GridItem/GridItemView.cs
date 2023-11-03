using UnityEngine;

namespace _Project.Scripts.Engine.GridItem
{
    public class GridItemView : MonoBehaviour
    {
        public Core.GridItem.GridItem GridItem { get; private set; }
        
        public void SetGridItem(Core.GridItem.GridItem item)
        {
            GridItem = item;
        }
    }
}
