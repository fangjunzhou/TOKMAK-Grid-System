using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fangjun.PriorityQueue
{
    public interface PriorityQueueADT<T>
    {
        /// <summary>
        /// Push a new element into the PriorityQueue
        /// </summary>
        /// <param name="data">the data you want to store</param>
        /// <returns>return true if success</returns>
        bool push(T data);

        /// <summary>
        /// Return and remove the largest node in the PriorityQueue
        /// </summary>
        /// <returns>the largest node in the PriorityQueue</returns>
        T pop();

        /// <summary>
        /// Return but not remove the largest node in the PriorityQueue
        /// </summary>
        /// <returns>the largest node in the PriorityQueue</returns>
        T peek();

        /// <summary>
        /// Check if the PriorityQueue is empty
        /// </summary>
        /// <returns>return true if empty</returns>
        bool isEmpty();

        /// <summary>
        /// Get the length of the whole PriorityQueue
        /// </summary>
        /// <returns>the length of the whole PriorityQueue</returns>
        int getLength();
    }
}
