using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using NaughtyAttributes;
using GridSystem;

public class TestVertex : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    [Button("Test the default constructor for Vertex")]
    private void TestBasicConstructor()
    {
        Vertex<string> vertex = new Vertex<string>();
        Debug.Log(vertex);
    }

    [Button("Test the constructor with coordinate for Vetex")]
    private void TestCoordinateConstructor()
    {
        Vertex<string> vertex = new Vertex<string>(new GridCoordinate(1, 5));
        Debug.Log(vertex);
    }

    [Button("Test the constructor with cost for Vertex")]
    private void TestCostConstructor()
    {
        Vertex<string> vertex = new Vertex<string>(5f);
        Debug.Log(vertex);
    }

    [Button("Test the constructor with cost and coordinate for Vertex")]
    private void TestDoubleConstructor()
    {
        Vertex<string> vertex = new Vertex<string>(new GridCoordinate(2, 5), 10f);
        Debug.Log(vertex);
    }

    [Button("Test the constructor with cost and coordinate and data for Vertex")]
    private void TestDataConstructor()
    {

        Vertex<string> vertex = new Vertex<string>(new GridCoordinate(2, 5), 10f, "Test vertex data");
        Debug.Log(vertex);
    }

    [Button("Test the AddConnectionDir func for Vertex")]
    private void TestAddDirection()
    {
        Vertex<string> vertex1 = new Vertex<string>();

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
        Vertex<string> vertex1 = new Vertex<string>(new GridCoordinate(0, 0));
        Vertex<string> vertex2 = new Vertex<string>(new GridCoordinate(1, 0));

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
        Vertex<string> vertex1 = new Vertex<string>(new GridCoordinate(0, 0));
        Vertex<string> vertex2 = new Vertex<string>(new GridCoordinate(1, 0));

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
        Dictionary<GridCoordinate, Vertex<string>> verticies = new Dictionary<GridCoordinate, Vertex<string>>();

        Vertex<string> ver1 = new Vertex<string>(new GridCoordinate(0, 1), 0, "ver1");
        verticies.Add(ver1.coordinate, ver1);
        Vertex<string> ver2 = new Vertex<string>(new GridCoordinate(0, 2), 0, "ver2");
        verticies.Add(ver2.coordinate, ver2);
        //Vertex<string> ver3 = new Vertex<string>(new GridCoordinate(0, 1));
        //verticies.Add(ver3.coordinate, ver3);                                 // failed

        Debug.Log(verticies[new GridCoordinate(0, 2)]);
    }
}
