using _Project.Scripts.Core.Collections;
using _Project.Scripts.Core.Grid.RuntimeData;
using UnityEngine;

namespace _Project.Scripts.Engine.GridItem
{
    public class GridItemView : MonoBehaviour
    {
        public Core.GridItem.GridItem GridItem { get; private set; }
        public void SetGridItem(Core.GridItem.GridItem item)
        {
            GridItem = item;
        }
        public void Init(Transform parentTransform,int x, int y)
        {
            name = $"[{x},{y}]";
            GridItem.GridCell = GridData.GetCell(x,y);
            GridItem.GridCell.SetGridItemToCell(GridItem);
            transform.position = new Vector3(x,y, 0);
            transform.SetParent(parentTransform);
            GridItem.GridItemView = this;
        }
        public bool Hide
        {
            set => gameObject.SetActive(!value);
        }

        protected void ChangeItemView(GridItemType gridItemType,Core.GridItem.GridItem gridItem)
        {
            GridItemViewPool.Instance.AddToPool(this);
            var newView = GridItemViewPool.Instance.GetGridItemView(gridItemType);
            newView.SetGridItem(gridItem);
            newView.Init(transform.parent,GridItem.GridCell.Coordinates.x,GridItem.GridCell.Coordinates.y);
        }
    }
}
