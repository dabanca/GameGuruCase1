using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Scripts.Core.Collections;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Engine.GridItem
{
    public class GridItemViewPool
    {
        private static GridItemViewPool _instance;
        public static GridItemViewPool Instance => _instance ??= new GridItemViewPool();

        private GridItemViewPool()
        {
        }

        private readonly Dictionary<GridItemType, Queue<GridItemView>> _queueMap = new Dictionary<GridItemType, Queue<GridItemView>>();
        
        private GridItemView _basicGridItemView;
        private GridItemView _signedGridItemView;

        public async Task InitializePool()
        {
            var basicTask = MonoViewLoader.Instance.LoadMonoViewGridItem<GridItemView>(GridItemType.Basic);
            var signedTask = MonoViewLoader.Instance.LoadMonoViewGridItem<GridItemView>(GridItemType.Signed);
            
            var tasks = new Task[] {basicTask,signedTask};
            await Task.WhenAll(tasks);
            
            _basicGridItemView = basicTask.Result;
            _signedGridItemView = signedTask.Result;
            
            _basicGridItemView.SetGridItem(new Core.GridItem.BasicGridItem());
            _signedGridItemView.SetGridItem(new Core.GridItem.SignedGridItem());
            
            FillPool();
        }

        private void FillPool()
        {
            PoolItems(_basicGridItemView, 10);
            PoolItems(_signedGridItemView, 10);
            
            _basicGridItemView.Hide = true;
            _signedGridItemView.Hide = true;
        }

        private void PoolItems(GridItemView gridItemView, int count)
        {
            var type = gridItemView.GridItem.GridItemType;
            if (!_queueMap.TryGetValue(type, out var queue))
            {
                queue = new Queue<GridItemView>();
                _queueMap.Add(type, queue);
            }

            for (var i = 0; i < count; i++)
                queue.Enqueue(CloneGridItemView(gridItemView.GridItem.GridItemType));
        }

        private GridItemView CloneGridItemView(GridItemType gridItemType)
        {
            var prototype = ReturnViewWithType(gridItemType);
            var clone = Object.Instantiate(prototype);
            var gridItemView = clone.GetComponent<GridItemView>();
            gridItemView.SetGridItem(prototype.GridItem);
            gridItemView.Hide = true;
            return gridItemView;
        }

        public GridItemView GetGridItemView(GridItemType gridItemType)
        {
            var queue = _queueMap[gridItemType];
            var gridItemView = queue.Count > 0 ? queue.Dequeue() : CloneGridItemView(gridItemType);
            gridItemView.Hide = false;
            return gridItemView;
        }

        private GridItemView ReturnViewWithType(GridItemType gridItemType)
        {
            return gridItemType switch
            {
                GridItemType.Basic => _basicGridItemView,
                GridItemType.Signed => _signedGridItemView,
                _ => throw new ArgumentOutOfRangeException(nameof(gridItemType), gridItemType, null)
            };
        }

        public void AddToPool(GridItemView gridItemView)
        {
            var type = gridItemView.GridItem.GridItemType;
            var queue = _queueMap[type];
            gridItemView.Hide = true;
            queue.Enqueue(gridItemView);
        }

        public void Release()
        {
            foreach (var pair in _queueMap)
            foreach (var tileView in pair.Value)
            {
                Object.Destroy(tileView.gameObject);
            }

            _queueMap.Clear();

            Addressables.Release(_basicGridItemView.gameObject);
            Addressables.Release(_signedGridItemView.gameObject);
        }
    }
}
