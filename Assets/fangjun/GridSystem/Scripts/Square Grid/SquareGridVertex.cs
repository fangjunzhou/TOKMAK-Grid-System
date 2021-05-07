using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem.Square
{
    /// <summary>
    /// The SquareGridVertex extention of Vertex class
    /// each SquareGridVertex have four dirction
    /// up, down, left, and right
    /// upLeft, upRight, downLeft, and downRight
    /// </summary>
    public class SquareGridVertex<DataType> : Vertex<DataType>
    {
        #region Constructor

        /// <summary>
        /// The basic constructor of SquareGridVertex
        /// </summary>
        public SquareGridVertex()
        {
            // set the coordinate to (0, 0)
            _coordinate = new GridCoordinate();
            // set the cost to 0
            _cost = 0;
            // initialize the connection dic to be empty
            _connection = new Dictionary<string, Edge<DataType>>();

            // initialize the connection
            SquareGridSetup();
        }

        /// <summary>
        /// The constructor with coordinate initialized
        /// </summary>
        /// <param name="coordinate">the coordinate of current vertex</param>
        public SquareGridVertex(GridCoordinate coordinate)
        {

            // set the coordinate
            this._coordinate = coordinate;
            // set the cost to 0
            _cost = 0;
            // initialize the connection dic to be empty
            _connection = new Dictionary<string, Edge<DataType>>();

            // initialize the connection
            SquareGridSetup();
        }

        /// <summary>
        /// The constructor with cost initialized
        /// </summary>
        /// <param name="cost">the cost of current vertex</param>
        public SquareGridVertex(float cost)
        {
            // set the coordinate to (0, 0)
            _coordinate = new GridCoordinate();
            // set the cost
            this._cost = cost;
            // initialize the connection dic to be empty
            _connection = new Dictionary<string, Edge<DataType>>();

            // initialize the connection
            SquareGridSetup();
        }

        /// <summary>
        /// The constructor with coordinate and cost initialized
        /// </summary>
        /// <param name="coordinate">the coordinate of current vertex</param>
        /// <param name="cost">the cost of current vertex</param>
        public SquareGridVertex(GridCoordinate coordinate, float cost)
        {
            // set the coordinate
            this._coordinate = coordinate;
            // set the cost
            this._cost = cost;
            // initialize the connection dic to be empty
            _connection = new Dictionary<string, Edge<DataType>>();

            // initialize the connection
            SquareGridSetup();
        }

        /// <summary>
        /// The constructor with coordinate, cost and data initialized
        /// </summary>
        /// <param name="coordinate">the coordinate of current vertex</param>
        /// <param name="cost">the cost of passing current vertex</param>
        /// <param name="data">the data stored in current vertex</param>
        public SquareGridVertex(GridCoordinate coordinate, float cost, DataType data)
        {
            // set the coordinate
            this._coordinate = coordinate;
            // set the cost
            this._cost = cost;
            // set the data
            this._data = data;
            
            // initialize connections
            SquareGridSetup();
        }

        #endregion

        #region Private Field

        /// <summary>
        /// Setup the connection dictionary of SquareGridVetex with four directions
        /// </summary>
        private void SquareGridSetup()
        {
            AddConnectionDir("up");
            AddConnectionDir("down");
            AddConnectionDir("left");
            AddConnectionDir("right");
            AddConnectionDir("upLeft");
            AddConnectionDir("upRight");
            AddConnectionDir("downLeft");
            AddConnectionDir("downRight");
        }

        #endregion
    }
}