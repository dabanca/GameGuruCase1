using _Project.Scripts.Core.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Engine.GridItem
{
    public class BasicGridItemView : GridItemView,IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.LogError(GridItem.GridCell.Coordinates);
            GridItemViewPool.Instance.AddToPool(this);
            
            var newView = GridItemViewPool.Instance.GetGridItemView(GridItemType.Signed);
            newView.Init(transform.parent,GridItem.GridCell.Coordinates.x,GridItem.GridCell.Coordinates.y);
        }
    }
}

