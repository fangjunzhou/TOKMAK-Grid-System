using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using GridSystem;

/// <summary>
/// The test class for the GridCoordinate class
/// </summary>
public class TestGridCoordinate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    [Button("Test default constructor for GridCoordinate")]
    /// <summary>
    /// Test the default constructor for the GridCoordinate class
    /// </summary>
    private void testDefaultConstructor()
    {
        GridCoordinate gridCoordinate = new GridCoordinate();
        Debug.Log("Default constructor: " + gridCoordinate.ToString());
    }

    [Button("Test constructor with value for GridCoordinate")]
    /// <summary>
    /// Test the constructor with value for GridCoordinate
    /// </summary>
    private void testConstructorWithValue()
    {
        GridCoordinate gridCoordinate = new GridCoordinate(1, 1);
        Debug.Log("Constructor initialize as (1, 1): " + gridCoordinate.ToString());
    }

    [Button("Test get and set for GridCoordinate")]
    /// <summary>
    /// Test the get ans set function for GridCoordiante
    /// </summary>
    private void testGetandSet()
    {
        GridCoordinate gridCoordinate = new GridCoordinate();
        Debug.Log("Default constructor: " + gridCoordinate.ToString());
        gridCoordinate.x = 10;
        gridCoordinate.y = 10;
        Debug.Log("Set the x and y to 10: " + gridCoordinate.ToString());
        Debug.Log("Get x: " + gridCoordinate.x.ToString());
        Debug.Log("Get y: " + gridCoordinate.y.ToString());
    }
}
