using _Project.Scripts.Core.Collections;

namespace _Project.Scripts.Core.GridItem
{
    public sealed class BasicGridItem : GridItem
    {
        public BasicGridItem()
        {
            GridItemType = GridItemType.Basic;
            CanInteract = true;
        }
    }
}