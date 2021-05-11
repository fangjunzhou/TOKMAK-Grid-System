using System.Collections.Generic;

namespace FinTOKMAK.GridSystem
{
    public class GridSystemSerializer
    {
        public static void Serialize<DataType>(IGridSystem<DataType> gridSystem, string filePath)
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