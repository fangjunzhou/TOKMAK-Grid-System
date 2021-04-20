using System.Collections.Generic;
using System.Collections;
using System;

namespace GridSystem
{
    /// <summary>
    /// The base class for a Vertex
    /// </summary>
    public class Vertex
    {
        #region Private Field

        /// <summary>
        /// The coordinate of the grid
        /// </summary>
        private GridCoordinate coordinate;
        /// <summary>
        /// The cost to pass through this grid
        /// </summary>
        private float cost;
        /// <summary>
        /// The connections with other vertecies
        /// </summary>
        private Dictionary<string, Edge> connection;

        #endregion

        #region Constructor

        /// <summary>
        /// The default constructor of Vertex base class
        /// </summary>
        public Vertex()
        {
            // set the coordinate to (0, 0)
            coordinate = new GridCoordinate();
            // set the cost to 0
            cost = 0;
            // initialize the connection dic to be empty
            connection = new Dictionary<string, Edge>();
        }

        /// <summary>
        /// The constructor with only coordinate initialized
        /// </summary>
        /// <param name="coordinate">the coordinate of current vertex</param>
        public Vertex(GridCoordinate coordinate)
        {
            // set the coordinate to (0, 0)
            this.coordinate = coordinate;
            // set the cost to 0
            cost = 0;
            // initialize the connection dic to be empty
            connection = new Dictionary<string, Edge>();
        }

        /// <summary>
        /// The constructor with only cost initialized
        /// </summary>
        /// <param name="cost">The cost that will take to pass current vertex</param>
        public Vertex(float cost)
        {
            // set the coordinate to (0, 0)
            coordinate = new GridCoordinate();
            // set the cost to 0
            this.cost = cost;
            // initialize the connection dic to be empty
            connection = new Dictionary<string, Edge>();
        }

        /// <summary>
        /// The constructor that will both initialize coordinate and cost of current vertex
        /// </summary>
        /// <param name="coordinate">the coordinate of current vertex</param>
        /// <param name="cost">The cost that will take to pass current vertex</param>
        public Vertex(GridCoordinate coordinate, float cost)
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the connection in one direction to a specific target
        /// </summary>
        /// <param name="direction">the direction to set</param>
        /// <param name="target">the target Vertex</param>
        /// <exception cref="ArgumentNullException">If the direction of target is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">If the direction does not appear in the connection dictionary</exception>
        public void SetConnection(string direction, Vertex target, float cost)
        {
            // handle all the possible exceptions
            if (direction == null)
                throw new ArgumentNullException("direction", "The direction cannot be null.");
            if (target == null)
                throw new ArgumentNullException("target", "The target cannot be null.");
            // if the direction is not the the key collection of connection dictionary
            if (!connection.ContainsKey(direction))
                throw new ArgumentOutOfRangeException("direction", "The direction is not in the connection dictionary");

            // set the connection of the specific direction to the new target
            connection[direction] = new Edge(this, target, cost);
        }

        /// <summary>
        /// Set the double connection between current vertex and the target vertex
        /// </summary>
        /// <param name="direction">the direction of target to the current vertex</param>
        /// <param name="target"> the target vertex</param>
        /// <param name="targetDirection">the direction of current vertex to the target vertex</param>
        /// <param name="cost">the cots of two edges (double connection)</param>
        /// <exception cref="ArgumentNullException">If the direction of target is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">If the direction does not appear in the connection dictionary</exception>
        public void SetDoubleConnection(string direction, Vertex target, string targetDirection, float cost)
        {

            // handle all the possible exceptions
            if (direction == null)
                throw new ArgumentNullException("direction", "The direction cannot be null.");
            if (target == null)
                throw new ArgumentNullException("target", "The target cannot be null.");
            if (targetDirection == null)
                throw new ArgumentNullException("targetDirection", "The targetDirection cannot be null");
            // if the direction is not the the key collection of connection dictionary
            if (!connection.ContainsKey(direction))
                throw new ArgumentOutOfRangeException("direction", "The direction is not in the connection dictionary, try AddConnectionDir()");
            if (!target.connection.ContainsKey(targetDirection))
                throw new ArgumentOutOfRangeException("targetDirection", "The targetDirection is not in the connection dictionary of target vertex, try AddConnectionDir()");

            // set the double connection between current vertex and target vertex
            connection[direction] = new Edge(this, target, cost);
            target.connection[targetDirection] = new Edge(target, this, cost);
        }

        /// <summary>
        /// Add a new dirction to the connection list
        /// </summary>
        /// <param name="direction">the direction to add</param>
        /// <exception cref="ArgumentException">If the connection alread exist</exception>
        public void AddConnectionDir(string direction)
        {
            if (connection.ContainsKey(direction))
                throw new ArgumentException("direction", "The connection to certain direction already exist, try use SetConnection()");
            connection.Add(direction, null);
        }

        /// <summary>
        /// The overload method of AddConnection, contains both direction and target
        /// </summary>
        /// <param name="direction">the direction of new connection</param>
        /// <param name="target">the target of new connection</param>
        /// <exception cref="ArgumentException">If the connection alread exist</exception>
        public void AddConnection(string direction, Vertex target, float cost)
        {
            if (connection.ContainsKey(direction))
                throw new ArgumentException("direction", "The connection to certain direction already exist, try use SetConnection()");
            connection.Add(direction, new Edge(this, target, cost));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="target"></param>
        /// <param name="targetDirection"></param>
        /// <param name="cost"></param>
        public void AddDoubleConnection(string direction, Vertex target, string targetDirection, float cost)
        {
            if (connection.ContainsKey(direction))
                throw new ArgumentException("direction", "The connection to certain direction already exist, try use SetConnection()");
            connection.Add(direction, new Edge(this, target, cost));
        }

        #endregion
    }
}