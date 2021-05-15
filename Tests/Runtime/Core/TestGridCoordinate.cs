using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using FinTOKMAK.GridSystem;

namespace FinTOKMAK.GridSystem.Core.Test
{
    /// <summary>
    /// The test class for the GridCoordinate class
    /// </summary>
    public class TestGridCoordinate : MonoBehaviour
    {
        /// <summary>
        /// Test the default constructor for the GridCoordinate class
        /// </summary>
        [Button("Test default constructor for GridCoordinate")]
        private void TestDefaultConstructor()
        {
            GridCoordinate gridCoordinate = new GridCoordinate();
            Debug.Log("Default constructor: " + gridCoordinate.ToString());
        }

        /// <summary>
        /// Test the constructor with value for GridCoordinate
        /// </summary>
        [Button("Test constructor with value for GridCoordinate")]
        private void TestConstructorWithValue()
        {
            GridCoordinate gridCoordinate = new GridCoordinate(1, 1);
            Debug.Log("Constructor initialize as (1, 1): " + gridCoordinate.ToString());
        }

        /// <summary>
        /// Test the get ans set function for GridCoordiante
        /// </summary>
        [Button("Test get and set for GridCoordinate")]
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
    }
}