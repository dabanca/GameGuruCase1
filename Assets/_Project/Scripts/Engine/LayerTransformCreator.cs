using UnityEngine;

namespace _Project.Scripts.Engine
{
    public class LayerTransformCreator
    {
        public Transform CellLayer { get; private set; }
        public Transform ItemLayer { get; private set; }
        
        public void CreateAndSetLayers(Transform parentTransform)
        {
            CellLayer = new GameObject("GridCellLayer").transform;
            ItemLayer = new GameObject("GridItemLayer").transform;
            
            CellLayer.SetParent(parentTransform);
            ItemLayer.SetParent(parentTransform);
        }
    }
}

