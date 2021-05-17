using System.Collections.Generic;
using System.Collections;
using System;

namespace FinTOKMAK.GridSystem
{
    /// <summary>
    /// The base class for a Vertex
    /// </summary>
    /// <typeparam name="DataType">The data type of data stored in the Vertex</typeparam>
    public class Vertex<DataType> where DataType : GridDataContainer
    {
        #region Private Field

        /// <summary>
        /// The grid system current Vertex belong to
        /// </summary>
        private protected int _gridSystemID;
        /// <summary>
        /// The coordinate of the grid
        /// </summary>
        private protected GridCoordinate _coordinate;
        /// <summary>
        /// The cost to pass through this grid
        /// </summary>
        private protected float _cost;
        /// <summary>
        /// The connections with other vertecies
        /// </summary>
        private protected Dictionary<string, Edge<DataType>> _connection;

        /// <summary>
        /// The data stored in current vertex
        /// </summary>
        private protected DataType _data;

        #endregion

        #region Public Field

        /// <summary>
        /// The grid system current Vertex belong to
        /// </summary>
        public int gridSystemID
        {
            get
            {
                return _gridSystemID;
            }
        }
        
        /// <summary>
        /// All the connections between current Vertex and other verticies
        /// </summary>
        public Dictionary<string, Edge<DataType>> connection
        {
            get
            {
                return _connection;
            }
        }

        /// <summary>
        /// The virtual coordinate of current Vertex
        /// Help the algorithm and system to navigate
        /// </summary>
        public GridCoordinate coordinate
        {
            get
            {
                return _coordinate;
            }
        }

        /// <summary>
        /// The cost of passing through current vertex
        /// </summary>
        public float cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }

        /// <summary>
        /// The data stored in current Vertex
        /// </summary>
        public DataType data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// The default parameterless constructor required for compile
        /// </summary>
        public Vertex()
        {
            // initialize the ID
            _gridSystemID = 0;
            // set the coordinate to (0, 0)
            _coordinate = new GridCoordinate();
            // set the cost to 0
            _cost = 0;
            // initialize the connection dic to be empty
            _connection = new Dictionary<string, Edge<DataType>>();
        }

        /// <summary>
        /// The default constructor of Vertex base class
        /// coordinate will be set to (0, 0)
        /// cost will be set to 0
        /// </summary>
        public Vertex(int id)
        {
            // initialize the ID
            _gridSystemID = id;
            // set the coordinate to (0, 0)
            _coordinate = new GridCoordinate();
            // set the cost to 0
            _cost = 0;
            // initialize the connection dic to be empty
            _connection = new Dictionary<string, Edge<DataType>>();
        }

        /// <summary>
        /// The constructor with only coordinate initialized
        /// cost will be set to 0
        /// </summary>
        /// <param name="coordinate">the coordinate of current vertex</param>
        public Vertex(int id, GridCoordinate coordinate)
        {
            // initialize the ID
            _gridSystemID = id;
            // set the coordinate
            this._coordinate = coordinate;
            // set the cost to 0
            _cost = 0;
            // initialize the connection dic to be empty
            _connection = new Dictionary<string, Edge<DataType>>();
        }

        /// <summary>
        /// The constructor with only cost initialized
        /// coordinate will be set to (0, 0)
        /// </summary>
        /// <param name="cost">The cost that will take to pass current vertex</param>
        public Vertex(int id, float cost)
        {
            // initialize the ID
            _gridSystemID = id;
            // set the coordinate to (0, 0)
            _coordinate = new GridCoordinate();
            // set the cost
            this._cost = cost;
            // initialize the connection dic to be empty
            _connection = new Dictionary<string, Edge<DataType>>();
        }

        /// <summary>
        /// The constructor that will both initialize coordinate and cost of current vertex
        /// </summary>
        /// <param name="coordinate">the coordinate of current vertex</param>
        /// <param name="cost">The cost that will take to pass current vertex</param>
        public Vertex(int id, GridCoordinate coordinate, float cost)
        {
            // initialize the ID
            _gridSystemID = id;
            // set the coordinate
            this._coordinate = coordinate;
            // set the cost
            this._cost = cost;
            // initialize the connection dic to be empty
            _connection = new Dictionary<string, Edge<DataType>>();
        }

        /// <summary>
        /// The constructor that will both initialize coordinate and cost of current vertex
        /// and initialized the data
        /// </summary>
        /// <param name="coordinate">the coordinate of current Vertex</param>
        /// <param name="cost">the cost of current Vertex</param>
        /// <param name="data">the data stored in current Vertex</param>
        public Vertex(int id, GridCoordinate coordinate, float cost, DataType data)
        {
            // initialize the ID
            _gridSystemID = id;
            // set the coordinate
            this._coordinate = coordinate;
            // set the cost
            this._cost = cost;
            // initialize the connection dic to be empty
            _connection = new Dictionary<string, Edge<DataType>>();
            // store the data in current Vertex
            this._data = data;
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
        public void SetConnection(string direction, Vertex<DataType> target, float cost)
        {
            // handle all the possible exceptions
            if (direction == null)
                throw new ArgumentNullException("direction", "The direction cannot be null.");
            if (target == null)
                throw new ArgumentNullException("target", "The target cannot be null.");
            // if the direction is not the the key collection of connection dictionary
            if (!_connection.ContainsKey(direction))
                throw new ArgumentOutOfRangeException("direction", "The direction is not in the connection dictionary");

            // check if the connection exist
            if (_connection[direction] != null)
            {
                // change the property of the old Edge
                _connection[direction].to = target.coordinate;
                _connection[direction].cost = cost;
                return;
            }
            
            // if the connection does not exist
            // set the connection of the specific direction to the new target
            _connection[direction] = new Edge<DataType>(this, target, cost);
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
        public void SetDoubleConnection(string direction, Vertex<DataType> target, string targetDirection, float cost)
        {

            // handle all the possible exceptions
            if (direction == null)
                throw new ArgumentNullException("direction", "The direction cannot be null.");
            if (target == null)
                throw new ArgumentNullException("target", "The target cannot be null.");
            if (targetDirection == null)
                throw new ArgumentNullException("targetDirection", "The targetDirection cannot be null");
            // if the direction is not the the key collection of connection dictionary
            if (!_connection.ContainsKey(direction))
                throw new ArgumentOutOfRangeException("direction", "The direction is not in the connection dictionary, try AddConnectionDir()");
            if (!target._connection.ContainsKey(targetDirection))
                throw new ArgumentOutOfRangeException("targetDirection", "The targetDirection is not in the connection dictionary of target vertex, try AddConnectionDir()");

            // set the double connection between current vertex and target vertex
            _connection[direction] = new Edge<DataType>(this, target, cost);
            target._connection[targetDirection] = new Edge<DataType>(target, this, cost);
        }

        /// <summary>
        /// Add a new dirction to the connection list
        /// </summary>
        /// <param name="direction">the direction to add</param>
        /// <exception cref="ArgumentException">If the connection alread exist</exception>
        public void AddConnectionDir(string direction)
        {
            // handle all the possible exceptions
            if (direction == null)
                throw new ArgumentNullException("direction", "The direction cannot be null.");

            if (_connection.ContainsKey(direction))
                throw new ArgumentException("direction", "The connection to certain direction already exist, try use SetConnection()");
            _connection.Add(direction, null);
        }

        /// <summary>
        /// The overload method of AddConnection, contains both direction and target
        /// </summary>
        /// <param name="direction">the direction of new connection</param>
        /// <param name="target">the target of new connection</param>
        /// <exception cref="ArgumentNullException">If the parameter passed into the method is null</exception>
        /// <exception cref="ArgumentException">If the connection alread exist</exception>
        public void AddConnection(string direction, Vertex<DataType> target, float cost)
        {
            // handle all the possible exceptions
            if (direction == null)
                throw new ArgumentNullException("direction", "The direction cannot be null.");
            if (target == null)
                throw new ArgumentNullException("target", "The target cannot be null.");

            if (_connection.ContainsKey(direction))
                throw new ArgumentException("direction", "The connection to certain direction already exist, try use SetConnection()");
            _connection.Add(direction,
                new Edge<DataType>(this, target, cost));
        }

        /// <summary>
        /// Add the double connection between current vertex and the target veretex
        /// </summary>
        /// <param name="direction">the direction of target vertex to the current vertex</param>
        /// <param name="target">the target vertex</param>
        /// <param name="targetDirection">the direction of current vertex to the target vertex</param>
        /// <param name="cost">the cost of the connection</param>
        /// <exception cref="ArgumentNullException">If the parameter passed into the method is null</exception>
        /// <exception cref="ArgumentException">If the connection alread exist</exception>
        public void AddDoubleConnection(string direction, Vertex<DataType> target, string targetDirection, float cost)
        {
            // handle all the possible exceptions
            if (direction == null)
                throw new ArgumentNullException("direction", "The direction cannot be null.");
            if (target == null)
                throw new ArgumentNullException("target", "The target cannot be null.");
            if (targetDirection == null)
                throw new ArgumentNullException("targetDirection", "The targetDirection cannot be null");

            if (_connection.ContainsKey(direction))
                throw new ArgumentException("direction", "The connection to certain direction already exist, try use SetConnection()");
            _connection.Add(direction,
                new Edge<DataType>(this, target, cost));
            // try to add connection to the target vertex
            try
            {
                target.AddConnection(targetDirection, this, cost);
            }catch(ArgumentException AE)
            {
                // if the direction already exist in the dictionary
                target.SetConnection(targetDirection, this, cost);
            }
        }

        #endregion

        /// <summary>
        /// Override the ToString method of Vertex class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string res = "";
            res += "Vertex coordinate: " + _coordinate.ToString() + "\n";
            res += "Cost: " + _cost.ToString();
            res += "\n";
            res += "Connections: \n";
            res += string.Join(Environment.NewLine, _connection);
            if (_data != null)
                res += "\nData: " + this._data.ToString();
            else
                res += "\nData: null";

            return res;
        }
    }
}