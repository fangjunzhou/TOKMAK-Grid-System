using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using GridSystem;

public class TestSquareGridVertex : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    [Button("Test the default constructor of SquareGridVertex")]
    private void TestDefaultConstructor()
    {
        SquareGridVertex<string> squareGridVertex = new SquareGridVertex<string>();
        Debug.Log(squareGridVertex);
    }
}
