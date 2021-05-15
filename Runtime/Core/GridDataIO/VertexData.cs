using System;
using System.Runtime.Serialization;

namespace FinTOKMAK.GridSystem
{
    /// <summary>
    /// Wrapper class that stores the coordinate, cost, and edge data
    /// </summary>
    /// <typeparam name="DataType">the data type of Vertex</typeparam>
    [System.Serializable]
    public class VertexData<DataType> where DataType : GridDataContainer
    {
        #region Public Field
        
        /// <summary>
        /// The coordinate of the Vertex
        /// coordinate[0] is the x coordinate
        /// coordinate[1] is the y coordinate
        /// </summary>
        public int[] coordinate = new int[2];

        /// <summary>
        /// the cost of the Vertex
        /// </summary>
        public float cost;

        /// <summary>
        /// A list of edge targets;
        /// </summary>
        public int[][] edgeTargets;
        /// <summary>
        /// The cost of edge between current Vertex and Vertex nearby
        /// -1 if there's no connection in certain direction
        /// </summary>
        public float[] edgeCost;

        /// <summary>
        /// Serializable data that stores in the GridDataContainer
        /// </summary>
        public ISerializable serializableData;

        #endregion

        #region Constructor

        /// <summary>
        /// The basic VertexData constructor
        /// </summary>
        /// <param name="vertex">the source Vertex to generate a correspond VertexData</param>
        public VertexData(Vertex<DataType> vertex)
        {
            // set the coordinate of the VertexData
            this.coordinate[0] = vertex.coordinate.x;
            this.coordinate[1] = vertex.coordinate.y;
            
            // set the cost of VertexData
            this.cost = vertex.cost;
            
            // set the edge information of VertexData
            this.edgeCost = new float[vertex.connection.Count];
            this.edgeTargets = new int[vertex.connection.Count][];
            // get all the connection information from the Vertex
            int index = 0;
            foreach (string direction in vertex.connection.Keys)
            {
                // if there's no connection in this direction
                if (vertex.connection[direction] == null)
                {
                    this.edgeCost[index] = -1;
                }
                else
                {
                    // set the edgeCost
                    this.edgeCost[index] = vertex.connection[direction].cost;
                    // set the edgeDirection
                    this.edgeTargets[index] = new[]
                    {
                        vertex.connection[direction].to.x,
                        vertex.connection[direction].to.y
                    };
                }

                index++;
            }

            serializableData = vertex.data.serializableData;
        }

        #endregion

        /// <summary>
        /// Override the ToString method for Debugging
        /// </summary>
        /// <returns>the string representation of current VertexData</returns>
        public override string ToString()
        {
            string res = "";
            res += "Coordinate: " + "(" + coordinate[0] + ", " + coordinate[1] + ")\n";
            res += "Cost: " + cost + "\n";
            res += "Edge targets: \n";
            foreach (int[] targetCoordinate in edgeTargets)
            {
                if (targetCoordinate != null)
                    res += "(" + targetCoordinate[0] + ", " + targetCoordinate[1] + ")\n";
            }

            res += "Edge costs: \n";
            foreach (float cost in edgeCost)
            {
                if (cost != -1)
                    res += cost + "\n";
            }

            if (serializableData != null)
            {
                res += "Serialized data: " + serializableData;
            }
            else
            {
                res += "Serialized data: null";
            }

            return res;
        }
    }
}