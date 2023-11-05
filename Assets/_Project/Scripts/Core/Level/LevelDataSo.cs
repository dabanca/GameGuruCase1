using System.Collections.Generic;
using _Project.Scripts.Core.Grid;
using UnityEngine;

namespace _Project.Scripts.Core.Level
{
    [CreateAssetMenu(fileName = "Level", menuName = "Game Levels/Level")]
    public class LevelDataSo : ScriptableObject
    {
        public int xSize, ySize;

        public List<GridCellDataContainer> GridCellDataContainers;
    }
}
