using _Project.Scripts.Core.Level;
using _Project.Scripts.Engine.GridItem;
using UnityEngine;

namespace _Project.Scripts.Engine
{ 
    public class Main : MonoBehaviour
    {
        private LevelCreator LevelCreator { get; set; }

        private async void Start()
        {
            SetGridItemViewPool();
            LevelCreator = new LevelCreator();

            await LevelCreator.Create();
            CameraController.Instance.PositionCamera();
        }
        
        private void SetGridItemViewPool()
        {
            var unused = new GridItemViewPoolHandler();
        }
    }
}
