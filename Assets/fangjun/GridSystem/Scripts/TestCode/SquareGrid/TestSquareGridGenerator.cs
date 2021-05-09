using System;
using UnityEngine;
using NaughtyAttributes;
using FinTOKMAK.GridSystem.Square.Generator;

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
        squareGridGenerator.GenerateMap<SampleSquareGridElement>(width, height, 2);
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