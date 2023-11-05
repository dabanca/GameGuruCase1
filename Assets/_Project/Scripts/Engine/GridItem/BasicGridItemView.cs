using _Project.Scripts.Core.Collections;
using _Project.Scripts.Core.GridItem;
using _Project.Scripts.Core.Match;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Engine.GridItem
{
    public class BasicGridItemView : GridItemView,IPointerDownHandler
    {
        private readonly CheckMatch _checkMatch = new CheckMatch();
        
        public void OnPointerDown(PointerEventData eventData)
        {
            ChangeItemView(GridItemType.Signed,new SignedGridItem());
            _checkMatch.SearchForMatch(GridItem.GridCell);
        }
    }
}

