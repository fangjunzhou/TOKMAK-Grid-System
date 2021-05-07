using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fangjun.PriorityQueue
{
    public class TestQueueNode : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            PriorityQueueNode<int> priorityQueueNode = new PriorityQueueNode<int>();
            priorityQueueNode.data = 10;
            priorityQueueNode.priority = 20;
            Debug.Log("Priority: " + priorityQueueNode.priority.ToString());
            Debug.Log("Data: " + priorityQueueNode.data.ToString());
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
