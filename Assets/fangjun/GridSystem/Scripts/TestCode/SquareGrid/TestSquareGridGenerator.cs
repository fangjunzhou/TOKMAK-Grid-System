using System;
using UnityEngine;
using NaughtyAttributes;

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
        squareGridGenerator.GenerateMap(width, height);
    }

    private void Start()
    {
        TestGenerate();
    }
}