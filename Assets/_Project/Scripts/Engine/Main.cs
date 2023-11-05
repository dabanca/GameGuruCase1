using System.Threading.Tasks;
using _Project.Scripts.Core.Grid.RuntimeData;
using _Project.Scripts.Core.Level;
using _Project.Scripts.Core.Match;
using _Project.Scripts.Engine.Camera;
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

            //
            //In case if LevelDataSo's grid item type changed to signed grid item, Check all cells at start
            var check = new CheckMatch();
            await Task.Delay(500); // Because of delay we can see matches at start,beside that is unnecessary.
            for (var x = 0; x < GridData.Size.x; x++)
            for (var y = 0; y < GridData.Size.y; y++)
                check.SearchForMatch(GridData.GetCell(x,y));
            //
        }
        
        private void SetGridItemViewPool()
        {
            var unused = new GridItemViewPoolHandler();
        }
    }
}
