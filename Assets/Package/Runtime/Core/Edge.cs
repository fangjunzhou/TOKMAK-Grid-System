using System.Collections;
using System.Collections.Generic;

namespace FinTOKMAK.GridSystem
{
    /// <summary>
    /// The base class for an Edge between Verteces
    /// </summary>
    /// <typeparam name="DataType">The data type of vertices</typeparam>
    public class Edge<DataType> where DataType : GridDataContainer
    {

        #region Private Field

        // the basic info of the edge
        private GridCoordinate _from;
        private int _fromGridSystemID;
        private GridCoordinate _to;
        private int _toGridSystemID;
        private float _cost;

        #endregion

        #region Public Field

        /// <summary>
        /// The coordinate of start vertex of the edge
        /// </summary>
        public GridCoordinate from
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
            }
        }

        /// <summary>
        /// The ID of the GridSystem from Vertex belong to
        /// </summary>
        public int fromGridSystemID
        {
            get
            {
                return _fromGridSystemID;
            }
            set
            {
                _fromGridSystemID = value;
            }
        }

        /// <summary>
        /// The coordinate of end vertex of the edge
        /// </summary>
        public GridCoordinate to
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
            }
        }

        /// <summary>
        /// The ID of the GridSystem to Vertex belong to
        /// </summary>
        public int toGridSystemID
        {
            get
            {
                return _toGridSystemID;
            }
            set
            {
                _toGridSystemID = value;
            }
        }

        /// <summary>
        /// The cost of this edge
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

        #endregion

        #region Constructor

        /// <summary>
        /// The basic constructor of an Edge
        /// </summary>
        /// <param name="from">The start vertex of the edge</param>
        /// <param name="to">The end vertex of the edge</param>
        /// <param name="cost">the cost of current edge</param>
        public Edge(GridCoordinate from, int fromID, GridCoordinate to, int toID, float cost)
        {
            _from = from;
            _fromGridSystemID = fromID;
            _to = to;
            _toGridSystemID = toID;
            _cost = cost;
        }

        #endregion

        /// <summary>
        /// Override the ToString method of Edge
        /// </summary>
        /// <returns>Edge info: (from => to : cost)</returns>
        public override string ToString()
        {
            string res = "";
            res += "(";
            res += from.ToString();
            res += " => ";
            res += to.ToString();
            res += " : ";
            res += cost.ToString();

            return res;
        }
    }
}