using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Scripts.Core.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Project.Scripts.Engine
{
    [Serializable]
    public class GridItemViewRefPair
    {
        public AssetReference Reference;
        public GridItemType GridItemType;
    }
    
    [Serializable]
    public class GridCellViewRefPair
    {
        public AssetReference Reference;
        public GridType GridType;
    }
    
    public class MonoViewLoader : Common.Singleton<MonoViewLoader>
    {
        [SerializeField] private List<GridItemViewRefPair> _gridItemViewRefPairs = new List<GridItemViewRefPair>();
        [SerializeField] private List<GridCellViewRefPair> _gridCellViewRefPairs = new List<GridCellViewRefPair>();

        public async Task<T> LoadMonoViewGridItem<T>(GridItemType gridItemType) where T : MonoBehaviour
        {
            var assetRef = _gridItemViewRefPairs.Find(item => item.GridItemType == gridItemType).Reference;
            return await LoadAsset<T>(assetRef);
        }
        
        public async Task<T> LoadMonoViewGridCell<T>(GridType gridType) where T : MonoBehaviour
        {
            var assetRef = _gridCellViewRefPairs.Find(item => item.GridType == gridType).Reference;
            return await LoadAsset<T>(assetRef);
        }
        
        private async Task<T> LoadAsset<T>(AssetReference assetRef) where T : MonoBehaviour
        {
            var handle = Addressables.InstantiateAsync(assetRef);
            var source = new TaskCompletionSource<T>();
            handle.Completed += h =>
            {
                var go = h.Result;
                var monoView = go.GetComponent<T>();
                source.SetResult(monoView);
            };
            return await source.Task;
        }
    }
}