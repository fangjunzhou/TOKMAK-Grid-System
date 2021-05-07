using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem.Square
{
    public class SquareGridSystem<DataType> : IGridSystem<DataType>
    {

        #region Public Field
        #endregion

        #region Private Field

        // a dictionary that stores all the Coordinate-Vertex pairs
        private Dictionary<GridCoordinate, SquareGridVertex<DataType>> _vertices;
        
        #endregion

        #region Consttuctor

        /// <summary>
        /// The default constructor of SquareGridSystem
        /// </summary>
        public SquareGridSystem()
        {
            // initialize vertices as empty dic
            _vertices = new Dictionary<GridCoordinate, SquareGridVertex<DataType>>();
        }
        
        #endregion


        #region IGridSystem interface

        /// <summary>
        /// Add a non-directional Edge between coordinate1 and coordinate2
        /// </summary>
        /// <param name="coordinate1">the coordinate of first Vertex</param>
        /// <param name="coordinate2">the coordinate of second Vertex</param>
        /// <param name="weight">the weight of Edge between two vertices</param>
        public void AddDoubleEdge(GridCoordinate coordinate1, GridCoordinate coordinate2, float weight)
        {
            AddEdge(coordinate1, coordinate2, weight);
            AddEdge(coordinate2, coordinate1, weight);
        }

        /// <summary>
        /// Add a directional Edge from start coordinate to end coordinate
        /// </summary>
        /// <param name="start">the coordinate of start Vertex</param>
        /// <param name="end">the coordinate of end Vertex</param>
        /// <param name="weight">the weight of Edge between two vertices</param>
        /// <exception cref="ArgumentException">if the start coordinate and the end coordinate are not neighbor</exception>
        public void AddEdge(GridCoordinate start, GridCoordinate end, float weight)
        {
            // Get the start and end Vertex
            SquareGridVertex<DataType> startVertex = _vertices[start];
            SquareGridVertex<DataType> endVertex = _vertices[end];

            // end Vertex is on the right of start Vertex
            if (end.x == start.x + 1 && end.y == start.y)
            {
                startVertex.SetConnection("right", endVertex, weight);
            }
            // end Vertex is on the left of start Vertex
            else if (end.x == start.x - 1 && end.y == start.y)
            {
                startVertex.SetConnection("left", endVertex, weight);
            }
            // end Vertex is on the top of start Vertex
            else if (end.x == start.x && end.y == start.y + 1)
            {
                startVertex.SetConnection("up", endVertex, weight);
            }
            // end Vertex is on the bottom of start Vertex
            else if (end.x == start.x && end.y == start.y - 1)
            {
                startVertex.SetConnection("down", endVertex, weight);
            }
            // end Vertex is on the top left of the start Vertex
            else if (end.x == start.x - 1 && end.y == start.y + 1)
            {
                startVertex.SetConnection("upLeft", endVertex, weight);
            }
            // end Vertex is on the top right of the start Vertex
            else if (end.x == start.x + 1 && end.y == start.y + 1)
            {
                startVertex.SetConnection("upRight", endVertex, weight);
            }
            // end Vertex is on the bottom left of the start Vertex
            else if (end.x == start.x - 1 && end.y == start.y - 1)
            {
                startVertex.SetConnection("downLeft", endVertex, weight);
            }
            // end Vertex is on the bottom right of the start Vertex
            else if (end.x == start.x + 1 && end.y == start.y - 1)
            {
                startVertex.SetConnection("downRight", endVertex, weight);
            }
            else
            {
                throw new ArgumentException("The start Vertex and end Vertex are not neighbor, they cannot be connected");
            }
        }

        /// <summary>
        /// Add a new vertex to the current grids
        /// </summary>
        /// <param name="coordinate">the coordinate of the new vertex</param>
        /// <param name="cost">the cost of passing specific vertex</param>
        /// <param name="data">the data stored in the vertex</param>
        /// <exception cref="ArgumentException">if coordinate already exist</exception>
        public void AddVertex(GridCoordinate coordinate, float cost, DataType data)
        {
            if (_vertices.ContainsKey(coordinate))
                throw new ArgumentException("Vertex with specific coordinate already exist in the dictionary");
            
            SquareGridVertex<DataType> vertex = new SquareGridVertex<DataType>(coordinate, cost, data);
            // add the Coordinate-Vertex pair into the _vertices dict
            _vertices.Add(coordinate, vertex);
        }

        public List<Vertex<DataType>> FindShortestPath(GridCoordinate start, GridCoordinate end)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get the weight of the edge from the start to end
        /// </summary>
        /// <param name="start">the coordinate of start Vertex</param>
        /// <param name="end">the coordinate of end Vertex</param>
        /// <returns>the weight of the edge</returns>
        /// <exception cref="ArgumentException">if the start Vertex and end Vertex are not neighbor
        /// or there is not connection between start Vertex and end Vertex</exception>
        public float GetEdge(GridCoordinate start, GridCoordinate end)
        {
            // Get the start Vertex
            SquareGridVertex<DataType> startVertex = _vertices[start];
            Dictionary<string, Edge<DataType>> startConnections = startVertex.connection;
            Edge<DataType> edge;
            
            // end Vertex is on the right of start Vertex
            if (end.x == start.x + 1 && end.y == start.y)
            {
                edge = startConnections["right"];
            }
            // end Vertex is on the left of start Vertex
            else if (end.x == start.x - 1 && end.y == start.y)
            {
                edge = startConnections["left"];
            }
            // end Vertex is on the top of start Vertex
            else if (end.x == start.x && end.y == start.y + 1)
            {
                edge = startConnections["up"];
            }
            // end Vertex is on the bottom of start Vertex
            else if (end.x == start.x && end.y == start.y - 1)
            {
                edge = startConnections["down"];
            }
            // end Vertex is on the top left of the start Vertex
            else if (end.x == start.x - 1 && end.y == start.y + 1)
            {
                edge = startConnections["upLeft"];
            }
            // end Vertex is on the top right of the start Vertex
            else if (end.x == start.x + 1 && end.y == start.y + 1)
            {
                edge = startConnections["upRight"];
            }
            // end Vertex is on the Bottom left of the start Vertex
            else if (end.x == start.x - 1 && end.y == start.y - 1)
            {
                edge = startConnections["downLeft"];
            }
            // end Vertex is on the Bottom right of the start Vertex
            else if (end.x == start.x + 1 && end.y == start.y - 1)
            {
                edge = startConnections["downRight"];
            }
            else
            {
                throw new ArgumentException("The start Vertex and end Vertex are not neighbor, they cannot be connected");
            }

            if (edge == null)
                throw new ArgumentException("There's no connection between start Vertex and end Vertex");

            // get the cost of the edge
            return edge.cost;
        }

        /// <summary>
        /// Get and return the Vertex with certain coordinate
        /// </summary>
        /// <param name="coordinate">the target coordinate to get</param>
        /// <returns>the vertex with specific coordinate, 
        /// null when the vertex with certain coordinate do not exist</returns>
        public Vertex<DataType> GetVertex(GridCoordinate coordinate)
        {
            // if the Vertex with certain coordinate do not exist
            if (!_vertices.ContainsKey(coordinate))
                return null;

            SquareGridVertex<DataType> res = _vertices[coordinate];
            return res;
        }

        /// <summary>
        /// Remove the edge both from coordinate1 to coordinate2 and coordinate2 to coordinate1
        /// </summary>
        /// <param name="coordinate1">the coordinate of first Vertex</param>
        /// <param name="coordinate2">the coordinate of second Vertex</param>
        public void RemoveDoubleEdge(GridCoordinate coordinate1, GridCoordinate coordinate2)
        {
            RemoveEdge(coordinate1, coordinate2);
            RemoveEdge(coordinate2, coordinate1);
        }

        public void RemoveEdge(GridCoordinate start, GridCoordinate end)
        {
            // Get the start Vertex
            SquareGridVertex<DataType> startVertex = _vertices[start];
            Edge<DataType> edge;
            
            // end Vertex is on the right of start Vertex
            if (end.x == start.x + 1 && end.y == start.y)
            {
                // remove the right connection of start
                if (startVertex.connection["right"] != null)
                    startVertex.connection["right"] = null;
                else
                    throw new NullReferenceException("There's no connection between start Vertex and end Vertex.");
            }
            // end Vertex is on the left of start Vertex
            else if (end.x == start.x - 1 && end.y == start.y)
            {
                if (startVertex.connection["left"] != null)
                    startVertex.connection["left"] = null;
                else
                    throw new NullReferenceException("There's no connection between start Vertex and end Vertex.");
            }
            // end Vertex is on the top of start Vertex
            else if (end.x == start.x && end.y == start.y + 1)
            {
                if (startVertex.connection["up"] != null)
                    startVertex.connection["up"] = null;
                else
                    throw new NullReferenceException("There's no connection between start Vertex and end Vertex.");
            }
            // end Vertex is on the bottom of start Vertex
            else if (end.x == start.x && end.y == start.y - 1)
            {
                if (startVertex.connection["down"] != null)
                    startVertex.connection["down"] = null;
                else
                    throw new NullReferenceException("There's no connection between start Vertex and end Vertex.");
            }
            // end Vertex is on the top left of start Vertex
            else if (end.x == start.x - 1 && end.y == start.y + 1)
            {
                if (startVertex.connection["upLeft"] != null)
                    startVertex.connection["upLeft"] = null;
                else
                    throw new NullReferenceException("There's no connection between start Vertex and end Vertex.");
            }
            // end Vertex is on the top right of start Vertex
            else if (end.x == start.x + 1 && end.y == start.y + 1)
            {
                if (startVertex.connection["upRight"] != null)
                    startVertex.connection["upRight"] = null;
                else
                    throw new NullReferenceException("There's no connection between start Vertex and end Vertex.");
            }
            // end Vertex is on the bottom left of start Vertex
            else if (end.x == start.x - 1 && end.y == start.y - 1)
            {
                if (startVertex.connection["downLeft"] != null)
                    startVertex.connection["downLeft"] = null;
                else
                    throw new NullReferenceException("There's no connection between start Vertex and end Vertex.");
            }
            // end Vertex is on the bottom right of start Vertex
            else if (end.x == start.x - 1 && end.y == start.y - 1)
            {
                if (startVertex.connection["downRight"] != null)
                    startVertex.connection["downRight"] = null;
                else
                    throw new NullReferenceException("There's no connection between start Vertex and end Vertex.");
            }
            else
            {
                throw new ArgumentException("The start Vertex and end Vertex are not neighbor, they cannot be connected");
            }
        }

        /// <summary>
        /// Remove the vertex with certain coordinate
        /// </summary>
        /// <param name="coordinate">the target coordinate to remove</param>
        /// <exception cref="ArgumentException">if the Vertex with certain coordinate do not exist</exception>
        public void RemoveVertex(GridCoordinate coordinate)
        {
            // if the target vertex do not exist
            if (!_vertices.ContainsKey(coordinate))
                throw new ArgumentException("The Vertex with certain coordinate" + coordinate.ToString() + " do not exist.");
            
            // if the target exist, remove the target
            _vertices.Remove(coordinate);
            
            // TODO: Remove the edges between target Vertex and Vertices nearby
        }

        #endregion
    }
}
