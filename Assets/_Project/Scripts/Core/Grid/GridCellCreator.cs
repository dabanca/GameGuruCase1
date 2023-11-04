using System.Threading.Tasks;
using _Project.Scripts.Engine;
using _Project.Scripts.Engine.Grid;
using UnityEngine;

namespace _Project.Scripts.Core.Grid
{
    public class GridCellCreator
    {
        public async Task CreateGridCell(GridCellDataContainer gridCellData,Transform parentTransform)
        {
            var x = gridCellData.CoordX;
            var y = gridCellData.CoordY;

            var cellTask = MonoViewLoader.Instance.LoadMonoViewGridCell<GridCellView>(gridCellData.GridType);
            await Task.WhenAll(cellTask);
            var cellView = cellTask.Result;
            
            var newCell = new GridCell(gridCellData.GridType);
            cellView.SetGridCell(newCell);
            cellView.Init(parentTransform,x,y);
        }
    }
}
