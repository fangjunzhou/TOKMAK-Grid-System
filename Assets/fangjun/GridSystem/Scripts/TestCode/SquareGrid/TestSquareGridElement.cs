using System;
using UnityEngine;
using NaughtyAttributes;
using GridSystem;
using GridSystem.Square;

public class TestSquareGridElement : MonoBehaviour
{
    #region Public Field

    [BoxGroup("GridElement coordinate")]
    public int x;
    [BoxGroup("GridElement coordinate")]
    public int y;

    [BoxGroup("GridElement prefab")]
    public SquareGridElement prefab;

    [BoxGroup("GridElelent root")]
    public GameObject root;

    #endregion

    [Button("Generate Grid")]
    private void TestGridElementGenerate()
    {
        Vector3 position = new Vector3(x * 115, y * 115, 0);
        SquareGridElement squareGridElement = Instantiate(prefab, position, Quaternion.identity, root.transform);
        squareGridElement.coordinate = new GridCoordinate(x, y);
    }
}