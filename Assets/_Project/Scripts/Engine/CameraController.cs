using _Project.Scripts.Core.Grid.RuntimeData;
using _Project.Scripts.Engine.Common;
using UnityEngine;

namespace _Project.Scripts.Engine
{
    public class CameraController : Singleton<CameraController>
    {
        [SerializeField] private Camera cam;
        public Camera Camera => cam;
        
        public void PositionCamera(GridData gridData)
        {
            const float z = -5f;

            transform.position = new Vector3(0.5f * (gridData.Size.x - 1), (0.5f * (gridData.Size.y - 1)), z);
        }
    }
}