using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using GridSystem;
using GridSystem.Square;

public class TestSquareGridVertex : MonoBehaviour
{
    [Button("Test the default constructor of SquareGridVertex")]
    private void TestDefaultConstructor()
    {
        SquareGridVertex<string> squareGridVertex = new SquareGridVertex<string>();
        Debug.Log(squareGridVertex);
    }

    [Button("Test the SquareGridVertex in dictionary")]
    private void TestDictionary()
    {
        SquareGridVertex<string> squareGridVertex1 = new SquareGridVertex<string>(new GridCoordinate(1, 5), 10, "ver1");
        SquareGridVertex<string> squareGridVertex2 = new SquareGridVertex<string>(new GridCoordinate(2, 10), 5, "ver2");
        Dictionary<GridCoordinate, Vertex<string>> dictionary = new Dictionary<GridCoordinate, Vertex<string>>();
        
        // add the vertex into the dictionary
        dictionary.Add(squareGridVertex1.coordinate, squareGridVertex1);
        dictionary.Add(squareGridVertex2.coordinate, squareGridVertex2);
        
        // search in the dictionary
        Debug.Log("Contains (1, 5): " + dictionary.ContainsKey(new GridCoordinate(1, 5)));
        Debug.Log("Get (1, 5" + dictionary[new GridCoordinate(1, 5)].ToString());
    }
}
