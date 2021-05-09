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
    
        [BoxGroup("Generator")]
        public SquareGridGenerator squareGridGenerator;
    
        [BoxGroup("Map size")]
        public int width;
        [BoxGroup("Map size")]
        public int height;

        #endregion

        [Button("Test the GenerateMap method")]
        private void TestGenerate()
        {
            squareGridGenerator.GenerateMap<SampleSquareGridElement>(width, height, 1);
        }

        [Button("Test the Clear method")]
        private void TestClear()
        {
            squareGridGenerator.ClearMap();
        }

        private void Start()
        {
            TestGenerate();
        }
    }
}