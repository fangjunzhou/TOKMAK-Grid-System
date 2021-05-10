using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using FinTOKMAK.GridSystem;

/// <summary>
/// The test class for the GridCoordinate class
/// </summary>
public class TestGridCoordinate : MonoBehaviour
{
    [Button("Test default constructor for GridCoordinate")]
    /// <summary>
    /// Test the default constructor for the GridCoordinate class
    /// </summary>
    private void TestDefaultConstructor()
    {
        GridCoordinate gridCoordinate = new GridCoordinate();
        Debug.Log("Default constructor: " + gridCoordinate.ToString());
    }

    [Button("Test constructor with value for GridCoordinate")]
    /// <summary>
    /// Test the constructor with value for GridCoordinate
    /// </summary>
    private void TestConstructorWithValue()
    {
        GridCoordinate gridCoordinate = new GridCoordinate(1, 1);
        Debug.Log("Constructor initialize as (1, 1): " + gridCoordinate.ToString());
    }

    [Button("Test get and set for GridCoordinate")]
    /// <summary>
    /// Test the get ans set function for GridCoordiante
    /// </summary>
    private void TestGetandSet()
    {
        GridCoordinate gridCoordinate = new GridCoordinate();
        Debug.Log("Default constructor: " + gridCoordinate.ToString());
        gridCoordinate.x = 10;
        gridCoordinate.y = 10;
        Debug.Log("Set the x and y to 10: " + gridCoordinate.ToString());
        Debug.Log("Get x: " + gridCoordinate.x.ToString());
        Debug.Log("Get y: " + gridCoordinate.y.ToString());
    }

    [Button("Test the Equals method of GridCoordinate")]
    private void TestEquals()
    {
        GridCoordinate gridCoordinate1 = new GridCoordinate(0, 1);
        GridCoordinate gridCoordinate2 = new GridCoordinate(2, 3);
        Debug.Log("Equals 1: " + gridCoordinate1.Equals(gridCoordinate2));
        Debug.Log("= 1: " + (gridCoordinate1 == gridCoordinate2));

        GridCoordinate gridCoordinate3 = new GridCoordinate(0, 1);

        Debug.Log("Equals 2: " + gridCoordinate1.Equals(gridCoordinate3));  // true
        Debug.Log("= 2: " + (gridCoordinate1 == gridCoordinate3));          // false
    }
}
