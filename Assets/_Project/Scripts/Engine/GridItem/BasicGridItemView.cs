using _Project.Scripts.Core.Collections;
using _Project.Scripts.Core.GridItem;
using _Project.Scripts.Core.Match;

namespace _Project.Scripts.Engine.GridItem
{
    public class BasicGridItemView : GridItemView,IInteractable
    {
        public void Interact(CheckMatch checkMatch)
        {
            ChangeItemView(GridItemType.Signed);
            checkMatch.SearchForMatch(GridItem.GridCell);
        }
    }
}

