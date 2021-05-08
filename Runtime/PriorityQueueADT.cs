using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FinTOKMAK.PriorityQueue
{
    public interface PriorityQueueADT<T>
    {
        /// <summary>
        /// Push a new element into the PriorityQueue
        /// </summary>
        /// <param name="data">the data you want to store</param>
        /// <param name="priority">the priority of the node</param>
        /// <returns>return true if success</returns>
        bool Push(T data, float priority);

        /// <summary>
        /// Change the priority of an Object
        /// </summary>
        /// <param name="data">the Object to change priority</param>
        /// <param name="priority">the priority to change</param>
        /// <returns></returns>
        bool ChangePriority(T data, float priority);

        /// <summary>
        /// Return and remove the largest node in the PriorityQueue
        /// </summary>
        /// <returns>the largest node in the PriorityQueue</returns>
        T Pop();

        /// <summary>
        /// Return but not remove the largest node in the PriorityQueue
        /// </summary>
        /// <returns>the largest node in the PriorityQueue</returns>
        T Peek();

        /// <summary>
        /// Check if the PriorityQueue contain certain element
        /// </summary>
        /// <param name="data">the data to check</param>
        /// <returns>true if the PriorityQueue contains certain element</returns>
        T GetElement(T data);

        /// <summary>
        /// Clear all the nodes in the PriorityQueue
        /// </summary>
        void Clear();

        /// <summary>
        /// Check if the PriorityQueue is empty
        /// </summary>
        /// <returns>return true if empty</returns>
        bool isEmpty { get; }

        /// <summary>
        /// Get the length of the whole PriorityQueue
        /// </summary>
        /// <returns>the length of the whole PriorityQueue</returns>
        int length { get; }
    }
}
