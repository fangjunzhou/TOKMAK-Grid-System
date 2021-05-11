using System;
using System.Collections.Generic;

namespace FinTOKMAK.GridSystem
{
    public class GridSystemSerializer
    {
        /// <summary>
        /// Serialize an IGridSystem into a map file
        /// </summary>
        /// <param name="gridSystem">the IGridSystem to serialize</param>
        /// <param name="filePath">the target file path</param>
        /// <typeparam name="DataType">the data type of Vertex</typeparam>
        public static void Serialize<DataType>(IGridSystem<DataType> gridSystem, string filePath)
            where DataType : GridDataContainer
        {
            // get all the vertices in the GridSystem
            List<Vertex<DataType>> vertices = gridSystem.vertices;
            // construct a VertexData List with the vertices list
            List<VertexData<DataType>> vertexDatas = new List<VertexData<DataType>>();
            foreach (Vertex<DataType> vertex in vertices)
            {
                vertexDatas.Add(new VertexData<DataType>(vertex));
            }
            // serialize all the vertices
            VertexSerializer.Serialize<DataType>(vertexDatas, filePath);
        }
    }
}