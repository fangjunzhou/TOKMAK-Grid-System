using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using FinTOKMAK.GridSystem;
using FinTOKMAK.GridSystem.Square;
using FinTOKMAK.GridSystem.Square.Generator;

namespace FinTOKMAK.GridSystem.Square.Test
{
    public class TestSquareGridSystem : MonoBehaviour
    {
        public SquareGridGenerator generator;
        public GridCoordinate startCoordinate;
        public GridCoordinate endCoordinate;
        
        [Button("Test the constructor of SquareGridSystem")]
        private void TestConstructor()
        {
            SquareGridSystem<GridDataContainer> squareGridSystem = new SquareGridSystem<GridDataContainer>(0, new GridCoordinate(0, 0));
            Debug.Log("Constructor working.");
        }
        
        [Button("Test AddVertex and GetVertex")]
        private void TestAddandGetVertex()
        {
            SquareGridSystem<GridDataContainer> squareGridSystem = new SquareGridSystem<GridDataContainer>(0, new GridCoordinate(0, 0));
            squareGridSystem.AddVertex(new GridCoordinate(0, 1), 10,
                new GridDataContainer());
            squareGridSystem.AddVertex(new GridCoordinate(10, 2), 12,
                new GridDataContainer());
            
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

        [Button("Test the RemoveVertex method")]
        private void TestRemoveVertex()
        {
            // add two vertices and edge between them
            SquareGridSystem<GridDataContainer> squareGridSystem = new SquareGridSystem<GridDataContainer>(0, new GridCoordinate(0, 0));
            squareGridSystem.AddVertex(new GridCoordinate(0, 1), 10,
                new GridDataContainer());
            squareGridSystem.AddVertex(new GridCoordinate(0, 2), 12,
                new GridDataContainer());
            squareGridSystem.SetDoubleEdge(new GridCoordinate(0, 1), 0, new GridCoordinate(0, 2), 0, 1);
            
            // print out the info of two vertices
            Debug.Log("Vertex (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
            Debug.Log("Vertex (0, 2): " + squareGridSystem.GetVertex(new GridCoordinate(0, 2)));
            
            // remove one vertex
            squareGridSystem.RemoveVertex(new GridCoordinate(0, 2));
            
            // print out the info of Vertex (0, 1)
            Debug.Log("Vertex (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
        }
        
        [Button("Test AddEdge and AddDoubleEdge")]
        private void TestAddEdge()
        {
            SquareGridSystem<GridDataContainer> squareGridSystem = new SquareGridSystem<GridDataContainer>(0, new GridCoordinate(0, 0));
            squareGridSystem.AddVertex(new GridCoordinate(0, 1), 10,
                new GridDataContainer());
            squareGridSystem.AddVertex(new GridCoordinate(1, 1), 12,
                new GridDataContainer());
            
            // get vertex
            Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
            Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
            
            Debug.LogWarning("ADD EDGE");
            // add edge
            squareGridSystem.SetEdge(new GridCoordinate(0, 1), 0, new GridCoordinate(1, 1), 0, 2);
            
            Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
            Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
            
            squareGridSystem.AddVertex(new GridCoordinate(3, 4), 10,
                new GridDataContainer());
            squareGridSystem.AddVertex(new GridCoordinate(3, 5), 12,
                new GridDataContainer());
            
            Debug.Log("Get (3, 4): " + squareGridSystem.GetVertex(new GridCoordinate(3, 4)));
            Debug.Log("Get (3, 5): " + squareGridSystem.GetVertex(new GridCoordinate(3, 5)));
            
            Debug.LogWarning("ADD DOUBLE EDGE");
            // add double edge
            squareGridSystem.SetDoubleEdge(new GridCoordinate(3, 4), 0, new GridCoordinate(3, 5), 0, 2);
            
            Debug.Log("Get (3, 4): " + squareGridSystem.GetVertex(new GridCoordinate(3, 4)));
            Debug.Log("Get (3, 5): " + squareGridSystem.GetVertex(new GridCoordinate(3, 5)));
        }

        [Button("Test GetEdge")]
        private void TestGetEdge()
        {
            SquareGridSystem<GridDataContainer> squareGridSystem = new SquareGridSystem<GridDataContainer>(0, new GridCoordinate(0, 0));
            squareGridSystem.AddVertex(new GridCoordinate(0, 1), 10,
                new GridDataContainer());
            squareGridSystem.AddVertex(new GridCoordinate(1, 1), 12,
                new GridDataContainer());
            
            // get vertex
            Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
            Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
            
            Debug.LogWarning("ADD EDGE");
            // add edge
            squareGridSystem.SetEdge(new GridCoordinate(0, 1), 0, new GridCoordinate(1, 1), 0, 2);
            
            Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
            Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
            
            Debug.LogWarning("Get Edge from (0, 1) to (1, 1): "  + 
                             squareGridSystem.GetEdge(new GridCoordinate(0, 1), 0, new GridCoordinate(1, 1), 0));
        }

        [Button("Test RemoveEdge and RemoveDoubleEdge")]
        private void TestRemoveEdge()
        {
            SquareGridSystem<GridDataContainer> squareGridSystem = new SquareGridSystem<GridDataContainer>(0, new GridCoordinate(0, 0));
            squareGridSystem.AddVertex(new GridCoordinate(0, 1), 10,
                new GridDataContainer());
            squareGridSystem.AddVertex(new GridCoordinate(1, 1), 12,
                new GridDataContainer());
            
            // get vertex
            Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
            Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
            
            Debug.LogWarning("ADD EDGE");
            // add edge
            squareGridSystem.SetEdge(new GridCoordinate(0, 1), 0, new GridCoordinate(1, 1), 0, 2);
            
            Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
            Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
            
            squareGridSystem.AddVertex(new GridCoordinate(3, 4), 10,
                new GridDataContainer());
            squareGridSystem.AddVertex(new GridCoordinate(3, 5), 12,
                new GridDataContainer());
            
            Debug.Log("Get (3, 4): " + squareGridSystem.GetVertex(new GridCoordinate(3, 4)));
            Debug.Log("Get (3, 5): " + squareGridSystem.GetVertex(new GridCoordinate(3, 5)));
            
            Debug.LogWarning("ADD DOUBLE EDGE");
            // add double edge
            squareGridSystem.SetDoubleEdge(new GridCoordinate(3, 4), 0, new GridCoordinate(3, 5), 0, 2);
            
            Debug.Log("Get (3, 4): " + squareGridSystem.GetVertex(new GridCoordinate(3, 4)));
            Debug.Log("Get (3, 5): " + squareGridSystem.GetVertex(new GridCoordinate(3, 5)));
            
            // remove edge
            squareGridSystem.RemoveEdge(new GridCoordinate(0, 1), 0, new GridCoordinate(1, 1), 0);
            Debug.LogWarning("Removed edge from (0, 1) to (1, 1)");
            
            Debug.Log("Get (0, 1): " + squareGridSystem.GetVertex(new GridCoordinate(0, 1)));
            Debug.Log("Get (1, 1): " + squareGridSystem.GetVertex(new GridCoordinate(1, 1)));
            
            // remove double edge
            squareGridSystem.RemoveDoubleEdge(new GridCoordinate(3, 4), 0, new GridCoordinate(3, 5), 0);
            Debug.LogWarning("Removed double edge from (3, 4) to (3, 5)");
            
            Debug.Log("Get (3, 4): " + squareGridSystem.GetVertex(new GridCoordinate(3, 4)));
            Debug.Log("Get (3, 5): " + squareGridSystem.GetVertex(new GridCoordinate(3, 5)));
        }

        [Button("Test the Pathfinding algorithm")]
        private void TestPathfinding()
        {
            LinkedList<Vertex<GridDataContainer>> path = generator.squareGridSystem.
                FindShortestPath(startCoordinate, 0, endCoordinate, 0, true);
            foreach (Vertex<GridDataContainer> vertex in path)
            {
                Debug.Log(vertex);
            }
        }
    }
}
