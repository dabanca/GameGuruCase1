using _Project.Scripts.Core.Grid;
using _Project.Scripts.Engine;
using UnityEngine;

namespace _Project.Scripts.Core.Level
{
    public class LevelCreator
    {
        public readonly GridCellCreator GridCellCreator = new GridCellCreator();

        private readonly LayerTransformCreator _layerTransformCreator = new LayerTransformCreator();

        private Transform _cellLayer;
        public void Create()
        {
            CreateLayers();
            CreateLevel();
        }

        private void CreateLayers()
        {
            var parentTransform = new GameObject("Layers").transform;
            _layerTransformCreator.CreateAndSetLayers(parentTransform);
            _cellLayer = _layerTransformCreator.CellLayer;
        }

        private void CreateLevel()
        {
            CreateGridCells();
        }

        private void CreateGridCells()
        {
            var xSize = 5;
            var ySize = 5;

            for (var x = 0; x < xSize; x++)
            for (var y = 0; y < ySize; y++)
              GridCellCreator.CreateGridCell(x,y,_cellLayer);
        }
    }
}