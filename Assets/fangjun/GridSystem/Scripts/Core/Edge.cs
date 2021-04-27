using System.Collections;
using System.Collections.Generic;

namespace GridSystem
{
    public class Edge<DataType>
    {

        #region Private Field

        // the basic info of the edge
        private Vertex<DataType> m_from;
        private Vertex<DataType> m_to;
        private float m_cost;

        #endregion

        #region Public Field

        /// <summary>
        /// The start vertex of the edge
        /// </summary>
        public Vertex<DataType> from
        {
            get
            {
                return m_from;
            }
            set
            {
                m_from = value;
            }
        }

        /// <summary>
        /// The end vertex of the edge
        /// </summary>
        public Vertex<DataType> to
        {
            get
            {
                return m_to;
            }
            set
            {
                m_to = value;
            }
        }

        /// <summary>
        /// The cost of this edge
        /// </summary>
        public float cost
        {
            get
            {
                return m_cost;
            }
            set
            {
                m_cost = value;
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
            m_from = from;
            m_to = to;
            m_cost = cost;
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