using _Project.Scripts.Core.Level;
using _Project.Scripts.Engine.GridItem;
using UnityEngine;

namespace _Project.Scripts.Engine
{ 
    public class Main : MonoBehaviour
    {
        private LevelCreator _levelCreator;
        private async void Start()
        {
            SetGridItemViewPool();
            _levelCreator = new LevelCreator();

            await _levelCreator.Create();
            CameraController.Instance.PositionCamera();
        }
        
        private void SetGridItemViewPool()
        {
            var unused = new GridItemViewPoolHandler();
        }
    }
}
