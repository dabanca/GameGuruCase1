using _Project.Scripts.Core.Grid;
using _Project.Scripts.Core.Grid.RuntimeData;
using _Project.Scripts.Core.GridItem;
using _Project.Scripts.Engine;
using UnityEngine;

namespace _Project.Scripts.Core.Level
{
    public class LevelCreator
    {
        public readonly GridCellCreator GridCellCreator = new GridCellCreator();
        public readonly GridItemCreator GridItemCreator= new GridItemCreator();
        
        private readonly LayerTransformCreator _layerTransformCreator = new LayerTransformCreator();

        private Transform _cellLayer;
        private Transform _itemLayer;
        
        private GridCellDataContainer[,] _gridCellDataContainers;
        
        public void Create(GridData gridData)
        {
            var levelData = LevelDataLoader.GetCurrentLevelFromDisk();
            InitBoardData(levelData,gridData);
            CreateLevel(levelData,gridData);
        }
        
        private void InitBoardData(LevelDataSo levelData, GridData gridData)
        { 
            gridData.Init(levelData);
            CreateLayers();
        }

        private void CreateLayers()
        {
            var parentTransform = new GameObject("Layers").transform;
            
            _layerTransformCreator.CreateAndSetLayers(parentTransform);

            _cellLayer = _layerTransformCreator.CellLayer;
            _itemLayer = _layerTransformCreator.ItemLayer;
        }

        private void CreateLevel(LevelDataSo levelData, GridData gridData)
        {
            CreateGridCells(levelData);
            CreateGridItems(levelData,gridData);
        }

        private void CreateGridItems(LevelDataSo levelData, GridData gridData)
        {
            var xSize = levelData.xSize;
            var ySize = levelData.ySize;

            for (var x = 0; x < xSize; x++)
            for (var y = 0; y < ySize; y++)
                GridItemCreator.CreateGridItem(_gridCellDataContainers[x, y],gridData,_itemLayer);
        }

        private void CreateGridCells(LevelDataSo levelData)
        {
            ChangeItemDataListTo2DArray(levelData);

            var xSize = levelData.xSize;
            var ySize = levelData.ySize;

            for (var x = 0; x < xSize; x++)
            for (var y = 0; y < ySize; y++) 
                GridCellCreator.CreateGridCell(_gridCellDataContainers[x, y],_cellLayer);
        }

        private void ChangeItemDataListTo2DArray(LevelDataSo levelData)
        {
            _gridCellDataContainers = new GridCellDataContainer[levelData.xSize, levelData.ySize];
            foreach (var container in levelData.GridCellDataContainers)
            {
                _gridCellDataContainers[container.CoordX, container.CoordY] = container;
            }
        }
    }
}