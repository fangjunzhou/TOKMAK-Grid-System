using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.GridSystem.Square.Generator;
using NaughtyAttributes;
using UnityEngine;

namespace FinTOKMAK.GridSystem.Square.Sample
{
    public class SampleSquareGridElementGenerator : MonoBehaviour
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
            squareGridGenerator.GenerateMap<SampleSquareGridElement3D>(width, height, 1, 
                direction);
        }

        [Button("Test the GenerateMap method with map data file")]
        private void TestGenerateVerticalFromFile()
        {
            squareGridGenerator.GenerateMap<SampleSquareGridElement3D>
                (Application.dataPath + "\\TestData\\" + filePath, direction);
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
