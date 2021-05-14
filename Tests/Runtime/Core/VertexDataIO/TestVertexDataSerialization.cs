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
            Vertex<GridDataContainer> vertex1 = new Vertex<GridDataContainer>(0, new GridCoordinate(0, 0));
            Vertex<GridDataContainer> vertex2 = new Vertex<GridDataContainer>(0, new GridCoordinate(1, 0));
            vertex1.AddConnectionDir("right");
            vertex2.AddConnectionDir("left");
            vertex1.SetDoubleConnection("right", vertex2, "left", 10);
            
            Debug.Log("Vertex 1:");
            Debug.Log(vertex1);
            Debug.Log("Vertex 2:");
            Debug.Log(vertex2);

            VertexData<GridDataContainer> vertexData1 = new VertexData<GridDataContainer>(vertex1);
            Debug.Log("VertexData1: " + vertexData1);

            VertexData<GridDataContainer> vertexData2 = new VertexData<GridDataContainer>(vertex2);
            Debug.Log("VertexData2: " + vertexData2);

            List<VertexData<GridDataContainer>> vertexDatas = new List<VertexData<GridDataContainer>>();
            vertexDatas.Add(vertexData1);
            vertexDatas.Add(vertexData2);
            
            // Serialization
            VertexSerializer.Serialize(vertexDatas, Application.dataPath + "\\TestData\\" + filePath);
        }

        [Button("Test the Deserialize method in the VertexSerializer")]
        private void TestDeserialize()
        {
            List<VertexData<GridDataContainer>> vertexDatas = 
                VertexSerializer.Deserialize<GridDataContainer>(Application.dataPath + "\\TestData\\" + filePath);
            foreach (VertexData<GridDataContainer> vertexData in vertexDatas)
            {
                Debug.Log(vertexData);
            }
        }
    }
}