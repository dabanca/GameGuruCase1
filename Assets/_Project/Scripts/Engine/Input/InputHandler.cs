using _Project.Scripts.Core.GridItem;
using _Project.Scripts.Core.Match;
using _Project.Scripts.Engine.Camera;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Engine.Input
{
    public class InputHandler : MonoBehaviour,IPointerDownHandler
    {
        [SerializeField] private LayerMask _interactableLayer;

        private CheckMatch _checkMatch;
        private void Start()
        {
            _checkMatch = new CheckMatch();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            var ray = CameraController.Instance.GetCam().ScreenPointToRay(UnityEngine.Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, float.MaxValue, _interactableLayer))
                hit.collider.gameObject.GetComponent<IInteractable>().Interact(_checkMatch);
        }
    }
}

