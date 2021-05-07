using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fangjun.PriorityQueue
{
    public class PriorityQueueNode<DataT>
    {
        #region Private Field
        // data stored in the wrapper class
        private DataT m_Data;
        // priority of this node
        private int m_Priority;
        #endregion

        #region Public Field
        public DataT data
        {
            get { return m_Data; }
            set { m_Data = value; }
        }

        public int priority
        {
            get { return m_Priority; }
            set { m_Priority = value; }
        }
        #endregion
    }
}