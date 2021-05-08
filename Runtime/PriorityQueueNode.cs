using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FinTOKMAK.PriorityQueue
{
    public class PriorityQueueNode<DataT>
    {
        #region Private Field
        // data stored in the wrapper class
        private DataT m_Data;
        // priority of this node
        private float m_Priority;
        #endregion

        #region Public Field
        public DataT data
        {
            get { return m_Data; }
            set { m_Data = value; }
        }

        public float priority
        {
            get { return m_Priority; }
            set { m_Priority = value; }
        }

        /// <summary>
        /// the index of current node
        /// </summary>
        public int index;

        #endregion
    }
}