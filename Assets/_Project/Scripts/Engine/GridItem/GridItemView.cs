using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Engine.GridItem
{
    public class GridItemView : MonoBehaviour,IPointerDownHandler
    {
        public Core.GridItem.GridItem GridItem { get; private set; }
        
        public void SetGridItem(Core.GridItem.GridItem item)
        {
            GridItem = item;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(!GridItem.CanInteract) return;
            
            Debug.LogError("Pointer Down");
            Destroy(gameObject);

            Vector2 worldPosition = CameraController.Instance.Camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, -CameraController.Instance.Camera.transform.position.z));
            var x = Mathf.RoundToInt(worldPosition.x);
            var y = Mathf.RoundToInt(worldPosition.y);
            
        }
    }
}
