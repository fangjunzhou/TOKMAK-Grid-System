using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FinTOKMAK.PriorityQueue
{
    public class PriorityQueue<DataT> : PriorityQueueADT<DataT>
    {
        #region Private Field
        // all the nodes in the PriorityQueue
        private List<PriorityQueueNode<DataT>> priorityQueueNodes = new List<PriorityQueueNode<DataT>>();
        private Dictionary<DataT, PriorityQueueNode<DataT>> dataNodePairs = new Dictionary<DataT, PriorityQueueNode<DataT>>();
        #endregion

        #region Public Field

        public bool isEmpty
        {
            get
            {
                if (priorityQueueNodes.Count == 0)
                {
                    return true;
                }
                return false;
            }
        }

        public int length
        {
            get
            {
                return priorityQueueNodes.Count;
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Perculate up at specific index
        /// </summary>
        /// <param name="index">the index of new node added</param>
        /// <returns>the new index of the node</returns>
        private void PerculateUp(int index)
        {
            while(index > 0)
            {
                bool res = CompareParent(index);
                // exchange
                if (res)
                {
                    // parent index
                    int parentIndex = (index - 1) / 2;
                    PriorityQueueNode<DataT> temp = priorityQueueNodes[index];
                    priorityQueueNodes[index] = priorityQueueNodes[parentIndex];
                    priorityQueueNodes[index].index = index;
                    priorityQueueNodes[parentIndex] = temp;
                    priorityQueueNodes[parentIndex].index = parentIndex;

                    // update index
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Compare the node at index and its prarent
        /// </summary>
        /// <param name="index">the target index of node to compare</param>
        /// <returns>return true if is greater than its parent;
        /// false if is less or equal than its prarent</returns>
        private bool CompareParent(int index)
        {
            // get the node
            PriorityQueueNode<DataT> priorityQueueNode = priorityQueueNodes[index];
            // parent index
            int parentIndex = (index - 1) / 2;
            // get parent node
            PriorityQueueNode<DataT> parentQueueNode = priorityQueueNodes[parentIndex];

            if (priorityQueueNode.priority > parentQueueNode.priority)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Perculate Down at the specific index
        /// </summary>
        /// <param name="index">the root of the array(List)</param>
        /// <returns>the new index of the node</returns>
        private void PerculateDown(int index)
        {
            int maxIndex = CompareChildren(index);
            while(maxIndex != index)
            {
                // exchange
                PriorityQueueNode<DataT> temp = priorityQueueNodes[index];
                priorityQueueNodes[index] = priorityQueueNodes[maxIndex];
                priorityQueueNodes[index].index = index;
                priorityQueueNodes[maxIndex] = temp;
                priorityQueueNodes[maxIndex].index = maxIndex;

                // update index
                index = maxIndex;
                // update max index
                maxIndex = CompareChildren(index);
            }
        }

        /// <summary>
        /// Compare the node at the index and its two children
        /// </summary>
        /// <param name="index">the target index to check</param>
        /// <returns>the index with max priority</returns>
        private int CompareChildren(int index)
        {
            // left child and right child index
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            // left child and right child eligibility
            bool leftChildEligible = leftChildIndex < priorityQueueNodes.Count;
            bool rightChildEligible = rightChildIndex < priorityQueueNodes.Count;

            int maxIndex = index;
            // compare left child
            if (leftChildEligible)
            {
                if (priorityQueueNodes[leftChildIndex].priority > priorityQueueNodes[maxIndex].priority)
                    maxIndex = leftChildIndex;
            }
            if (rightChildEligible)
            {
                if (priorityQueueNodes[rightChildIndex].priority > priorityQueueNodes[maxIndex].priority)
                    maxIndex = rightChildIndex;
            }

            return maxIndex;
        }
        #endregion

        public bool Push(DataT data, float priority)
        {
            if (data == null || dataNodePairs.ContainsKey(data))
            {
                return false;
            }
            
            PriorityQueueNode<DataT> wrapperData = new PriorityQueueNode<DataT>()
            {
                data = data,
                priority = priority,
                index = priorityQueueNodes.Count
            };

            // add to the end of the list
            priorityQueueNodes.Add(wrapperData);
            // perculate up
            PerculateUp(priorityQueueNodes.Count - 1);
            
            // add the index to dataIndexPairs
            dataNodePairs.Add(data, wrapperData);

            return true;
        }
        
        public bool ChangePriority(DataT data, float priority)
        {
            if (!dataNodePairs.ContainsKey(data))
                return false;
            
            // get the index
            int index = dataNodePairs[data].index;
            PriorityQueueNode<DataT> wrapperData = priorityQueueNodes[index];
            // record the old priority
            float oldPriority = wrapperData.priority;
            wrapperData.priority = priority;
            // if the new priority is larger
            if (priority > oldPriority)
            {
                // perculate up
                PerculateUp(index);
            }
            else if (priority < oldPriority)
            {
                // perculate down
                PerculateDown(index);
            }

            return true;
        }

        public DataT Pop()
        {
            // remove the first element in the list
            PriorityQueueNode<DataT> res = priorityQueueNodes[0];
            // move the last element to the first
            priorityQueueNodes[0] = priorityQueueNodes[priorityQueueNodes.Count - 1];
            priorityQueueNodes[0].index = 0;
            
            priorityQueueNodes.RemoveAt(priorityQueueNodes.Count - 1);
            
            PerculateDown(0);

            return res.data;
        }

        public DataT Peek()
        {
            return priorityQueueNodes[0].data;
        }

        public DataT GetElement(DataT data)
        {
            if (!dataNodePairs.ContainsKey(data))
                return default;
            
            return dataNodePairs[data].data;
        }

        public override string ToString()
        {
            string res = "";
            foreach (PriorityQueueNode<DataT> node in priorityQueueNodes)
            {
                res += node.data + ", " + node.priority + ", " + node.index + "|||";
            }
            return res;
        }
    }
}