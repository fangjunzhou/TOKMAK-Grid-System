using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using NaughtyAttributes;
using FinTOKMAK.GridSystem;

namespace FinTOKMAK.GridSystem.Core.Test
{
    public class TestVertex : MonoBehaviour
    {
        [Button("Test the default constructor for Vertex")]
        private void TestBasicConstructor()
        {
            Vertex<GridDataContainer> vertex = new Vertex<GridDataContainer>();
            Debug.Log(vertex);
        }

        [Button("Test the constructor with coordinate for Vetex")]
        private void TestCoordinateConstructor()
        {
            Vertex<GridDataContainer> vertex = new Vertex<GridDataContainer>(0, new GridCoordinate(1, 5));
            Debug.Log(vertex);
        }

        [Button("Test the constructor with cost for Vertex")]
        private void TestCostConstructor()
        {
            Vertex<GridDataContainer> vertex = new Vertex<GridDataContainer>(0, 5f);
            Debug.Log(vertex);
        }

        [Button("Test the constructor with cost and coordinate for Vertex")]
        private void TestDoubleConstructor()
        {
            Vertex<GridDataContainer> vertex = new Vertex<GridDataContainer>(0, new GridCoordinate(2, 5), 10f);
            Debug.Log(vertex);
        }

        [Button("Test the constructor with cost and coordinate and data for Vertex")]
        private void TestDataConstructor()
        {

            Vertex<GridDataContainer> vertex = new Vertex<GridDataContainer>(0, new GridCoordinate(2, 5), 10f,
                new GridDataContainer());
            Debug.Log(vertex);
        }

        [Button("Test the AddConnectionDir func for Vertex")]
        private void TestAddDirection()
        {
            Vertex<GridDataContainer> vertex1 = new Vertex<GridDataContainer>();

            Debug.Log("Vertex 1:");
            Debug.Log(vertex1);

            vertex1.AddConnectionDir("right");
            Debug.Log("Add direction...");

            Debug.Log("Vertex 1:");
            Debug.Log(vertex1);
        }

        [Button("Test the SetConnection func for Vertex")]
        private void TestSetConnection()
        {
            // create two verticies
            Vertex<GridDataContainer> vertex1 = new Vertex<GridDataContainer>(0, new GridCoordinate(0, 0));
            Vertex<GridDataContainer> vertex2 = new Vertex<GridDataContainer>(0, new GridCoordinate(1, 0));

            Debug.Log("Vertex 1:");
            Debug.Log(vertex1);
            Debug.Log("Vertex 2:");
            Debug.Log(vertex2);

            vertex1.AddConnectionDir("right");
            vertex1.SetConnection("right", vertex2, 10);

            Debug.Log("Add and set connection");

            Debug.Log("Vertex 1:");
            Debug.Log(vertex1);
            Debug.Log("Vertex 2:");
            Debug.Log(vertex2);

            vertex1.SetConnection("right", vertex2, 25);

            Debug.Log("Change connection");

            Debug.Log("Vertex 1:");
            Debug.Log(vertex1);
            Debug.Log("Vertex 2:");
            Debug.Log(vertex2);

        }

        [Button("Test the SetDoubleConnection for Vertex")]
        private void TestSetDoubleConnection()
        {
            // create two verticies
            Vertex<GridDataContainer> vertex1 = new Vertex<GridDataContainer>(0, new GridCoordinate(0, 0));
            Vertex<GridDataContainer> vertex2 = new Vertex<GridDataContainer>(0, new GridCoordinate(1, 0));

            Debug.Log("Vertex 1:");
            Debug.Log(vertex1);
            Debug.Log("Vertex 2:");
            Debug.Log(vertex2);

            vertex1.AddConnectionDir("right");
            try
            {
                vertex1.SetDoubleConnection("right", vertex2, "left", 10);
                Debug.LogWarning("Did not raise exception in AddDoubleConnection");

            }catch(ArgumentException AE)
            {
                Debug.Log("Successfully raise exception");
            }

            Debug.Log("Vertex 1:");
            Debug.Log(vertex1);
            Debug.Log("Vertex 2:");
            Debug.Log(vertex2);

            vertex2.AddConnectionDir("left");
            vertex1.SetDoubleConnection("right", vertex2, "left", 10);
            Debug.Log("Add and set double connection");

            Debug.Log("Vertex 1:");
            Debug.Log(vertex1);
            Debug.Log("Vertex 2:");
            Debug.Log(vertex2);
        }

        [Button("Test using Coordinate as key nevigate Vertex in a hash table")]
        private void TestHashTable()
        {
            Dictionary<GridCoordinate, Vertex<GridDataContainer>> verticies = 
                new Dictionary<GridCoordinate, Vertex<GridDataContainer>>();

            Vertex<GridDataContainer> ver1 = new Vertex<GridDataContainer>(0, new GridCoordinate(0, 1), 0,
                new GridDataContainer());
            verticies.Add(ver1.coordinate, ver1);
            Vertex<GridDataContainer> ver2 = new Vertex<GridDataContainer>(0, new GridCoordinate(0, 2), 0,
                new GridDataContainer());
            verticies.Add(ver2.coordinate, ver2);
            //Vertex<string> ver3 = new Vertex<string>(new GridCoordinate(0, 1));
            //verticies.Add(ver3.coordinate, ver3);                                 // failed

            Debug.Log(verticies[new GridCoordinate(0, 2)]);
        }
    }
}