using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using FinTOKMAK.GridSystem;
using FinTOKMAK.GridSystem.Square;

namespace FinTOKMAK.GridSystem.Square.Test
{
    public class TestSquareGridVertex : MonoBehaviour
    {
        [Button("Test the default constructor of SquareGridVertex")]
        private void TestDefaultConstructor()
        {
            SquareGridVertex<GridDataContainer> squareGridVertex = new SquareGridVertex<GridDataContainer>(0, new GridCoordinate(0, 0));
            Debug.Log(squareGridVertex);
        }

        [Button("Test the SquareGridVertex in dictionary")]
        private void TestDictionary()
        {
            SquareGridVertex<GridDataContainer> squareGridVertex1 = 
                new SquareGridVertex<GridDataContainer>(0, new GridCoordinate(1, 5), 10, new GridDataContainer());
            SquareGridVertex<GridDataContainer> squareGridVertex2 = 
                new SquareGridVertex<GridDataContainer>(0, new GridCoordinate(2, 10), 5, new GridDataContainer());
            Dictionary<GridCoordinate, Vertex<GridDataContainer>> dictionary = 
                new Dictionary<GridCoordinate, Vertex<GridDataContainer>>();
        
            // add the vertex into the dictionary
            dictionary.Add(squareGridVertex1.coordinate, squareGridVertex1);
            dictionary.Add(squareGridVertex2.coordinate, squareGridVertex2);
        
            // search in the dictionary
            Debug.Log("Contains (1, 5): " + dictionary.ContainsKey(new GridCoordinate(1, 5)));
            Debug.Log("Get (1, 5" + dictionary[new GridCoordinate(1, 5)].ToString());
        }
    }
}
