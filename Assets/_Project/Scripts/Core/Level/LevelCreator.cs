using System.Threading.Tasks;
using _Project.Scripts.Core.Grid;
using _Project.Scripts.Core.Grid.RuntimeData;
using _Project.Scripts.Core.GridItem;
using _Project.Scripts.Engine.Creators;
using _Project.Scripts.Engine.GridItem;
using UnityEngine;

namespace _Project.Scripts.Core.Level
{
    public class LevelCreator
    {
        private readonly GridCellCreator _gridCellCreator = new GridCellCreator();
        private readonly GridItemCreator _gridItemCreator= new GridItemCreator();
        private readonly LayerTransformCreator _layerTransformCreator = new LayerTransformCreator();

        private Transform _cellLayer;
        private Transform _itemLayer;
        private GridCellDataContainer[,] _gridCellDataContainers;
        public async Task Create()
        {
            var levelData = LevelDataLoader.GetCurrentLevelFromDisk();
            InitBoardData(levelData);
            await CreateLevel(levelData);
        }
        
        private void InitBoardData(LevelDataSo levelData)
        {
            GridData.Init(levelData);
            CreateLayers();
        }

        private void CreateLayers()
        {
            var parentTransform = new GameObject("Layers").transform;
            
            _layerTransformCreator.CreateAndSetLayers(parentTransform);

            _cellLayer = _layerTransformCreator.CellLayer;
            _itemLayer = _layerTransformCreator.ItemLayer;
        }

        private async Task CreateLevel(LevelDataSo levelData)
        {
            var poolTask = GridItemViewPoolHandler.Instance.InitTileViewPool();
            await Task.WhenAll(poolTask);
            
            await CreateGridCells(levelData);
            CreateGridItems(levelData);
            SetNeighbours();
        }

        private void CreateGridItems(LevelDataSo levelData)
        {
            var xSize = levelData.xSize;
            var ySize = levelData.ySize;

            for (var x = 0; x < xSize; x++)
            for (var y = 0; y < ySize; y++)
                _gridItemCreator.CreateGridItem(_gridCellDataContainers[x, y],_itemLayer);
        }

        private async Task CreateGridCells(LevelDataSo levelData)
        {
            ChangeCellDataListTo2DArray(levelData);

            var xSize = levelData.xSize;
            var ySize = levelData.ySize;

            for (var x = 0; x < xSize; x++)
            for (var y = 0; y < ySize; y++)
             await _gridCellCreator.CreateGridCell(_gridCellDataContainers[x, y],_cellLayer);
        }

        private void SetNeighbours()
        {
            var xSize = GridData.Size.x;
            var ySize =  GridData.Size.y;

            for (var x = 0; x < xSize; x++)
            for (var y = 0; y < ySize; y++)
                GridData.GetCell(x,y).FindNeighbours();
        }

        private void ChangeCellDataListTo2DArray(LevelDataSo levelData)
        {
            _gridCellDataContainers = new GridCellDataContainer[levelData.xSize, levelData.ySize];
            foreach (var container in levelData.GridCellDataContainers)
            {
                _gridCellDataContainers[container.CoordX, container.CoordY] = container;
            }
        }
    }
}