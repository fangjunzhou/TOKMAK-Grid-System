using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace FinTOKMAK.GridSystem.Core.Test
{
    public class TestVertexDataSerialization : MonoBehaviour
    {
        #region Public Field

        /// <summary>
        /// The file path of Vertex data
        /// </summary>
        public string filePath;

        #endregion
        
        [Button("Test the Serialize method in the VertexSerializer")]
        private void TestVertexDataWrite()
        {
            // create two vertices and connect them
            Vertex<string> vertex1 = new Vertex<string>(new GridCoordinate(0, 0));
            Vertex<string> vertex2 = new Vertex<string>(new GridCoordinate(1, 0));
            vertex1.AddConnectionDir("right");
            vertex2.AddConnectionDir("left");
            vertex1.SetDoubleConnection("right", vertex2, "left", 10);
            
            Debug.Log("Vertex 1:");
            Debug.Log(vertex1);
            Debug.Log("Vertex 2:");
            Debug.Log(vertex2);

            VertexData<string> vertexData1 = new VertexData<string>(vertex1);
            Debug.Log("VertexData1: " + vertexData1);

            VertexData<string> vertexData2 = new VertexData<string>(vertex2);
            Debug.Log("VertexData2: " + vertexData2);

            List<VertexData<string>> vertexDatas = new List<VertexData<string>>();
            vertexDatas.Add(vertexData1);
            vertexDatas.Add(vertexData2);
            
            // Serialization
            VertexSerializer.Serialize(vertexDatas, Application.dataPath + "\\TestData\\" + filePath);
        }

        [Button("Test the Deserialize method in the VertexSerializer")]
        private void TestDeserialize()
        {
            List<VertexData<string>> vertexDatas = 
                VertexSerializer.Deserialize<string>(Application.dataPath + "\\TestData\\" + filePath);
            foreach (VertexData<string> vertexData in vertexDatas)
            {
                Debug.Log(vertexData);
            }
        }
    }
}