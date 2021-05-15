﻿using System.Collections;
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
        private Vertex<DataType> _from;
        private Vertex<DataType> _to;
        private float _cost;

        #endregion

        #region Public Field

        /// <summary>
        /// The start vertex of the edge
        /// </summary>
        public Vertex<DataType> from
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
        /// The end vertex of the edge
        /// </summary>
        public Vertex<DataType> to
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
        public Edge(Vertex<DataType> from, Vertex<DataType> to, float cost)
        {
            _from = from;
            _to = to;
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
            res += from.coordinate.ToString();
            res += " => ";
            res += to.coordinate.ToString();
            res += " : ";
            res += cost.ToString();

            return res;
        }
    }
}