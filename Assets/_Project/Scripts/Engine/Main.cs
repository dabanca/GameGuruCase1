using _Project.Scripts.Core.Level;
using _Project.Scripts.Engine.Grid;
using UnityEngine;

namespace _Project.Scripts.Engine
{ 
    public class Main : MonoBehaviour
    {
        private LevelCreator LevelCreator { get; set; }

        [SerializeField] private GridCellView _gridCellViewPrefab;
        private void Start()
        {
            LevelCreator = new LevelCreator();
            LevelCreator.GridCellCreator.SetGridCellViewPrefab(_gridCellViewPrefab);
            LevelCreator.Create();
        }
    }
}
