using _Project.Scripts.Core.Grid.RuntimeData;
using _Project.Scripts.Engine.Common;
using UnityEngine;

namespace _Project.Scripts.Engine
{
    public class CameraController : Singleton<CameraController>
    {
        public void PositionCamera()
        {
            transform.position = new Vector3(0.5f * (GridData.Size.x - 1), (0.5f * (GridData.Size.y - 1)), -(GridData.Size.x + GridData.Size.y)/2);
        }
    }
}