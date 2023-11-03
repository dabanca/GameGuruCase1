using _Project.Scripts.Core.Grid.RuntimeData;
using _Project.Scripts.Core.Level;
using _Project.Scripts.Engine.Grid;
using _Project.Scripts.Engine.GridItem;
using UnityEngine;

namespace _Project.Scripts.Engine
{ 
    public class Main : MonoBehaviour
    {
        private LevelCreator LevelCreator { get; set; }
        public GridData GridData { get; private set; }

        [SerializeField] private GridCellView _gridCellViewPrefab;
        [SerializeField] private GridItemView _gridItemViewPrefab;
        private void Start()
        {
            LevelCreator = new LevelCreator();
            GridData = new GridData();
            
            LevelCreator.GridCellCreator.SetGridCellViewPrefab(_gridCellViewPrefab);
            LevelCreator.GridItemCreator.SetGridItemViewPrefab(_gridItemViewPrefab);
            
            LevelCreator.Create(GridData);
        }
    }
}
