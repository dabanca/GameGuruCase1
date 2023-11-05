using _Project.Scripts.Core.Collections;
using _Project.Scripts.Core.GridItem;
using _Project.Scripts.Core.Match;

namespace _Project.Scripts.Engine.GridItem
{
    public class SignedGridItemView : GridItemView,IMatchable
    {
        public void Match()
        {
            ChangeItemView(GridItemType.Basic,new BasicGridItem());
        }
    }
}

