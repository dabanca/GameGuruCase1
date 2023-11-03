using UnityEngine;

namespace _Project.Scripts.Engine
{
    public class LayerTransformCreator
    {
        public Transform CellLayer { get; private set; }
        public void CreateAndSetLayers(Transform parentTransform)
        {
            CellLayer = new GameObject("GridCellLayer").transform;
            CellLayer.SetParent(parentTransform);
        }
    }
}

