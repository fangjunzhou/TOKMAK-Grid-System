using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fangjun.PriorityQueue
{
    public class PriorityQueue<DataT> : PriorityQueueADT<PriorityQueueNode<DataT>>
    {
        #region Private Field
        // all the nodes in the PriorityQueue
        private List<PriorityQueueNode<DataT>> priorityQueueNodes = new List<PriorityQueueNode<DataT>>();
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
                    priorityQueueNodes[parentIndex] = temp;

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
        private void PerculateDown(int index)
        {
            int maxIndex = CompareChildren(index);
            while(maxIndex != index)
            {
                // exchange
                PriorityQueueNode<DataT> temp = priorityQueueNodes[index];
                priorityQueueNodes[index] = priorityQueueNodes[maxIndex];
                priorityQueueNodes[maxIndex] = temp;

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

        public bool Push(PriorityQueueNode<DataT> data)
        {
            if (data == null)
            {
                return false;
            }

            // add to the end of the list
            priorityQueueNodes.Add(data);
            // perculate up
            PerculateUp(priorityQueueNodes.Count - 1);

            return true;
        }

        public PriorityQueueNode<DataT> Pop()
        {
            PriorityQueueNode<DataT> res = priorityQueueNodes[0];
            priorityQueueNodes[0] = priorityQueueNodes[priorityQueueNodes.Count - 1];
            priorityQueueNodes.RemoveAt(priorityQueueNodes.Count - 1);
            PerculateDown(0);

            return res;
        }

        public PriorityQueueNode<DataT> Peek()
        {
            return priorityQueueNodes[0];
        }

        public override string ToString()
        {
            string res = "";
            foreach (PriorityQueueNode<DataT> node in priorityQueueNodes)
            {
                res += node.data + "," + node.priority + ";";
            }
            return res;
        }
    }
}