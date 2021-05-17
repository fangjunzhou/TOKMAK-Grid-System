using System;
using System.Collections;
using System.Collections.Generic;

namespace FinTOKMAK.GridSystem
{
    /// <summary>
    /// The interface for a basic grid system
    /// including basic operation such as adding and removing vertex
    /// adding and removing edges
    /// </summary>
    /// <typeparam name="DataType">The data type of data that stores in each vertices</typeparam>
    public interface IGridSystem<DataType> where DataType : GridDataContainer
    {
        #region Public Field

        /// <summary>
        /// All the vertices in the GridSystem
        /// </summary>
        List<Vertex<DataType>> vertices { get; }

        /// <summary>
        /// the global offset of all the Vertex in the grid system
        /// </summary>
        GridCoordinate globalCoordinateOffset { get; set; }
        
        /// <summary>
        /// The unique ID of the gridSystem
        /// </summary>
        int gridSystemID { get; }

        #endregion
        
        #region Vertext Operation

        /// <summary>
        /// Add a new vertex to the current grids
        /// </summary>
        /// <param name="coordinate">the coordinate of the new vertex</param>
        /// <param name="cost">the cost of passing specific vertex</param>
        /// <param name="data">the data stored in the vertex</param>
        void AddVertex(GridCoordinate coordinate, float cost, DataType data);

        /// <summary>
        /// Remove a vertex from the current grids
        /// </summary>
        /// <param name="coordinate">the coordinate of the target vertex</param>
        /// <exception cref="ArgumentException">if the vertex with specific coordinate does not exist</exception>
        void RemoveVertex(GridCoordinate coordinate);

        /// <summary>
        /// Get a vertex with certain coordinate
        /// </summary>
        /// <param name="coordinate">the coordinate of the specific vertex to get</param>
        /// <exception cref="ArgumentException">if the vertext to remove with specific coordinate does not exist</exception>
        Vertex<DataType> GetVertex(GridCoordinate coordinate);

        #endregion

        #region Edge Operation

        /// <summary>
        /// Add a new edge from the start vertex to the end vertex
        /// </summary>
        /// <param name="start">the coordinate of star vertex</param>
        /// <param name="startGridSystemID">the ID of the grid system of the start Vertex</param>
        /// <param name="end">the coordinate of end vertex</param>
        /// <param name="endGridSystemID">the ID of the grid system of the end Vertex</param>
        /// <param name="weight">the weight of the edge from the start vertex to the end vertex</param>
        void SetEdge(GridCoordinate start, int startGridSystemID,
            GridCoordinate end, int endGridSystemID, float weight);

        /// <summary>
        /// Add a new edge between two vertecies
        /// </summary>
        /// <param name="coordinate1">coordinate of one vertex</param>
        /// <param name="startGridSystemID">the ID of the grid system of the start Vertex</param>
        /// <param name="coordinate2">coordinate of another vertex</param>
        /// <param name="endGridSystemID">the ID of the grid system of the end Vertex</param>
        /// <param name="weight">the weight of the edge from the start vertex to the end vertex</param>
        void SetDoubleEdge(GridCoordinate coordinate1, int startGridSystemID, 
            GridCoordinate coordinate2, int endGridSystemID, float weight);

        /// <summary>
        /// Remove an edge from the start vertex to the end vertex
        /// </summary>
        /// <param name="start">the coordinate of the start vertex</param>
        /// <param name="startGridSystemID">the ID of the grid system of the start Vertex</param>
        /// <param name="end">the coordinate of the end vertex</param>
        /// <param name="endGridSystemID">the ID of the grid system of the end Vertex</param>
        void RemoveEdge(GridCoordinate start, int startGridSystemID, 
            GridCoordinate end, int endGridSystemID);

        /// <summary>
        /// Remove an edge between two verticies
        /// </summary>
        /// <param name="coordinate1">coordiante of one vertex</param>
        /// <param name="startGridSystemID">the ID of the grid system of the start Vertex</param>
        /// <param name="coordinate2">coordiante of another vertex</param>
        /// <param name="endGridSystemID">the ID of the grid system of the end Vertex</param>
        void RemoveDoubleEdge(GridCoordinate coordinate1, int startGridSystemID, 
            GridCoordinate coordinate2, int endGridSystemID);

        /// <summary>
        /// Get the weight of the edge from the start vertex to the end vertex
        /// </summary>
        /// <param name="start">the coordinate of the start vertex</param>
        /// <param name="startGridSystemID">the ID of the grid system of the start Vertex</param>
        /// <param name="end">the coordinate of the end vertex</param>
        /// <param name="endGridSystemID">the ID of the grid system of the end Vertex</param>
        /// <returns>the weight of the edge that get</returns>
        float GetEdge(GridCoordinate start, int startGridSystemID, GridCoordinate end, int endGridSystemID);

        /// <summary>
        /// The overload method of GetEdge with coordinate
        /// can save the time of looking the vertex in the hash table
        /// </summary>
        /// <param name="startVertex">the "from" Vertex of the Edge</param>
        /// <param name="endVertex">the "to" Vertex of the Edge</param>
        /// <returns>the weight of the Edge between the startVertex and the endVertex</returns>
        float GetEdge(Vertex<DataType> startVertex, Vertex<DataType> endVertex);

        #endregion

        #region Path Finding

        /// <summary>
        /// Find the shortest path from the start vertex to the end vertex
        /// </summary>
        /// <param name="start">the coordinate of the start vertex</param>
        /// <param name="startGridSystemID">the ID of the grid system of the start Vertex</param>
        /// <param name="end">the coordinate of the end vertex</param>
        /// <param name="endGridSystemID">the ID of the grid system of the end Vertex</param>
        /// <returns>a list of verticies that lies on the shortest path from the start vertex to the end vertex</returns>
        /// <exception cref="ArgumentNullException">if the startVertex with the start coordinate
        /// or the endVertex with the end coordinate do not exist</exception>
        LinkedList<Vertex<DataType>> FindShortestPath(GridCoordinate start, int startGridSystemID, 
            GridCoordinate end, int endGridSystemID, bool useAccelerationTable);

        #endregion
    }
}