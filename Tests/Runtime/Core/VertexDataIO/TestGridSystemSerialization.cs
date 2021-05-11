using System.Collections.Generic;
using FinTOKMAK.GridSystem.Square.Generator;
using NaughtyAttributes;
using UnityEngine;

namespace FinTOKMAK.GridSystem.Core.Test
{
    public class TestGridSystemSerialization : MonoBehaviour
    {
        #region Public Field

        public string filePath;
        public SquareGridGenerator gridGenerator;

        #endregion

        [Button("Test the Serialize method of GridSystemSerializer")]
        private void TestSerialization()
        {
            GridSystemSerializer.Serialize(gridGenerator.squareGridSystem, Application.dataPath + "\\TestData\\" + filePath);
        }

        [Button("Test the Deserialize method of GridSystemSerializer")]
        private void TestDeserialization()
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