using _Project.Scripts.Core.Level;
using UnityEngine;

namespace _Project.Scripts.Core.GridItem
{
    public static class LevelDataLoader
    {
        public static LevelDataSo GetCurrentLevelFromDisk()
        {
            LevelDataSo currentLevel = null;
            var currentLevelIndex = 1;

            currentLevel = Resources.Load<LevelDataSo>("LevelData/Level" + currentLevelIndex);
            if (!currentLevel) Debug.LogError("Current Level is NULL");

            return currentLevel;
        }
    }
}
