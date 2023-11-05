using System.Collections.Generic;
using _Project.Scripts.Core.Grid;
using _Project.Scripts.Core.Level;
using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Engine.Editor
{
    public class LevelEditorWindow : EditorWindow
    {
        private int _column;

        [MenuItem("Window/LevelEditor")]
        public static void ShowWindow()
        {
            var window = GetWindow<LevelEditorWindow>("LevelEditorWindow");
        }

        private void OnGUI()
        {
            _column = EditorGUILayout.IntSlider("N Size",_column, 1, 9);
            
            if (GUILayout.Button("Create Level"))
                CreateNewLevel();
        }

        private void CreateNewLevel()
        {
            LevelDataSo levelData = CreateInstance<LevelDataSo>();
            levelData.xSize = _column;
            levelData.ySize = _column;
            levelData.GridCellDataContainers = new List<GridCellDataContainer>(_column*_column);
            
            for (int i = 0; i < _column; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    var dataContainer = new GridCellDataContainer
                    {
                        CoordX = i,
                        CoordY = j
                    };
                    levelData.GridCellDataContainers.Add(dataContainer);
                }
            }
            
            AssetDatabase.CreateAsset(levelData,"Assets/Resources/LevelData/"+"Level"+1 +".asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = levelData;
        }
    }
}
