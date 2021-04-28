using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using GridSystem;

public class TestSquareGridSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    [Button("Test the constructor of SquareGridSystem")]
    private void TestConstructor()
    {
        SquareGridSystem<string> squareGridSystem = new SquareGridSystem<string>();
        Debug.Log("Constructor working.");
    }
    
    [Button("Test AddVertex and GetVertex")]
    private void TestAddandGetVertex()
    {
        SquareGridSystem<string> squareGridSystem = new SquareGridSystem<string>();
        squareGridSystem.AddVertex(new GridCoordinate(0, 1), 10, "ver1");
        squareGridSystem.AddVertex(new GridCoordinate(10, 2), 12, "ver2");
        
        // get vertex
        Debug.Log("Get (10, 2): " + squareGridSystem.GetVertex(new GridCoordinate(10, 2)));
        
        // remove vertex
        squareGridSystem.RemoveVertex(new GridCoordinate(10, 2));
        Debug.Log("Remove (10, 2)");
        
        // try get vertex
        try
        {
            squareGridSystem.GetVertex(new GridCoordinate(10, 2));
            Debug.Log("Failed to raise ArgumentException");
        }
        catch (ArgumentException e)
        {
            Debug.Log("Successfully removed");
        }
    }
    
    [Button("Test AddEdge and AddDoubleEdge")]
    private void TestAddEdge()
    {
        SquareGridSystem<string> squareGridSystem = new SquareGridSystem<string>();
        squareGridSystem.AddVertex(new GridCoordinate(0, 1), 10, "ver1");
        squareGridSystem.AddVertex(new GridCoordinate(1, 1), 12, "ver2");
        
        // get vertex
        Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
        Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
        
        Debug.LogWarning("ADD EDGE");
        // add edge
        squareGridSystem.AddEdge(new GridCoordinate(0, 1), new GridCoordinate(1, 1), 2);
        
        Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
        Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
        
        squareGridSystem.AddVertex(new GridCoordinate(3, 4), 10, "ver3");
        squareGridSystem.AddVertex(new GridCoordinate(3, 5), 12, "ver4");
        
        Debug.Log("Get (3, 4): " + squareGridSystem.GetVertex(new GridCoordinate(3, 4)));
        Debug.Log("Get (3, 5): " + squareGridSystem.GetVertex(new GridCoordinate(3, 5)));
        
        Debug.LogWarning("ADD DOUBLE EDGE");
        // add double edge
        squareGridSystem.AddDoubleEdge(new GridCoordinate(3, 4), new GridCoordinate(3, 5), 2);
        
        Debug.Log("Get (3, 4): " + squareGridSystem.GetVertex(new GridCoordinate(3, 4)));
        Debug.Log("Get (3, 5): " + squareGridSystem.GetVertex(new GridCoordinate(3, 5)));
    }

    [Button("Test GetEdge")]
    private void TestGetEdge()
    {
        SquareGridSystem<string> squareGridSystem = new SquareGridSystem<string>();
        squareGridSystem.AddVertex(new GridCoordinate(0, 1), 10, "ver1");
        squareGridSystem.AddVertex(new GridCoordinate(1, 1), 12, "ver2");
        
        // get vertex
        Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
        Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
        
        Debug.LogWarning("ADD EDGE");
        // add edge
        squareGridSystem.AddEdge(new GridCoordinate(0, 1), new GridCoordinate(1, 1), 2);
        
        Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
        Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
        
        Debug.LogWarning("Get Edge from (0, 1) to (1, 1): "  + 
                         squareGridSystem.GetEdge(new GridCoordinate(0, 1), new GridCoordinate(1, 1)));
    }

    [Button("Test RemoveEdge and RemoveDoubleEdge")]
    private void TestRemoveEdge()
    {
        SquareGridSystem<string> squareGridSystem = new SquareGridSystem<string>();
        squareGridSystem.AddVertex(new GridCoordinate(0, 1), 10, "ver1");
        squareGridSystem.AddVertex(new GridCoordinate(1, 1), 12, "ver2");
        
        // get vertex
        Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
        Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
        
        Debug.LogWarning("ADD EDGE");
        // add edge
        squareGridSystem.AddEdge(new GridCoordinate(0, 1), new GridCoordinate(1, 1), 2);
        
        Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
        Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
        
        squareGridSystem.AddVertex(new GridCoordinate(3, 4), 10, "ver3");
        squareGridSystem.AddVertex(new GridCoordinate(3, 5), 12, "ver4");
        
        Debug.Log("Get (3, 4): " + squareGridSystem.GetVertex(new GridCoordinate(3, 4)));
        Debug.Log("Get (3, 5): " + squareGridSystem.GetVertex(new GridCoordinate(3, 5)));
        
        Debug.LogWarning("ADD DOUBLE EDGE");
        // add double edge
        squareGridSystem.AddDoubleEdge(new GridCoordinate(3, 4), new GridCoordinate(3, 5), 2);
        
        Debug.Log("Get (3, 4): " + squareGridSystem.GetVertex(new GridCoordinate(3, 4)));
        Debug.Log("Get (3, 5): " + squareGridSystem.GetVertex(new GridCoordinate(3, 5)));
        
        // remove edge
        squareGridSystem.RemoveEdge(new GridCoordinate(0, 1), new GridCoordinate(1, 1));
        Debug.LogWarning("Removed edge from (0, 1) to (1, 1)");
        
        Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
        Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
        
        // remove double edge
        squareGridSystem.RemoveDoubleEdge(new GridCoordinate(3, 4), new GridCoordinate(3, 5));
        Debug.LogWarning("Removed double edge from (3, 4) to (3, 5)");
        
        Debug.Log("Get (3, 4): " + squareGridSystem.GetVertex(new GridCoordinate(3, 4)));
        Debug.Log("Get (3, 5): " + squareGridSystem.GetVertex(new GridCoordinate(3, 5)));
    }
}
