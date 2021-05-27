using System;
using UnityEngine;
using NaughtyAttributes;
using FinTOKMAK.GridSystem.Square.Generator;
using FinTOKMAK.GridSystem.Square.Sample;

namespace FinTOKMAK.GridSystem.Square.Test
{
    public class TestSquareGridGenerator : MonoBehaviour
    {
        #region Public Field

        [BoxGroup("Generate Method")]
        public bool useMapFile;
        [BoxGroup("Generate Method")]
        public string filePath;
        [BoxGroup("Generate Method")]
        public GridGenerationDirection direction;
        
        [BoxGroup("Generator")]
        public SquareGridGenerator squareGridGenerator;
    
        [BoxGroup("Map size")]
        public int width;
        [BoxGroup("Map size")]
        public int height;

        [BoxGroup("Global Offset")]
        public GridCoordinate globalOffset;

        #endregion

        [Button("Test the GenerateMap method")]
        private void TestGenerateVertical()
        {
            squareGridGenerator.GenerateMap<SampleSquareGridElement>(width, height, 1, 
                direction);
        }

        [Button("Test the GenerateMap method with map data file")]
        private void TestGenerateVerticalFromFile()
        {
            #if UNITY_EDITOR_OSX
            squareGridGenerator.GenerateMap<SampleSquareGridElement>
                (Application.dataPath + "/TestData/" + filePath, direction);
            #else
            squareGridGenerator.GenerateMap<SampleSquareGridElement>
                (Application.dataPath + "\\TestData\\" + filePath, direction);
            #endif
        }

        [Button("Test the Clear method")]
        private void TestClear()
        {
            squareGridGenerator.ClearMap();
        }

        private void Start()
        {
            // set the global offset
            squareGridGenerator.globalOffset = globalOffset;
            if (!useMapFile)
                TestGenerateVertical();
            else
                TestGenerateVerticalFromFile();
        }
    }
}