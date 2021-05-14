using UnityEngine;
using NaughtyAttributes;

namespace FinTOKMAK.GridSystem.Core.Test
{
    public class TestVertexData : MonoBehaviour
    {
        [Button("Test the constructor of VertexData")]
        private void TestVertexDataConstructor()
        {
            // create two vertices and connect them
            Vertex<GridDataContainer> vertex1 = new Vertex<GridDataContainer>(0, new GridCoordinate(0, 0));
            Vertex<GridDataContainer> vertex2 = new Vertex<GridDataContainer>(0, new GridCoordinate(1, 0));
            vertex1.AddConnectionDir("right");
            vertex2.AddConnectionDir("left");
            vertex1.SetDoubleConnection("right", vertex2, "left", 10);
            
            Debug.Log("Vertex 1:");
            Debug.Log(vertex1);
            Debug.Log("Vertex 2:");
            Debug.Log(vertex2);

            VertexData<GridDataContainer> vertexData = new VertexData<GridDataContainer>(vertex1);
            
            Debug.Log("VertexData: " + vertexData);
        }
    }
}