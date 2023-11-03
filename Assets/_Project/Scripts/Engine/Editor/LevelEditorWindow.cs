using System.Collections.Generic;
using _Project.Scripts.Core.Grid;
using _Project.Scripts.Core.Level;
using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Engine.Editor
{
    public class LevelEditorWindow : EditorWindow
    {
        private int _row;
        private int _column;
        private int _levelNumber;

        [MenuItem("Window/LevelEditor")]
        public static void ShowWindow()
        {
            var window = GetWindow<LevelEditorWindow>("LevelEditorWindow");
        }

        private void OnGUI()
        {
             _levelNumber = EditorGUILayout.IntField("Level Number",_levelNumber);
             _column = EditorGUILayout.IntSlider("X Size",_column, 1, 9);
             _row = EditorGUILayout.IntSlider("Y Size",_row, 1, 9);

             if (GUILayout.Button("Create Level"))
             {
                 CreateNewLevel();
             }
        }

        private void CreateNewLevel()
        {
            LevelDataSo levelData = CreateInstance<LevelDataSo>();
            levelData.xSize = _column;
            levelData.ySize = _row;
            levelData.LevelNumber = _levelNumber;
            levelData.GridCellDataContainers = new List<GridCellDataContainer>(_row*_column);
            
            for (int i = 0; i < _column; i++)
            {
                for (int j = 0; j < _row; j++)
                {
                    var dataContainer = new GridCellDataContainer
                    {
                        CoordX = i,
                        CoordY = j
                    };
                    levelData.GridCellDataContainers.Add(dataContainer);
                }
            }
            
            AssetDatabase.CreateAsset(levelData,"Assets/Resources/LevelData/"+"Level"+_levelNumber +".asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = levelData;
        }
    }
}
